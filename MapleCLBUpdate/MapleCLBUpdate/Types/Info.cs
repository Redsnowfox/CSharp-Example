using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types
{
    public sealed class Info
    {
        private const int PORTAL_CRC_CONST = -1770422;
        private const int CUTSCENE_CRC_CONST = 929492331;
        private const int HYPER_CRC_CONST = 830623;

        internal long SessionId;

        private int seed;
        internal int Seed
        {
            private get { return seed; }
            set
            {
                seed = value;
                PortalCount = 1;
            }
        }

        private int peopleCount = 0;
        public int PeopleCount
        {
            get { return peopleCount; }
            set
            {
                peopleCount = value;
            }
        }

        private int monsterCount = 0;
        public int MonsterCount
        {
            get { return monsterCount; }
            set
            {
                monsterCount = value;
            }
        }
        internal int GrabNextCh()
        {
            if (Channel == 19)
                return 0;
            else
                return Channel + 1;
        }

        internal void IncrementPortalCount()
        {
            if (++PortalCount == 0)
            {
                PortalCount = 1; // wrap around
            }
        }

        public int UserId { get; internal set; }

        public int killCount = 0;
        public int ccFailedCount = 0;

        public int missCount = 0;

        public byte Channel { get; internal set; }
        public int MapId { get; internal set; }

        public int nFieldHeight { get; internal set; }
        public int nFieldWidth { get; internal set; }

        public int cutSceneCrc => UserId ^ Seed ^ CUTSCENE_CRC_CONST;
        public int PortalCrc => UserId ^ Seed ^ PORTAL_CRC_CONST;
        public int HyperCrc => UserId ^ MapId ^ Seed ^ HYPER_CRC_CONST; // xor with destination MapId

        private byte portalCount = 0;
        internal byte PortalCount
        {
            get { return portalCount; }
            private set
            {
                portalCount = value;
            }
        }

    }
}