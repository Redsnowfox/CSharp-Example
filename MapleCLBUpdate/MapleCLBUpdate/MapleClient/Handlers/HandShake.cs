using MapleCLBUpdate.Packets.Send;
using MapleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.MapleClient.Handlers
{
    internal class Handshake : Handler<ServerInfo>
    {
        internal Handshake(Client client) : base(client) { }

        internal async override void Handle(object session, ServerInfo info)
        {
            switch (client.State)
            {
                case ClientState.DISCONNECTED:
                    Console.WriteLine("Validating login for MapleStory v" + info.Version + "." + info.Subversion);
                    SendPacket(Login.Validate(info.Locale, info.Version, short.Parse(info.Subversion)));
                    await client.PutTaskDelay(30);
                    SendPacket(Login.GetServers());
                    await client.PutTaskDelay(30);
                    SendPacket(Login.ClientLogin(client.Account));
                    client.State = ClientState.LOGIN;
                    client.UpdateAction.Report("Login");
                    break;

                case ClientState.LOGIN:
                    //Console.WriteLine("Logged in!");
                    SendPacket(Login.EnterServer(client.Account));
                    client.State = ClientState.GAME;
                    client.UpdateAction.Report("In Game");
                    client.startScript(client.mode);
                    break;

                case ClientState.GAME:
                    //Console.WriteLine("Back in game!");
                    SendPacket(Login.EnterServer(client.Account));
                    client.State = ClientState.GAME;
                    client.UpdateAction.Report("In Game");
                    client.Map.Clear();
                    client.startScript(client.mode);
                    break;

                case ClientState.CASHSHOP:
                    SendPacket(Login.EnterServer(client.Account));
                    client.UpdateAction.Report("Cash Shop");
                    await client.PutTaskDelay(3000);
                    SendPacket(General.ExitCS());
                    client.State = ClientState.GAME;
                    break;
            }
        }
    }
}