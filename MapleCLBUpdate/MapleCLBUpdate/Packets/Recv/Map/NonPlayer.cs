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
    internal class NonPlayer
    {
        //Needs updating
        public static void Spawn(Client c, PacketReader r)
        {
            int UID = r.ReadInt();
            int NPCid = r.ReadInt();
            var position = r.ReadPosition(); // [X (2)] [Y (2)]

            // Create NPC
           // var npc = new Types.Map.NonPlayerType(UID)
           // {
           //     Position = position,
          //      NpcId = NPCid,
           // };
            //c.Map.SpawnNpc(npc);
        }

        public static void Despawn(Client c, PacketReader r)
        {
            int id = r.ReadInt();
            //c.Map.DespawnNpc(id);
        }

        //Not all NPCs are spawned but can still be accessed fking bs
        public static void SpawnController(Client c, PacketReader r)
        {
            if (r.ReadBool())
            {
                int UID = r.ReadInt();
                int NPCid = r.ReadInt();
                var position = r.ReadPosition(); // [X (2)] [Y (2)]
                                                 // Create NPC
               // var npc = new Types.Map.NonPlayerType(UID)
               // {
               //     Position = position,
               //     NpcId = NPCid,
               // };
                //c.Map.SpawnNpcController(npc);
            }
            else
            {
                int id = r.ReadInt();
                //c.Map.DespawnNpcController(id);
            }
        }


    }
}
