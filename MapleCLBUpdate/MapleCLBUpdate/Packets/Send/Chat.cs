using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send
{
    internal class Chat
    {
        public static byte[] All(Client c, string msg)
        {
            var pw = new PacketWriter(28);
            pw.Timestamp();
            pw.WriteMapleString(msg);
            pw.WriteByte();

            return pw.ToArray();
        }
    }
}
