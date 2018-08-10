using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send
{
    internal class General
    {
        public static byte[] Pong(){
            var pw = new PacketWriter(SendOps.PONG);
            pw.Timestamp();

            return pw.ToArray();
        }

        public static byte[] ChangeChannel(Client c, byte channel){
            var pw = new PacketWriter(SendOps.CHANGE_CHANNEL);
            //var pw = new PacketWriter(c.EncryptedHeaders[SendOps.CHANGE_CHANNEL]);
            pw.WriteByte(channel);
            pw.Timestamp();

            return pw.ToArray();
        }

        public static byte[] EnterCS(){
            var pw = new PacketWriter(SendOps.ENTER_CASHSHOP);
            pw.Timestamp();
            pw.WriteByte();
            return pw.ToArray();
        }

        public static byte[] ExitCS(){
            var pw = new PacketWriter(SendOps.ENTER_PORTAL);
            return pw.ToArray();
        }
    }
}
