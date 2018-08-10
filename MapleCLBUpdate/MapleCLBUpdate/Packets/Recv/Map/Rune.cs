using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv.Map
{
    internal class Rune
    {
        public static void Spawn(Client c, PacketReader r)
        {
            if (r.ReadLong() == 0)
                return;
            int type = r.ReadInt();
            int x = r.ReadInt();
            int y = r.ReadInt();
            r.Skip(1);
            var rune = new Types.Map.Rune()
            {
                X = x, // Fine for now
                Y = y,
                Type = type
            };
            c.Map.SpawnRune(rune);
            c.SendPacket(Send.RuneRequests.RequestRune(c,rune));
        }

        public static void ReadKey(Client c, PacketReader r)
        {
            //Need to wait 10 minutes to despawn a rune
            if(r.Available < 10) {
                //Wait 10 minutes then CS to undo the rune..
                Console.WriteLine("Need to wait 10 minutes for next rune despawn!");
                return;
            }
            r.Skip(4);
            int dir1 = r.ReadInt();
            int dir2 = r.ReadInt();
            int dir3 = r.ReadInt();
            int dir4 = r.ReadInt();

            c.SendPacket(Send.RuneRequests.SendKey(c, 0, dir1));
            c.SendPacket(Send.RuneRequests.SendKey(c, 1, dir2));
            c.SendPacket(Send.RuneRequests.SendKey(c, 2, dir3));
            c.SendPacket(Send.RuneRequests.SendKey(c, 3, dir4));
            c.SendPacket(Send.RuneRequests.SendLocation(c, c.Map.activeRune));
        }

        public static void ReadAction(Client c, PacketReader r)
        {
            string clear = "The Elite Boss curse has been lifted!";
            string response = r.ReadMapleString();
            //if (response.Equals(""))
            //    c.Map.DespawnRune();
            if (response.Equals(clear))
                c.Map.DespawnRune();
        }
    }
}
