using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal class Map
    {
        public readonly IDictionary<int, Player> Players;
        public readonly IDictionary<int, Reactor> Reactors;
        public readonly IDictionary<int, Drop> Drops;
        public readonly IDictionary<int, Shop> Shops;
        public readonly IDictionary<int, Mob> Mobs;
        public readonly IDictionary<int, Summon> Summons;
        public readonly IDictionary<int, NonPlayerType> Npcs;
        public readonly IDictionary<int, NonPlayerType> NpcController;
        public readonly IDictionary<int, int> MapOfCont;
        public Rune activeRune;

        internal Map()
        {
            Players = new ConcurrentDictionary<int, Player>();
            Reactors = new ConcurrentDictionary<int, Reactor>();
            Drops = new ConcurrentDictionary<int, Drop>();
            Shops = new ConcurrentDictionary<int, Shop>();
            Mobs = new ConcurrentDictionary<int, Mob>();
            Npcs = new ConcurrentDictionary<int, NonPlayerType>();
            NpcController = new ConcurrentDictionary<int, NonPlayerType>();
            MapOfCont = new ConcurrentDictionary<int, int>();
            Summons = new ConcurrentDictionary<int, Summon>();
            MapCont();
            activeRune = null;
        }

        internal void MapCont()
        {
            MapOfCont[10] = 0;//Hene
            MapOfCont[13] = 8;//Ereve
            MapOfCont[14] = 9;//Rien
            MapOfCont[20] = 10;//Orbis
            MapOfCont[21] = 11;//El Nath
            MapOfCont[22] = 12;//Ludi
            //MapOfCont[22] = 14;//FolkTown Broken..
            MapOfCont[23] = 15;//Aqua
            MapOfCont[24] = 16;//Leafre
            MapOfCont[25] = 17;//MuLung
            //MapOfCont[25] = 18;//HerbTown
            MapOfCont[26] = 19;//Ariant
            //MapOfCont[26] = 20;//Magatia
            MapOfCont[31] = 21;//Eldistien
            //MapOfCont[10] = 22;//Elluel

        }

        internal void Clear()
        {
            Players.Clear();
            Drops.Clear();
            Reactors.Clear();
            Shops.Clear();
            Mobs.Clear();
            Npcs.Clear();
            NpcController.Clear();
            Summons.Clear();
            activeRune = null;
        }

        internal void SpawnSummon(Summon sum)
        {
            Summons[sum.Id] = sum;
        }

        internal void DespawnSummons(int id)
        {
            //Summons.Remove(id);
            Summons.Clear();
        }

        internal void SpawnRune(Rune rune)
        {
            activeRune = rune;
        }
        
        internal void DespawnRune()
        {
            activeRune = null;
        }

        internal void SpawnNpcController(NonPlayerType npc)
        {
            NpcController[npc.NpcId] = npc;
        }

        internal void DespawnNpcController(int id)
        {
            NpcController.Remove(id);
        }

        internal void SpawnNpc(NonPlayerType npc)
        {
            Npcs[npc.NpcId] = npc;
        }

        internal void DespawnNpc(int id)
        {
            Npcs.Remove(id);
        }

        internal void SpawnReactor(Reactor reactor)
        {
            Reactors[reactor.Id] = reactor;
        }

        internal void DespawnReactor(int id)
        {
            Reactors.Remove(id);
        }

        internal void SpawnPlayer(Player player)
        {
            Players[player.Id] = player;
        }

        internal void DespawnPlayer(int id)
        {
            Players.Remove(id);
        }

        internal void SpawnDrop(Drop drop)
        {
            Drops[drop.Id] = drop;
        }

        internal void DespawnDrop(int id)
        {
            Drops.Remove(id);
        }

        internal void SpawnShop(Shop shop)
        {
            Shops[shop.Id] = shop;
        }

        internal void DespawnShop(int id)
        {
            Shops.Remove(id);
        }

        internal void SpawnMob(Mob mob)
        {
            if (mob.MobId == 9999999)
            { // Not real Mob
                return;
            }
            Mobs[mob.Id] = mob;
            //Console.WriteLine("Spawned Mob {0} {1}", mob.Id, mob.Position);
        }

        internal void DespawnMob(int id)
        {
            Mobs.Remove(id);
            //Console.WriteLine("Despawned Mob {0}", id);
        }
    }
}

