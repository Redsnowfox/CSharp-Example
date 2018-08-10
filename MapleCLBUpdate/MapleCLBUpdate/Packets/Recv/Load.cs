using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types;
using MapleCLBUpdate.Types.Items;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv
{
    internal static class Load{
        public static void CharInfo(Client c, PacketReader r){
            r.Skip(18); // [02 00 01 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00]
            c.Account.info.Channel = (byte)(r.ReadInt() + 1); //CH Connected To
            r.Skip(1 + 4 + 1 + 4 + 1);
            c.Account.info.nFieldWidth = r.ReadInt();
            c.Account.info.nFieldHeight = r.ReadInt();
            switch (r.ReadByte())
            { // Loading Mode: 0 = Change Map, 1 = Login, 2 = Reload Map
                case 0:
                    //c.Info.IncrementPortalCount();
                    goto case 2;
                case 1:
                    /* [00 00] [Damage Seed 1 (4)] [Damage Seed 2 (4)] [Damage Seed 3 (4)]
                    * [FF FF FF FF FF FF FF FF] [00 FX FF FF FF FX FF FF FF FX FF FF FF]
                    * [00 00 00 00 00 00 00] */
                    r.Skip(14 + 21 + 7);
                    /* Character Stats */
                    c.Mapler = r.ReadMapler();

                    /* Char Info */
                    r.Skip(1); // BL Size
                    if (r.ReadBool()){ // Skips Fairy Blessing
                        r.ReadMapleString();
                    }if (r.ReadBool()){ // Skips Emress Blessing
                        r.ReadMapleString();
                    }if (r.ReadBool()){ // Skips Ultimate Explorer's Parent
                        r.ReadMapleString();
                    }
                    //c.Map.Clear();
                    c.Inventory = r.ReadInventory();
                    //Parse skills here next

                    //c.UpdateMesos.Report(c.Inventory.Mesos);
                    break;
                case 2:
                    r.Skip(3);
                    c.Mapler.Map = r.ReadInt();
                    //Need to update all information here
                    break;
                default:
                    throw new InvalidOperationException("Invalid CHAR_INFO loading mode");
            }
            //Console.WriteLine(c.Inventory.Mesos);
            //Console.WriteLine(c.Inventory.EquippedInventory.Count);
            //Console.WriteLine(c.Inventory.EquipInventory.Count);
            //Console.WriteLine(c.Inventory.UseInventory.Count);
            c.UpdateMapler.Report(c.Mapler);
            c.UpdateInfo.Report(c.Account.info);
        }

        public static void Seed(Client c, PacketReader r){
            c.Account.info.Seed = r.ReadInt();
        }

    }
}
