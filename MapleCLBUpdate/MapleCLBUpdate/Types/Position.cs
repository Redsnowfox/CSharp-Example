using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types
{
    public class Position
    {
        public short X { get; set; }
        public short Y { get; set; }

        public Position(short x, short y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    internal static class PositionPacketExtensions
    {
        internal static void WritePosition(this PacketWriter pw, Position p)
        {
            pw.WriteShort(p.X);
            pw.WriteShort(p.Y);
        }

        internal static Position ReadPosition(this PacketReader pr)
        {
            return new Position(pr.ReadShort(), pr.ReadShort());
        }
    }
}