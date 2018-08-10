using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv.Map
{
    internal class Player
    {
        //Needs updating
        public static void Spawn(Client c, PacketReader r)
        {
            //Console.WriteLine("Warning Player Detector is off");
            int id = r.ReadInt();
            r.ReadByte(); //Level
            string ign = r.ReadMapleString();
            if (id != c.Account.info.UserId){
                Console.WriteLine("Player Detected: "+ign +" Disconnecting for 2 minutes.");
                c.Disconnect(true, 180000);
            }
            //r.ReadMapleString(); // Ultimate Explorer's Parent
            //r.ReadMapleString(); // Guild
            //r.Skip(19); // [LogoBG (2)] [Color (1)] [Logo (2)] [Color (1)] 00 [40 00 00 00] [01 00 00 00] [00 00 00 00]

            // Sub
            //r.Skip(64 + 4 + 64); // [Mostly Zeros (64] FF FF FF FF [??? (64)]
            //r.Next(01); // End of Time Encoding
            //r.Skip(12); // ?? ?? ?? ?? [Zero (8)]
            //r.Skip(30); // [TimeEncode (5)] [00 00] [00 00 00 00] [00 00 00 00] [TimeEncode (5)] [00 00] [00 00 00 00] [00 00 00 00]
            //r.Skip(13); // [TimeEncode (5)] [00 00 00 00] [00 00 00 00]
            //r.Skip(20); // [TimeEncode (5)] 00 [DE AC 77 DA] [00 00 00 00] [00 00 00 00] [00 00]
            //r.Skip(28); // [TimeEncode (5)] [Zero (16)] [TimeEncode (5)] 00 00

            //short job = r.ReadShort(); // JOB 
            //r.Skip(6); // [SubJob (2)] [? (4)]
            //r.SkipAppearance(job);
            //r.Skip(4 * 14 + 14); // [00 00 00 00] * 14 [FF FF] [00 00 00 00 00 00 00 00 00 00 00 00]

            //var position = r.ReadPosition();
            //r.Skip(1); // Type or stance?
            //short foothold = r.ReadShort();
            //r.Skip(17); // Unknown shit
            //bool hasPermit = r.ReadBool(); // 0x05 means Permit

            // Create Player
            //var player = new Types.Map.Player(id)
            //{
            //    Name = ign,
            //    Position = position,
            //    Foothold = foothold,
            //    HasPermit = hasPermit
            //};
            //c.Map.SpawnPlayer(player);
            //c.Info.PeopleCount++;
            //c.UpdateInfo.Report(c.Info);
        }

        public static void Despawn(Client c, PacketReader r)
        {
            int id = r.ReadInt();
            //c.Map.DespawnPlayer(id);
            //c.Info.PeopleCount--;
            //c.UpdateInfo.Report(c.Info);
        }

        public static void AckAttack(Client c, PacketReader r)
        {
            int id = r.ReadInt();
            //Sometimes you can get an ACK of an old monster after a CS, client doesnt despawn them from memory....
            if(c.Map.Mobs.ContainsKey(id))
                c.Map.Mobs[id].waitForAck = false;
            //if (c.Account.info.attackAckID == id)
            //    c.Account.info.attackAckID = 0;
            //else
            //    c.Account.info.missCount++;
            r.Skip(1); //Unknown
        }

    }
}

