using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types.Map;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send
{
    internal class RuneRequests
    {
        public static byte[] RequestRune(Client c, Rune rune)
        {
            var pw = new PacketWriter(SendOps.RUNE_REQUEST);
            pw.WriteInt(0);
            pw.WriteInt(rune.Type);
            return pw.ToArray();
        }

        public static byte[] SendKey(Client c, int count, int dir)
        {
            var pw = new PacketWriter(SendOps.RUNE_KEY);
            pw.WriteInt(count);
            pw.WriteInt(dir);
            return pw.ToArray();
        }

        public static byte[] SendLocation(Client c, Rune rune)
        {
            var pw = new PacketWriter(SendOps.RUNE_LOCATION);
            pw.WriteByte(1);
            pw.WriteInt(rune.X);
            pw.WriteInt(rune.Y);
            return pw.ToArray();
        }
    }
}
