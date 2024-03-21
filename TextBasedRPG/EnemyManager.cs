using System;
using System.Collections.Generic;

namespace TextBasedRPG
{
    internal class EnemyManager
    {
        public List<Enemy> Enemies { get { return enemies; } }

        private List<Enemy> enemies;
        private Player player;
        private Map map;
        private ItemManager itemManager;
        public NormalEnemy normalEnemy;
        public ScaredEnemy scaredEnemy;
        public RandomEnemy randomEnemy;

        public EnemyManager(Player player, Map map, ItemManager itemManager)
        {
            this.player = player;
            this.map = map;
            this.itemManager = itemManager;
            enemies = new List<Enemy>();
        }

        public void SpawnNormalEnemies(int startNumber)
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
                enemies.Add(new NormalEnemy(player, map, itemManager, spawnX, spawnY));
            }
        }

        public void SpawnScaredEnemies(int startNumber)
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
                enemies.Add(new ScaredEnemy(player, map, itemManager, spawnX, spawnY));
            }
        }

        public void SpawnRandomEnemies(int startNumber)
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
                enemies.Add(new RandomEnemy(player, map, itemManager, spawnX, spawnY));
            }
        }

        public void UpdateEnemies(ConsoleKeyInfo input)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.SimpleAI(input);
            }
            enemies.RemoveAll(enemy => enemy.IsDefeated());
        }

        public void DrawEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }
        }
    }
}