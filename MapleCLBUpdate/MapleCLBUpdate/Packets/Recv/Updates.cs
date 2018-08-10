using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Resources;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv{
    class Updates{

        //Find better spot for this
        public static void FailedCC(Client c, PacketReader r){
            Thread.Sleep(5000);
            if(c.Account.info.ccFailedCount++ == 3)
            {
                c.Account.info.ccFailedCount = 0;
                Console.WriteLine("Failed to CS 3 times, dcing for 1 Minute");
                c.Disconnect(true, 60000);
            }
            c.SendPacket(Send.General.EnterCS());
                //c.SendPacket(Send.General.ChangeChannel(c, (byte)(c.Account.info.GrabNextCh())));
        }

        //Needs updating
        public static void Inventory(Client c, PacketReader r)
        {

        }

        public static void Status(Client c, PacketReader r){
            switch (r.ReadByte()){
                case 0x00: // Meso update
                    r.Skip(7);//Unknown
                    c.Inventory.Mesos = r.ReadLong();
                    //Update Mesos call
                    break;
                case 0x04: // Exp update
                    r.Skip(1);//Unknown
                    long exp = c.Mapler.Exp + r.ReadLong();
                    if (exp >= Exp.PlayerExp[c.Mapler.Level]){
                        Console.WriteLine("Leveled!");
                        c.Mapler.Exp = exp - Exp.PlayerExp[c.Mapler.Level];
                        c.Mapler.Level++;
                    }
                    else
                        c.Mapler.Exp = exp;

                    c.UpdateMapler.Report(c.Mapler);
                    break;
                default:
                    break;
            }

        }
    }
}
