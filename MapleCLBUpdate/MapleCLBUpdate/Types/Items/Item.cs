using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Items
{
    public enum ItemType : byte
    {
        UNKNOWN = 0,
        EQUIP = 1,
        OTHER = 2,
        PET = 3
    }

    public abstract class Item
    {
        public readonly ItemType ItemType;
        public readonly int Id;
        public readonly short Slot;
        public readonly Boolean HasUnqID;

        protected Item(ItemType type, int id, short slot, Boolean hasUnqID)
        {
            ItemType = type;
            Id = id;
            Slot = slot;
            HasUnqID = hasUnqID;
        }

        internal abstract void Parse(PacketReader pr);
    }

    internal static class ItemPacketExtensions
    {
        internal static T Read<T>(this PacketReader pr) where T : Item
        {
            short slot = typeof(T) == typeof(Equip) ? pr.ReadShort() : pr.ReadByte();
            if (slot == 0)
            {
                return (T)Activator.CreateInstance(typeof(T), ItemType.UNKNOWN, 0, slot, false);
            }

            return Read<T>(pr, slot);
        }

        internal static T Read<T>(this PacketReader pr, short slot) where T : Item
        {
            // [Type (1)] [Id (4)] [Flag (1) ? UniqueId (8)] [Timestamp (8)] FF FF FF FF
            var type = (ItemType)pr.ReadByte();
            int id = pr.ReadInt();
            Boolean hasUnqID = pr.ReadBool();
            if (hasUnqID)
            {
                pr.ReadLong();
            }
            pr.Skip(12); // Used to check for expiration?

            var item = (T)Activator.CreateInstance(typeof(T), type, id, slot, hasUnqID);
            item.Parse(pr); // Parses remaining item info, and stores data

            return item;
        }
    }
}
