using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemManager
    {
        public List<Item> Items { get { return items; } }

        private List<Item> items;
        private Player player;
        private Map map;

        public ItemManager(Player player, Map map)
        {
            this.player = player;
            this.map = map;
            items = new List<Item>();
        }

        public void SpawnSword(int startNumber)
        {
            Random random = new Random();
            for (int i = 0; i < startNumber; i++)
            {
                int spawnX, spawnY;
                do
                {
                    spawnX = random.Next(map.MapRows[0].Length);
                    spawnY = random.Next(map.MapRows.Length);
                }
                while (map.map[spawnX, spawnY] == '#');
                items.Add(new Sword(map, spawnX, spawnY));
            }
        }

        public void SpawnShield(int startNumber)
        {
            Random random = new Random();
            for (int i = 0; i < startNumber; i++)
            {
                int spawnX, spawnY;
                do
                {
                    spawnX = random.Next(map.MapRows[0].Length);
                    spawnY = random.Next(map.MapRows.Length);
                }
                while (map.map[spawnX, spawnY] == '#');
                items.Add(new Shield(map, spawnX, spawnY));
            }
        }

        public void SpawnHealthPotion(int startNumber)
        {
            Random random = new Random();

            for (int i = 0; i < startNumber; i++)
            {
                int spawnX, spawnY;
                do
                {
                    spawnX = random.Next(map.MapRows[0].Length);
                    spawnY = random.Next(map.MapRows.Length);
                }
                while (map.map[spawnX, spawnY] == '#');
                items.Add(new HealingPotion(map, spawnX, spawnY));
            }
        }

        public void UpdateItems(ConsoleKeyInfo input)
        {
            foreach (Item item in items)
            {
                item.Update(input);
            }
            items.RemoveAll(items => items.IsDeleted());
        }

        public void DrawItems()
        {
            foreach (Item item in items)
            {
                item.Draw();
            }
        }
    }
}
