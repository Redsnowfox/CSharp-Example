using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedTools;
using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types;
using MapleCLBUpdate.Types.Items;
using System.Threading;
using MapleCLBUpdate.Packets.Send;

namespace MapleCLBUpdate.Forms
{
    public partial class ClientForm : UserControl
    {
        private Client client;
        private DateTime uptime;
        public IProgress<bool> ConnectToggle;
        public Progress<Mapler> UpdateMapler;
        public Progress<Info> UpdateInfo;
        public Progress<String> UpdateAction;
        public Progress<Inventory> UpdateInventory;

        private RusherForm rusherForm;

        bool debug = true;

        public ClientForm()
        {
            InitializeComponent();
            userNameBox.SetCueBanner("Username");
            passwordBox.SetCueBanner("Password");
            picBox.SetCueBanner("PIC");
            slotBox.SetCueBanner("Slot");
            InitializeProgress();
            client = new Client(this);
        }

        //Temp maybe
        public Account GetAccount()
        {
            if (debug)
            {
                return new Account
                {
                    Username = "@gmail.com",
                    Password = "",
                    Pic = "",
                    Select = "1",
                    Mode = (byte)0,
                    Channel = (byte)7,
                    World = (byte)2
                };
            }
            else
            {
                return new Account
                {
                    Username = userNameBox.Text,
                    Password = passwordBox.Text,
                    Pic = picBox.Text,
                    Select = slotBox.Text,
                    Mode = (byte)modeSelect.SelectedIndex,
                    Channel = (byte)channelSelect.SelectedIndex,
                    World = (byte)worldSelect.SelectedIndex
                };
            }
        }

        private void InitializeProgress()
        {
            ConnectToggle = new Progress<bool>(b => {
                connectButton.Text = b ? "Connect" : "Disconnect";
                userNameBox.Enabled = b;
                passwordBox.Enabled = b;
                picBox.Enabled = b;
                slotBox.Enabled = b;
                worldSelect.Enabled = b;
                channelSelect.Enabled = b;
                modeSelect.Enabled = b;
                upTimer.Enabled = !b;
                uptime = new DateTime();
            });

            /* Stats */
            UpdateMapler = new Progress<Mapler>(m => {
                if (m != null){
                    nameStat.Text = m.Name;
                    mapStat.Text = m.Map.ToString();
                    levelStat.Text = m.Level.ToString();
                    expStat.Text = (decimal.Divide(m.Exp, Resources.Exp.PlayerExp[m.Level]) * 100).ToString("F") + '%';
                    //RushView.Update(m.Map);
                }else{
                    nameStat.Text = "Offline";
                    mapStat.Text = "Offline";
                    levelStat.Text = "Offline";
                    expStat.Text = "Offline";
                }
            });

            UpdateInfo = new Progress<Info>(i => {
                if (i != null){
                    channelStat.Text = i.Channel.ToString();
                    peopleStat.Text = i.PeopleCount.ToString();
                    monsterStat.Text = i.MonsterCount.ToString();
                }else{
                    channelStat.Text = "Offline";
                    peopleStat.Text = "Offline";
                    monsterStat.Text = "Offline";
                }
            });

            UpdateAction = new Progress<string>(s =>
            {
                actionStat.Text = s;
            });

        }

        private void UpTimer_Tick(object sender, EventArgs e){
            uptime = uptime.AddSeconds(1);
            timeStat.Text = uptime.ToString("HH:mm:ss");
        }

        private void connectButton_Click(object sender, EventArgs e){
            if (connectButton.Text.Equals("Connect"))
            {
                Task.Run(() => client.grabPassport()).Wait();
                Task.Factory.StartNew(() =>
                {
                    client.Connect();
                }, TaskCreationOptions.LongRunning);
            }
            else
            {
                client.Disconnect(false,0);
            }
        }

        private void MiscBtn_Click(object sender, EventArgs e)
        {

        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            client.State = ClientState.CASHSHOP;
            client.SendPacket(General.EnterCS());
        }

        private void rusherBtn_Click(object sender, EventArgs e)
        {
            rusherForm = new RusherForm();
            rusherForm.SetClient(client);
            rusherForm.Update(client.Mapler.Map);
            rusherForm.Show();
        }
    }
}
