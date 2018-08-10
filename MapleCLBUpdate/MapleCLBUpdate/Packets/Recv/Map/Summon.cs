using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv.Map
{
    internal class Summon
    {
        public async static void Spawn(Client c, PacketReader r)
        {
            r.Skip(4);//Unknown
            int spawnID = r.ReadInt();
            int skillID = r.ReadInt();

            var summon = new Types.Map.Summon(spawnID){
                skillID = skillID,
            };
            c.Map.SpawnSummon(summon);

            //Summons only last ~60 seconds
            //await c.PutTaskDelay(60000);
        }
    }
}
