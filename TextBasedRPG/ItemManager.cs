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
        public Shield shield;
        public Sword sword;
        public HealingPotion healingPotion;
        public HUD hud;

        public ItemManager(Player player, Map map, EnemyManager enemyManager, HUD hud)
        {
            this.hud = hud;
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
                while (map.map[spawnX, spawnY] == '#' || map.map[spawnX, spawnY] == 'L' || ItemExistsAt(spawnX, spawnY));

                items.Add(new Sword(player, map, hud, spawnX, spawnY));
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
                while (map.map[spawnX, spawnY] == '#' || map.map[spawnX, spawnY] == 'L' || ItemExistsAt(spawnX, spawnY));

                items.Add(new Shield(player, map, hud, spawnX, spawnY));
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
                while (map.map[spawnX, spawnY] == '#' || map.map[spawnX, spawnY] == 'L' || ItemExistsAt(spawnX, spawnY));

                items.Add(new HealingPotion(player, map, hud, spawnX, spawnY));
            }
        }

        private bool ItemExistsAt(int x, int y)
        {
            foreach (Item item in items)
            {
                if (item.coord2D.x == x && item.coord2D.y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateItems(ConsoleKeyInfo input)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                items[i].Update(input);
                if (items[i].IsDeleted())
                {
                    items.RemoveAt(i);
                }
            }
        }

        public void PickUp(Item item)
        {
            item.PickUp(player, this);
            items.Remove(item);
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
