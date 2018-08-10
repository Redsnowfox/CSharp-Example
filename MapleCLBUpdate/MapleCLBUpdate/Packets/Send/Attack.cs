using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types.Map;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send
{
    internal static class Attack
    {
        //Level 10 Kanna skill -> Use until 100 
        internal static byte[] KannaSkill(Client c, Mob mob)
        {
            Random r = new Random();
            var pw = new PacketWriter(SendOps.KANNA_ATTACK);
            pw.WriteByte(c.Account.info.PortalCount);
            if (mob != null)
            {
                pw.WriteByte(18);//Unknown
                pw.WriteInt(42001000);//Skill ID
                pw.WriteByte(20);//SkillLVL
                pw.WriteInt(-539844870);//SKill CRC
                pw.WriteZero(16);
                pw.WriteInt(-1621752198);//Unknown
                pw.WriteInt(101751550);//Unknown
                pw.Timestamp();
                pw.WriteZero(4);
                pw.WriteInt(mob.Id);
                pw.WriteByte(7);//Unknown
                                //pw.WriteZero(4);//Changes sometimes..
                pw.WriteShort(0);
                pw.WriteShort(0);

                pw.WriteInt(mob.MobId);
                pw.WriteByte(1);
                pw.WriteShort(mob.Position.X);
                pw.WriteShort(mob.Position.Y);
                pw.WriteShort(mob.Position.X);
                pw.WriteShort(mob.Position.Y);

                pw.WriteShort(-19356);//Unknown
                pw.WriteZero(9);

                pw.WriteLong(110);//Damage
                pw.WriteLong(135);//Damage

                pw.WriteZero(4);

                pw.Timestamp();//Mob CRC but fuck it yolo

                pw.WriteBool(false);
                pw.WriteBool(true);

                pw.WriteShort(mob.Position.X);
                pw.WriteShort(mob.Position.Y);

                pw.WriteShort(mob.Position.X);
                pw.WriteShort(mob.Position.Y);

                pw.WriteShort(mob.Position.X);
                pw.WriteShort(mob.Position.Y);

                pw.WriteShort(mob.Position.X);
                pw.WriteShort(mob.Position.Y);

                pw.WriteBool(false);
            }
            else
            {
                pw.WriteByte(2);//Unknown
                pw.WriteInt(42001000);//Skill ID
                pw.WriteByte(20);//SkillLVL
                pw.WriteInt(-539844870);//SKill CRC
                pw.WriteZero(16);
                pw.WriteInt(-1621752198);//Unknown
                pw.WriteInt(101751550);//Unknown
                pw.Timestamp();
                pw.WriteInt(0);
                pw.WriteInt(-122945391);//X/Y but yolo :D
                pw.WriteByte(0);
            }

            return pw.ToArray();
        }

        //Level 100 Charm 1 Mob Skill Kanna
        internal static byte[] CharmAttack(Client c, Mob mob)
        {
            var pw = new PacketWriter(SendOps.KANNA_ATTACK);
            pw.WriteByte(c.Account.info.PortalCount);
            pw.WriteByte(19);
            pw.WriteInt(42121000);
            pw.WriteByte(30);
            pw.WriteInt(-2111132484);
            pw.WriteZero(20);
            pw.WriteInt(1873118838);//Unknown
            pw.WriteInt(101766041);//Unknown
            pw.Timestamp();
            pw.WriteZero(4);
            pw.WriteInt(mob.Id);
            pw.WriteByte(7);//Unknown
            pw.WriteShort(0);
            pw.WriteShort(0);
            pw.WriteInt(mob.MobId);
            pw.WriteByte(1);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);
            pw.WriteShort(25700);//Unknown
            pw.WriteZero(9);
            pw.WriteLong(39260);//Damage
            pw.WriteLong(36804);//Damage
            pw.WriteLong(24905);//Damage
            pw.WriteZero(4);
            pw.Timestamp();
            pw.WriteBool(false);
            pw.WriteBool(true);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteBool(false);

            return pw.ToArray();
        }

        internal static byte[] BallHur(Client c, Mob mob)
        {
            var pw = new PacketWriter(SendOps.STRIKE_ATTACK);
            pw.WriteByte(c.Account.info.PortalCount);
            pw.WriteByte(17);
            pw.WriteInt(37121003);//Skill
            pw.WriteByte(10);//Skill Level
            pw.WriteByte(0);
            pw.WriteInt(-1792535077);//Skill CRC
            pw.WriteZero(20);
            pw.WriteInt(-1621752491);//Unknown
            pw.WriteInt(84450046);//Unknown
            pw.Timestamp();
            //pw.WriteInt(128109334);//Unknown
            pw.WriteZero(8);
            pw.WriteInt(mob.Id);
            pw.WriteByte(7);
            pw.WriteShort(0);
            pw.WriteShort(135);//Unknown
            pw.WriteInt(mob.MobId);
            pw.WriteByte(1);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);
            //120 here??
            pw.WriteShort(120);
            pw.WriteZero(8);
            pw.WriteLong(41050);
            pw.WriteZero(4);
            pw.Timestamp();

            pw.WriteBool(false);
            pw.WriteBool(true);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);

            return pw.ToArray();
        }


            internal static byte[] MonkeyStrike(Client c, Mob mob, int attackCount)
        {
            var pw = new PacketWriter(SendOps.STRIKE_ATTACK);
            pw.WriteByte(c.Account.info.PortalCount);
            pw.WriteByte(19);//Unknown
            pw.WriteInt(42120003);//Skill ID
            pw.WriteByte(3);//Skill Level
            pw.WriteByte(0);
            pw.WriteInt(-387161429);//Skill CRC
            pw.WriteZero(14);
            pw.WriteInt(attackCount);//Not zero..?
            pw.WriteShort(0);
            pw.WriteShort(18);
            pw.WriteInt(1836870926);//Unknown
            pw.WriteShort(1040);
            pw.WriteInt(823337379);//Changes but not sure!
            pw.WriteZero(8);
            pw.WriteInt(mob.Id);
            pw.WriteByte(7);
            pw.WriteShort(0);//Changes sometimes
            pw.WriteShort(135);//Unknown
            pw.WriteInt(mob.MobId);
            pw.WriteByte(1);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);
            pw.WriteShort(mob.Position.X);
            pw.WriteShort(mob.Position.Y);
            pw.WriteZero(10);
            pw.WriteLong(5295);//Damage
            pw.WriteLong(6321);//Damage
            pw.WriteLong(2733);//Damage
            pw.WriteZero(4);
            pw.Timestamp();

            pw.WriteBool(false);
            pw.WriteBool(true);

            pw.WriteShort((short)(mob.Position.X + 200));
            pw.WriteShort((short)(mob.Position.Y + 20));

            pw.WriteShort((short)(mob.Position.X - 200));
            pw.WriteShort((short)(mob.Position.Y + 20));

            pw.WriteShort((short)(mob.Position.X + 200));
            pw.WriteShort((short)(mob.Position.Y + 20));

            pw.WriteShort(mob.Position.X);
            //pw.WriteShort(1268);
            pw.WriteShort(mob.Position.Y);
            //pw.WriteShort(-415);

            return pw.ToArray();
        }

    }
}
