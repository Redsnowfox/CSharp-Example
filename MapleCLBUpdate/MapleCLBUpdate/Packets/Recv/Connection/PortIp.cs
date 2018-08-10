using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv.Connection
{
    internal class PortIp
    {
        public static void ServerIp(Client c, PacketReader r)
        {
            r.ReadShort();
            byte[] serverIp = r.ReadBytes(4);
            short port = r.ReadShort();
            string ip = $"{serverIp[0]}.{serverIp[1]}.{serverIp[2]}.{serverIp[3]}";
            c.Reconnect(ip, port);
        }

        public static void ChannelIp(Client c, PacketReader r)
        {
            r.ReadByte();
            byte[] channelIp = r.ReadBytes(4);
            short port = r.ReadShort();
            string ip = $"{channelIp[0]}.{channelIp[1]}.{channelIp[2]}.{channelIp[3]}";
            c.Reconnect(ip, port);
        }
    }
}
