using System;
using System.Collections.Generic;

namespace TextBasedRPG
{
    internal class ItemManager
    {
        public List<Item> Items { get { return items; } }

        private List<Item> items;
        private Player player;
        private Map map;
        private EnemyManager enemyManager;
        public HealingPotion healingPotion;
        public Shield shield;
        public Sword sword;
        public ItemManager(Player player, Map map, EnemyManager enemyManager)
        {
            this.player = player;
            this.map = map;
            this.enemyManager = enemyManager;
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
                items.Add(new Sword(player, map, spawnX, spawnY));
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
                items.Add(new Shield(player, map, spawnX, spawnY));
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
                items.Add(new HealingPotion(player, map, spawnX, spawnY));

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
        public void PickUp(Item item)
        {
            item.PickUp(player, this);
            if (item is HealingPotion)
            {
                items.Remove(item);
            }
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
