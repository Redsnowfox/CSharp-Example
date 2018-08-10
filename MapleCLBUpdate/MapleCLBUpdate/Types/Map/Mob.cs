using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal class Mob : MapObject
    {
        public int Crc { get; internal set; }
        public int MobId { get; internal set; }
        public Boolean waitForAck = false;

        internal Mob(int id) : base(id) { }

        public void Move(Position position)
        {
            Position = position;
        }
        //internal Mob(int id) : base(id) { }
    }

    //internal static class Mob
    // {



    //internal static Mob ReadMob(this PacketReader pr) {
    //    pr.ReadByte();
    //    var m = new Mob(pr.ReadInt());
    //    pr.ReadBool();
    //    int monsterID = pr.ReadInt(); // [MonsterId (4)]
    //    if (!pr.ReadBool() && monsterID != 9010017){
    //        pr.Skip(4 + 16 + 151); // [?? (4)] [?? (16)] [MobStatus (151)]
    //        m.Position = pr.ReadPosition();
    //        // [Stance (1)] [Fh (2)] [InitFh (2)] [Animation -1=instant,-2=fade (2)] FF 7D 
    //        // [Zero (24)] [FF FF FF FF] 00 [Zero (8)] [FF FF FF FF] [00 00 00 00]
    //    }
    //    else //throw new NotImplementedException("Read Monster cannot handle: " + pr); //t.h.e.m.a.p.leblc@gmail.com
    //        m = null;

    //    return m;
    //}
    //}
}
