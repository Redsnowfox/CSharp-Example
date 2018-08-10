using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types
{
public sealed class Mapler { 
    public int Id { get; set; }
    public string Name { get; set; }
    public byte Level { get; set; }
    public short Job { get; set; }

    public short Str { get; set; }
    public short Dex { get; set; }
    public short Int { get; set; }
    public short Luk { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public int Mp { get; set; }
    public int MaxMp { get; set; }

    public int Ap { get; set; }
    public long Exp { get; set; }
    public int Fame { get; set; }
    public int Map { get; set; }

    public int spawnPoint { get; set; }

    public bool IsAran => Job == 2000 || Job / 100 == 21;
    public bool IsDemon => Job == 3001 || Job / 100 == 31;
    public bool IsXenon => Job == 3002 || Job / 100 == 36;
    public bool IsZero => Job == 10000 || Job / 100 == 101;
    public bool IsBeastTamer => Job == 11000 || Job / 100 == 112;

    public void Print()
    {
        Console.WriteLine("Id: {0}, Name: {1}, Job: {2}, Level: {3}", Id, Name, Job, Level);
        Console.WriteLine("Str[{0}] Dex[{1}] Int[{2}] Luk[{3}], {4} / {5} Hp, {6} / {7} Mp",
            Str, Dex, Int, Luk, Hp, MaxHp, Mp, MaxMp);
        Console.WriteLine("Ap: {0}, Exp: {1}, Fame: {2}, Map: {3}", Ap, Exp, Fame, Map);
    }
}

internal static class MaplerPacketExtensions
{
    internal static Mapler ReadMapler(this PacketReader pr)
    {
        var m = new Mapler();
        // [uid (4)] [uid (4)] [02 00 00 00] [Name (13)]
        m.Id = pr.ReadInt();
        pr.Skip(8);
        m.Name = pr.ReadString(13).TrimEnd('\0');
        // [Gender (1)] [Skin (1)] [Face (4)] [Hair (4)] [FF 00 00] [Level (1)] [Job (2)]
        pr.Skip(13);
        m.Level = pr.ReadByte();
        m.Job = pr.ReadShort();
        // [str (2)] [dex (2)] [int (2)] [luk (2)] [hp (4)] [maxhp (4)] [mp (4)] [maxmp (4)] [Unused AP (2)]
        m.Str = pr.ReadShort();
        m.Dex = pr.ReadShort();
        m.Int = pr.ReadShort();
        m.Luk = pr.ReadShort();

        m.Hp = pr.ReadInt();
        m.MaxHp = pr.ReadInt();
        m.Mp = pr.ReadInt();
        m.MaxMp = pr.ReadInt();

        m.Ap = pr.ReadShort();

        /* Separated SP [Segments (1)] */
        if (!m.IsBeastTamer)
        {
            for (int j = pr.ReadByte(); j > 0; j--)
            {
                pr.Skip(5); // [Job Level (1)] [Unused SP (4)]
            }
        }

        // [Exp (8)] [Fame (4)] [WeaponPoints (4)] [GachExp (4)] [MapId (4)]
        m.Exp = pr.ReadLong();
        m.Fame = pr.ReadInt();
        pr.Skip(8);
        m.Map = pr.ReadInt();
        m.spawnPoint = pr.ReadByte();
        pr.Skip(6); // [SpawnPoint (1)] 00 00 00 00 [SubJob (2)] [(Demon, Xenon, Beast Tamer) ? FaceMark (4)]
        if (m.IsDemon || m.IsXenon || m.IsBeastTamer){
            pr.Skip(4);
        }

            /* [Fatigue (2)] [Date (4)] 
             * [Ambition (4)] [Insight (4)] [Willpower (4)] [Dilligence (4)] [Empathy (4)] [Charm (4)]
             * [Zeros (13)] [00 40 E0 FD] [3B 37 4F 01]
             * [nPvPExp (4)] [nPvPGrade (1)] [nPvpPoint (4)][nPvpModeLevel (1)] [nPvpModeType (1)] [nEventPoint (4)]
             * part time job - Resting = 1, Herbalism = 2, Mining = 3, General Store = 4, Weapon/Armor Store = 5
             * [3B 37 4F 01] [00 40 E0 FD] [00 00 00 00] [00]
             * Character Cards 9 bytes each
             * [Last Login (8)] 00
             */
            //pr.Skip(6 + 24 + 21 + 15 + 1 + 13 + 81 + 9);
            pr.Skip(6 + 24 + 21 + 15 + 81 + 8 + 37);

            return m;
    }

    internal static void SkipAppearance(this PacketReader pr, short job)
    {
        var m = new Mapler { Job = job };
        pr.SkipAppearance(m);
    }

    internal static void SkipAppearance(this PacketReader pr, Mapler m)
    {
        pr.Skip(15); // [Gender (1)] [Skin (1)] [Face (4)] [Job (2)] [SubJob (2)] [Mega (1)] [Hair (4)]

        for (int j = 0; j < 3; ++j)
        { // Skips the Equipment
            pr.Next(0xFF);
        }

        pr.Skip(4); // [00 00 00 00]

        pr.Skip(21); // [Weapon (4)] [Shield (4)] [Mercedes Ears (1)] [Zeros (12)]
        if (m.IsDemon || m.IsXenon)
        { // Demon/Xenon
            pr.Skip(4); // [FaceMark (4)]
        }
        else if (m.IsBeastTamer)
        { // Beast Tamer
            pr.Skip(14); // [FaceMark (4)] [Ears (1)] [EarType (4)] [Tail (1)] [TailType (4)]
        }
        pr.Skip(3); // ?? ?? ?? need 45 ALWAYS
    }
}
}
