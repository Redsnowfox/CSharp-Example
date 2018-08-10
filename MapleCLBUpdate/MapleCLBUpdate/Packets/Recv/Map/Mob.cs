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
    internal class Mob
    {
        public static void Spawn(Client c, PacketReader r)
        {
            r.Skip(1);
            int id = r.ReadInt(); // [Id (4)]
            r.Skip(1);
            int mobId = r.ReadInt(); // [MobId (4)]

            if (r.ReadBool()){ 
                return;
            }

            r.Skip(163); // [?? (4)] [?? (16)] [MobStatus (151)]
            var position = r.ReadPosition();
            // [Stance (1)] [Fh (2)] [InitFh (2)] [Animation -1=instant,-2=fade (2)] FF 7D 
            // [Zero (24)] [FF FF FF FF] 00 [Zero (8)] [FF FF FF FF] [00 00 00 00]
            var mob = new Types.Map.Mob(id)
            {
                Crc = mobId, // Fine for now
                MobId = mobId,
                Position = position
            };
            c.Map.SpawnMob(mob);
            c.Account.info.MonsterCount = c.Map.Mobs.Count;
            Console.WriteLine("Added Mob: " + mob.Id);
            c.UpdateInfo.Report(c.Account.info);
        }

        public static void Update(Client c, PacketReader r)
        {
            int id = r.ReadInt(); // [Id (4)]
            Types.Map.Mob mob;
            if (!c.Map.Mobs.TryGetValue(id, out mob))
            { // Mob doesn't exist
                return;
            }
            r.ReadByte(); // Use skill
            r.ReadByte(); // What Skill
            r.Skip(4); // [Unknown (4)]
            r.Skip(6); // [Zero (6)]

            var position = r.ReadPosition();
            mob.Move(position);
            //Console.WriteLine("Server Moving Mob: " + mob.Id);
        }

        public static void Control(Client c, PacketReader r){
            bool isAggro = r.ReadBool();
            int id = r.ReadInt(); // [Id (4)]
            Types.Map.Mob mob;
            if (!c.Map.Mobs.TryGetValue(id, out mob) || !isAggro){
                return;
            }
            r.Skip(1);
            r.ReadInt(); // [Template (4)]
            if (r.Available > 256){
                return;
            }
            r.Skip(162); // ???
            var position = r.ReadPosition();
            mob.Move(position);
            //Console.WriteLine("Moving Mob: " + mob.Id);
        }

        public static void Despawn(Client c, PacketReader r)
        {
            int id = r.ReadInt();
            bool isDead = r.ReadBool();
            if (isDead)
            {
                Console.WriteLine("KILLED {0}", id);
                //if (c.Map.Mobs[id].MobId == 150001)//Find a better way to script questing.
                    c.Account.info.killCount = c.Account.info.killCount + 1;
            }

            c.Map.DespawnMob(id);
            c.Account.info.MonsterCount = c.Map.Mobs.Count;
            c.UpdateInfo.Report(c.Account.info);
        }
    }
}
