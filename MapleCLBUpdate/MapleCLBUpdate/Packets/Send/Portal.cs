using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send
{
    internal class Portal
    {
        public static byte[] Enter(Info info, PortalInfo data)
        {
            var pw = new PacketWriter(SendOps.ENTER_PORTAL);
            pw.WriteByte(info.PortalCount);
            pw.WriteInt(-1); // FF FF FF FF
            pw.WriteInt(info.PortalCrc);
            pw.WriteMapleString(data.Name);
            pw.WritePosition(data.Position);
            pw.WriteZero(3); //what is this

            return pw.ToArray();
        }
        /*
        public static byte[] EnterCutScene(Info info, int id, PortalInfo data)
        {
            var pw = new PacketWriter(SendOps.ENTER_PORTAL);
            pw.WriteByte(info.PortalCount);
            pw.WriteInt(id); // this is acutally map ID i think.
            pw.WriteInt(info.cutSceneCrc);
            pw.WriteMapleString(data.Name);
            pw.WriteZero(3); //what is this
            return pw.ToArray();
        }

        public static byte[] EnterSpecial(Info info, PortalInfo data)
        {
            var pw = new PacketWriter(SendOps.SPECIAL_PORTAL);
            pw.WriteByte(info.PortalCount);
            pw.WriteMapleString(data.Name);
            pw.WritePosition(data.Position);

            return pw.ToArray();
        }
        */
    }
}