using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Items
{
    public enum Potential : byte
    {
        NONE = 0,
        HIDDEN_RARE = 1,
        HIDDEN_EPIC = 2,
        HIDDEN_UNIQUE = 3,
        HIDDEN_LEGEND = 4,
        RARE = 17,
        EPIC = 18,
        UNIQUE = 19,
        LEGEND = 20
    }

    public sealed class Equip : Item
    {
        public Potential Potential { get; private set; }
        public byte Enhancements { get; private set; }
        // TODO: Add all the stats :D

        public Equip(ItemType type, int id, short slot, System.Boolean hasUnqID) : base(type, id, slot, hasUnqID) { }

        internal override void Parse(PacketReader pr)
        {
            //pr.Next(0xFF); // Skip item stats
            //// [00 11 00 00] Unknown
            //if (pr.ReadShort() != 0) {
            //    pr.Skip(2);
            //} else {
            //    pr.Skip(-2);
            //}
            //// [Other Creator] [Potential (1)] [Enhancements (1)]
            //pr.ReadMapleString();
            //Potential = (Potential) pr.ReadByte();
            //Enhancements = pr.ReadByte();
            // [Potential (2 * 3)] [Bonus Potential (2 * 3)] 00 00 [Socket State (2)] [Socket (2 * 3)]
            // [Database Id (8)] [Timestamp (8)] FF FF FF FF [Zero (8)] [Timestamp (8)] [Zero (20)] 00 00
            //pr.Skip(22 + 58);

            long flag = pr.ReadInt();

            flag = ReadIfFlaggedByte(pr, flag, 0x01);
            flag = ReadIfFlaggedByte(pr, flag, 0x02);

            flag = ReadIfFlaggedShort(pr, flag, 0x04);
            flag = ReadIfFlaggedShort(pr, flag, 0x08);
            flag = ReadIfFlaggedShort(pr, flag, 0x10);
            flag = ReadIfFlaggedShort(pr, flag, 0x20);
            flag = ReadIfFlaggedShort(pr, flag, 0x40);
            flag = ReadIfFlaggedShort(pr, flag, 0x80);
            flag = ReadIfFlaggedShort(pr, flag, 0x100);
            flag = ReadIfFlaggedShort(pr, flag, 0x200);
            flag = ReadIfFlaggedShort(pr, flag, 0x400);
            flag = ReadIfFlaggedShort(pr, flag, 0x800);
            flag = ReadIfFlaggedShort(pr, flag, 0x1000);
            flag = ReadIfFlaggedShort(pr, flag, 0x2000);
            flag = ReadIfFlaggedShort(pr, flag, 0x4000);
            flag = ReadIfFlaggedShort(pr, flag, 0x8000);
            flag = ReadIfFlaggedShort(pr, flag, 0x10000);
            flag = ReadIfFlaggedShort(pr, flag, 0x20000);

            flag = ReadIfFlaggedByte(pr, flag, 0x40000);
            flag = ReadIfFlaggedByte(pr, flag, 0x80000);

            flag = ReadIfFlaggedLong(pr, flag, 0x100000);

            flag = ReadIfFlaggedInt(pr, flag, 0x200000);
            flag = ReadIfFlaggedInt(pr, flag, 0x400000);

            flag = ReadIfFlaggedShort(pr, flag, 0x800000);
            flag = ReadIfFlaggedByte(pr, flag, 0x1000000);
            flag = ReadIfFlaggedShort(pr, flag, 0x2000000);
            flag = ReadIfFlaggedInt(pr, flag, 0x4000000);

            flag = ReadIfFlaggedByte(pr, flag, 0x8000000);
            flag = ReadIfFlaggedByte(pr, flag, 0x10000000);
            flag = ReadIfFlaggedByte(pr, flag, 0x20000000);
            flag = ReadIfFlaggedByte(pr, flag, 0x40000000);
            flag = ReadIfFlaggedByte(pr, flag, 0x80000000);

            //Flags part 2
            flag = pr.ReadInt();
            flag = ReadIfFlaggedByte(pr, flag, 0x01);
            flag = ReadIfFlaggedByte(pr, flag, 0x02);
            flag = ReadIfFlaggedByte(pr, flag, 0x04);
            flag = ReadIfFlaggedLong(pr, flag, 0x08);
            flag = ReadIfFlaggedInt(pr, flag, 0x10);

            pr.ReadMapleString();
            Potential = (Potential)pr.ReadByte();
            Enhancements = pr.ReadByte();

            pr.Skip(22);

            if (HasUnqID == false)
                pr.Skip(8);

            pr.Skip(50);
            pr.Skip(4);//New v195

            // [Potential (2 * 3)] [Bonus Potential (2 * 3)] [Anvilled item ID + (itemid - (itemid % 10000)) (2)][Socket State (2)] [Nebulite item ID + 3060000 (2 * 3)]
            // [Database Id (8)] [Timestamp (8)] FF FF FF FF [Zero (8)] [Timestamp (8)] [Zero (20)] 00 00



        }

        public long ReadIfFlaggedByte(PacketReader pr, long value, long flag)
        {
            if ((value & flag) == flag)
            {
                pr.Skip(1);
                return value - flag;
            }
            return value;
        }

        public long ReadIfFlaggedShort(PacketReader pr, long value, long flag)
        {
            if ((value & flag) == flag)
            {
                pr.Skip(2);
                return value - flag;
            }
            return value;
        }

        public long ReadIfFlaggedInt(PacketReader pr, long value, long flag)
        {
            if ((value & flag) == flag)
            {
                pr.Skip(4);
                return value - flag;
            }
            return value;
        }

        public long ReadIfFlaggedLong(PacketReader pr, long value, long flag)
        {
            if ((value & flag) == flag)
            {
                pr.Skip(8);
                return value - flag;
            }
            return value;
        }


    }
}
