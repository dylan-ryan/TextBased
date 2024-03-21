using System;

namespace TextBasedRPG
{
    internal class GameManager
    {
        static public bool gameOver = false;
        static public bool gameWin = false;
        private static ConsoleKeyInfo input;
        public static Player player;
        public static Enemy enemy;
        public static EnemyManager enemyManager;
        public static ItemManager itemManager;
        public static Map map = new Map(player);
        HUD hud;

        public static void Input()
        {
            input = Console.ReadKey(true);
        }

        public void Play()
        {
            //map = new Map(player);
            player = new Player(enemyManager, map);
            enemyManager = new EnemyManager(player, map);
            itemManager = new ItemManager(player, map);
            int width = map.MapRows[0].Length;
            int height = map.MapRows.Length;
            RandomEnemy randomEnemy = new RandomEnemy(player, map, height, width);
            ScaredEnemy scaredEnemy = new ScaredEnemy(player, map, height, width);
            NormalEnemy normalEnemy = new NormalEnemy(player, map, height, width);
            Sword sword = new Sword(map, height, width);
            Shield shield = new Shield(map, height, width);
            HealingPotion healingPotion = new HealingPotion(map, height, width);
            hud = new HUD(player, normalEnemy, scaredEnemy, randomEnemy, shield, map, healingPotion, sword);
            player.SetEnemy(enemyManager, normalEnemy, scaredEnemy, randomEnemy);
            player.SetPickups(itemManager, healingPotion, shield, sword);

            bool scaredEnemiesSpawned = false;
            bool randomEnemiesSpawned = false;
            bool normalEnemiesSpawned = false;
            bool swordSpawned = false;
            bool shieldSpawned = false;
            bool healingSpawned = false;

            while (!gameOver)
            {
                Input();
                player.MoveTo(input);
                enemyManager.UpdateEnemies(input);
                itemManager.UpdateItems(input);

                enemyManager.DrawEnemies();
                itemManager.DrawItems();


                hud.Display();

     

                if (!scaredEnemiesSpawned)
                {
                    enemyManager.SpawnScaredEnemies(1);
                    scaredEnemiesSpawned = true;
                }
                if (!randomEnemiesSpawned)
                {
                    enemyManager.SpawnRandomEnemies(25);
                    randomEnemiesSpawned = true;
                }
                if (!normalEnemiesSpawned)
                {
                    enemyManager.SpawnNormalEnemies(1);
                    normalEnemiesSpawned = true;
                }

                if (!swordSpawned)
                {
                    itemManager.SpawnSword(1);
                    swordSpawned = true;
                }
                if (!shieldSpawned)
                {
                    itemManager.SpawnShield(1);
                    shieldSpawned = true;
                }
                if (!healingSpawned)
                {
                    itemManager.SpawnHealthPotion(25);
                    healingSpawned = true;
                }
            }

            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}