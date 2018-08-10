using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send
{
    internal class Familiar
    {
        internal static byte[] Summon(int ID){
            var pw = new PacketWriter(SendOps.SUMMON_FAMILIAR);
            pw.Timestamp();
            pw.WriteInt(ID);
            pw.WriteBool(true);
            return pw.ToArray();
        }

        internal static byte[] Skill(int ID){
            var pw = new PacketWriter(SendOps.FAMILIAR_SKILL);
            pw.WriteBool(false);
            pw.WriteInt(ID);
            pw.WriteBool(true);
            pw.Timestamp();
            return pw.ToArray();
        }
    }
}
