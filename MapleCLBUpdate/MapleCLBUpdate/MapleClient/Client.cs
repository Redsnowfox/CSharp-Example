using MapleCLBUpdate.Forms;
using MapleCLBUpdate.MapleClient.Handlers;
using MapleCLBUpdate.MapleClient.Scripts;
using MapleCLBUpdate.Packets.Send;
using MapleCLBUpdate.ScriptLib;
using MapleCLBUpdate.Types;
using MapleCLBUpdate.Types.Items;
using MapleCLBUpdate.Types.Map;
using MapleLib;
using MapleLib.Packet;
using SharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleCLBUpdate.MapleClient{
    internal enum ClientState : byte{
        DISCONNECTED,
        LOGIN,
        CASHSHOP,
        GAME
    }
    public class Client{
        private const int SERVER_TIMEOUT = 20000;
        private const int CHANNEL_TIMEOUT = 10000;

        private Session session;
        private readonly Handshake handshakeHandler;
        private readonly Packet packetHandler;
        public readonly ScriptManager ScriptManager;

        private readonly ClientForm cForm;
        internal readonly IProgress<Mapler> UpdateMapler;
        internal readonly IProgress<Info> UpdateInfo;
        internal readonly IProgress<String> UpdateAction;
        internal IProgress<List<PortalInfo>> MapRush;

        internal ushort[] EncryptedHeaders;

        internal ClientState State;

        /* Game Info */
        internal Account Account;
        internal Mapler Mapler;
        internal Inventory Inventory;
        internal Map Map;

        public int mode = 1;

        /*Default Restart Values 3 Minutes and true */
        bool shouldRestart = true;
        int restartDelay = 240000;

        internal Client(ClientForm form)
        {
            cForm = form;
            EncryptedHeaders = new ushort[1200];

            //Rework script class later
            ScriptManager = new ScriptManager(this);

            handshakeHandler = new Handshake(this);
            packetHandler = new Packet(this);
            Account = cForm.GetAccount();
            mode = Account.Mode;
            Mapler = new Mapler();
            Map = new Map();
            Inventory = new Inventory();
            UpdateMapler = cForm.UpdateMapler;
            UpdateInfo = cForm.UpdateInfo;
            UpdateAction = cForm.UpdateAction;

            MapRush = new Progress<List<PortalInfo>>(list => {
                if (list == null){
                    return;
                }
                foreach (var data in list){
                    SendPacket(Portal.Enter(Account.info, data));
                    Account.info.IncrementPortalCount();
                    Thread.Sleep(30); // small delay just in case
                }
            });

        }

        public async Task<String> grabPassport(){
            string response = await WebAPI.GetAuthToken(Account.Username, Account.Password);
            Account.passport = response;
            return response;
        }

        internal void ClearStats()
        {
            UpdateMapler.Report(null);
            UpdateInfo.Report(null);
            UpdateAction.Report("Disconnected");
            //UpdateMesos.Report(-1);
            Account = cForm.GetAccount();
            Inventory.Clear();
            Map.Clear();
        }

        //Fix clearStats and ClearData to be more useful
        internal void ClearData()
        {
            Account.info.missCount = 0;
            Account.info.ccFailedCount = 0;
            Account.info.killCount = 0;
            shouldRestart = true;
            restartDelay = 240000;
        }

        public void startScript(int mode){
            //1 = login, 0 = farm
            if (mode == 0)
            {
                //ScriptManager.Get<FarmScript>().Start();
                ScriptManager.Get<NewFarmScript>().Start();
            }
        }

        public async Task PutTaskDelay(int delay){
            await Task.Delay(delay);
        }

        #region Client Connection
        internal void Connect()
        {
            Console.WriteLine("Connecting to " + Program.LoginIp + ":" + Program.LoginPort);
            cForm.ConnectToggle.Report(false);
            try
            {
                var connector = new Connector(Program.LoginIp, Program.LoginPort, Program.AesCipher);
                connector.OnConnected += OnConnected;
                connector.OnError += OnError;
                connector.Connect(SERVER_TIMEOUT);
            }
            catch
            {
                Console.WriteLine("Failed to connect.");
                cForm.ConnectToggle.Report(true);
            }
        }

        internal void Reconnect(string ip, short port)
        {
            Console.WriteLine("Reconnecting to " + ip + ":" + port);
            session.Disconnect(false);
            //temp call
            ClearData();
            //ScriptManager.Get<AttackScript>().Start();
            try
            {
                var connector = new Connector(IPAddress.Parse(ip), port, Program.AesCipher);
                connector.OnConnected += OnConnected;
                connector.OnError += OnError;

                connector.Connect(CHANNEL_TIMEOUT);

            }
            catch
            {
                session.Disconnect();
            }
        }

        //Manual call to disconnect for specified reasons
        internal void Disconnect(bool restart,int delay)
        {
            shouldRestart = restart;
            restartDelay = delay;
            session.Disconnect();
        }

        public void WriteLog(string message)
        {
            //Log.Report(message);
        }

        public void SendPacket(byte[] packet)
        {
            //This should be done in session itself.
            try
            {
                //if (cForm.IsLogSend)
                //{
                //byte[] copy = new byte[packet.Length];
                //Buffer.BlockCopy(packet, 0, copy, 0, packet.Length);
                //cForm.WriteSend.Report(copy);
                //}
                ushort oldOp = (ushort)(packet[0] | (packet[1] << 8));
                if (oldOp == Packets.SendOps.CLIENT_HELLO || oldOp == Packets.SendOps.CHAR_SELECT || oldOp == Packets.SendOps.GET_SERVERS || oldOp == Packets.SendOps.PONG || oldOp == Packets.SendOps.SERVER_LOGIN || oldOp == Packets.SendOps.PLAYER_LOGGEDIN)
                    session.SendPacket(packet);
                else
                {
                    ushort newOp = EncryptedHeaders[oldOp];
                    byte[] header = BitConverter.GetBytes(newOp);
                    packet[0] = header[0];
                    packet[1] = header[1];
                    session.SendPacket(packet);
                }
            }
            catch
            {
                //Log.Report("An error occured when attempting to send packet.");
            }
        }

        public void SendPacket(PacketWriter w)
        {
            try
            {
                //cForm.WriteSend.Report(w.Buffer);
                session.SendPacket(w.ToArray());
            }
            catch
            {
                //Log.Report("An error occured when attempting to send packet.");
            }
        }
        #endregion

        #region Event Handlers
        private void OnConnected(object o, Session s)
        {
            Console.WriteLine("Connected to server.");
            session = s;
            s.OnHandshake += handshakeHandler.Handle;
            s.OnPacket += packetHandler.Handle;
            s.OnDisconnected += OnDisconnected;
        }

        private void OnError(object c, SocketError e)
        {
            Console.WriteLine("Connection error code " + e);
            ClearStats();
            cForm.ConnectToggle.Report(false);
        }

        private void OnDisconnected(object o, EventArgs e)
        {
            Console.WriteLine("Disconnected from server, Restart: "+shouldRestart + " Restarting in: "+restartDelay/60 + " Seconds");
            State = ClientState.DISCONNECTED;
            ClearStats();
            cForm.ConnectToggle.Report(true);
            if (shouldRestart){
                Thread.Sleep(restartDelay);
                Task.Run(() => grabPassport()).Wait();
                Task.Factory.StartNew(() =>
                {
                    Connect();
                }, TaskCreationOptions.LongRunning);
            }
        }
        #endregion

        #region Script Packet Funcs (Concurrent)
        public bool AddScriptRecv(ushort header, Action<Client, PacketReader> handler){
            return packetHandler.RegisterHandler(header, handler);
        }

        public void RemoveScriptRecv(ushort header){
            packetHandler.UnregisterHandler(header);
        }

        public void WaitScriptRecv(ushort header, Blocking<PacketReader> reader, bool returnPacket){
            packetHandler.RegisterWait(header, reader, returnPacket);
        }
        #endregion

    }
}
