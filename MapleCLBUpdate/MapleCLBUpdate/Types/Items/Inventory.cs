using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Items
{
    public enum InventoryTab : byte
    {
        EQUIP = 1,
        USE = 2,
        SETUP = 3,
        ETC = 4,
        CASH = 5
    }

    public sealed class Inventory
    {
        public long Mesos { get; set; }
        public readonly Dictionary<short, Equip> EquippedInventory;
        public readonly Dictionary<short, Equip> EquipInventory;
        public readonly Dictionary<short, Other> UseInventory;
        public readonly Dictionary<short, Other> SetupInventory;
        public readonly Dictionary<short, Other> EtcInventory;
        public readonly Dictionary<short, Other> CashInventory;

        public Inventory()
        {
            EquippedInventory = new Dictionary<short, Equip>();
            EquipInventory = new Dictionary<short, Equip>();
            UseInventory = new Dictionary<short, Other>();
            SetupInventory = new Dictionary<short, Other>();
            EtcInventory = new Dictionary<short, Other>();
            CashInventory = new Dictionary<short, Other>();
        }

        public void Clear()
        {
            EquippedInventory.Clear();
            EquipInventory.Clear();
            UseInventory.Clear();
            SetupInventory.Clear();
            EtcInventory.Clear();
            CashInventory.Clear();
        }

        public void Add(InventoryTab tab, Item item)
        {
            switch (tab)
            {
                case InventoryTab.EQUIP:
                    var equip = item as Equip;
                    if (equip != null)
                    {
                        EquipInventory[item.Slot] = equip;
                    }
                    return;
                default:
                    var other = item as Other;
                    if (other != null)
                    {
                        GetInventory(tab)[item.Slot] = other;
                    }
                    break;
            }
        }

        public short Search(InventoryTab tab, int ItemID)
        {
            switch (tab)
            {
                case InventoryTab.EQUIP:
                    foreach (short key in EquipInventory.Keys)
                    {
                        if (EquipInventory[key].Id == ItemID)
                            return EquipInventory[key].Slot;
                    }
                    return -1;
                case InventoryTab.USE:
                    foreach (short key in UseInventory.Keys)
                    {
                        if (UseInventory[key].Id == ItemID)
                            return UseInventory[key].Slot;
                    }
                    return -1;
                case InventoryTab.ETC:
                    foreach (short key in EtcInventory.Keys)
                    {
                        if (EtcInventory[key].Id == ItemID)
                            return EtcInventory[key].Slot;
                    }
                    return -1;
                case InventoryTab.SETUP:
                    foreach (short key in SetupInventory.Keys)
                    {
                        if (SetupInventory[key].Id == ItemID)
                            return SetupInventory[key].Slot;
                    }
                    return -1;
                case InventoryTab.CASH:
                    foreach (short key in CashInventory.Keys)
                    {
                        if (CashInventory[key].Id == ItemID)
                            return CashInventory[key].Slot;
                    }
                    return -1;
                default:
                    return -1;
            }
        }

        public void Update(InventoryTab tab, short slot, short quantity)
        {
            switch (tab)
            {
                case InventoryTab.EQUIP:
                    if (quantity == 0)
                    {
                        EquipInventory.Remove(slot);
                    }
                    break;
                default:
                    Dictionary<short, Other> inventory = GetInventory(tab);
                    if (quantity == 0)
                    {
                        inventory.Remove(slot);
                    }
                    else
                    {
                        if (inventory.ContainsKey(slot))
                        {
                            inventory[slot].Quantity = quantity;
                        }
                    }
                    break;
            }
        }

        public void Move(InventoryTab tab, short src, short dst)
        {
            switch (tab)
            {
                case InventoryTab.EQUIP:
                    if (EquipInventory.ContainsKey(src) && EquipInventory.ContainsKey(dst))
                    {
                        var equip = EquipInventory[src];
                        EquipInventory[src] = EquipInventory[dst];
                        EquipInventory[dst] = equip;
                    }
                    break;
                default:
                    Dictionary<short, Other> inventory = GetInventory(tab);
                    if (inventory.ContainsKey(src) && inventory.ContainsKey(dst))
                    {
                        var other = inventory[src];
                        inventory[src] = inventory[dst];
                        inventory[dst] = other;
                    }
                    break;
            }
        }

        // Helper method to simplify code, this doesnt handle Equip inventory
        private Dictionary<short, Other> GetInventory(InventoryTab tab)
        {
            switch (tab)
            {
                case InventoryTab.USE:
                    return UseInventory;
                case InventoryTab.SETUP:
                    return SetupInventory;
                case InventoryTab.ETC:
                    return EtcInventory;
                case InventoryTab.CASH:
                    return CashInventory;
                default:
                    throw new ArgumentException($"{tab} is not a supported InventoryTab");
            }
        }
    }

    internal static class InventoryPacketExtensions
    {
        internal static Inventory ReadInventory(this PacketReader pr)
        {
            var i = new Inventory();

            /* Inventory Info */
            i.Mesos = pr.ReadLong();            
            //If you read true here chances are inventory parsing will fail..!
            if (pr.ReadBool())
                pr.Skip(63);
            else
                pr.Skip(7);//47 + 5 + 9
        
            pr.Skip(5 + 8 + 1);

            //TODO : Equipped Inventory 
            /* Equipped Items */
            Equip equippedItem;
            while ((equippedItem = pr.Read<Equip>()).Slot != 0)
            {
                i.EquippedInventory[equippedItem.Slot] = equippedItem;
            }
            /* Equipped CS Items */
            while ((equippedItem = pr.Read<Equip>()).Slot != 0)
            {
                i.EquippedInventory[equippedItem.Slot] = equippedItem;
            }

            /* Equip Inventory */
            Equip equipItem;
            while ((equipItem = pr.Read<Equip>()).Slot != 0)
            {
                i.EquipInventory[equipItem.Slot] = equipItem;
            }

            Equip unknownEquip;
            while ((unknownEquip = pr.Read<Equip>()).Slot != 0)
            {
                i.EquipInventory[unknownEquip.Slot] = unknownEquip;
            }

            Equip dragonEquip;
            while ((dragonEquip = pr.Read<Equip>()).Slot != 0)
            {
                i.EquipInventory[dragonEquip.Slot] = dragonEquip;
            }

            //Mechanic Equipment.. will fail if mechanic!
            pr.Skip(2);

            //Some sort of Android items but not all?
            pr.Skip(2);

            //Unknown Equip Items..
            pr.Skip(8);

            Equip totemEquips;
            while ((totemEquips = pr.Read<Equip>()).Slot != 0)
            {
                i.EquipInventory[totemEquips.Slot] = totemEquips;
            }

            //More Equips
            pr.Skip(2 + 2);

            //Android related...
            int count = pr.ReadShort();
            if(count != 0)
            {
                Console.WriteLine("Failed to parse full inventory due to android..!");
                return i;
            }
            for (int k = 0; k < count; k++)
                pr.Skip(35);
            //More Unknown Equips
            pr.Skip(2 + 2 + 2);


            /* Use Inventory */
            Other otherItem;
            while ((otherItem = pr.Read<Other>()).Slot != 0)
            {
                i.UseInventory[otherItem.Slot] = otherItem;
            }
            /* Set-up Inventory */
            while ((otherItem = pr.Read<Other>()).Slot != 0)
            {
                i.SetupInventory[otherItem.Slot] = otherItem;
            }
            /* Etc Inventory */
            while ((otherItem = pr.Read<Other>()).Slot != 0)
            {
                i.EtcInventory[otherItem.Slot] = otherItem;
            }
            /* Cash Inventory */
            while ((otherItem = pr.Read<Other>()).Slot != 0)
            {
                i.CashInventory[otherItem.Slot] = otherItem;
            }

            //Extended slots?
            pr.Skip(17 + 4);

            return i;
        }
    }
}
