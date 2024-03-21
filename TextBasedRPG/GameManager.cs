using System;

namespace TextBasedRPG
{
    internal class GameManager
    {
        public static bool gameOver = false;
        public static bool gameWin = false;
        private static ConsoleKeyInfo input;
        public static Player player;
        public static EnemyManager enemyManager;
        public static ItemManager itemManager;
        public static HealingPotion healingPotion;
        public static Map map;
        private HUD hud;

        public GameManager()
        {
            map = new Map(player);
            player = new Player(enemyManager, itemManager, map);
        }

        public void Input()
        {
            input = Console.ReadKey(true);
        }

        public void Play()
        {
            int width = map.MapRows[0].Length;
            int height = map.MapRows.Length;

            // Initialize item manager and enemy manager
            itemManager = new ItemManager(player, map, enemyManager);
            enemyManager = new EnemyManager(player, map, itemManager);

            // Initialize player

            // Initialize items and enemies
            Sword sword = new Sword(player, map, height, width);
            Shield shield = new Shield(player, map, height, width);
            HealingPotion healingPotion = new HealingPotion(player, map, height, width);
            ScaredEnemy scaredEnemy = new ScaredEnemy(player, map, height, width);
            NormalEnemy normalEnemy = new NormalEnemy(player, map, height, width);
            RandomEnemy randomEnemy = new RandomEnemy(player, map, itemManager, height, width);

            enemyManager.SpawnScaredEnemies(1);
            enemyManager.SpawnRandomEnemies(25);
            enemyManager.SpawnNormalEnemies(1);
            itemManager.SpawnSword(1);
            itemManager.SpawnShield(1);
            itemManager.SpawnHealthPotion(25);

            // Initialize HUD

            // Set player pickups and enemies
            player.SetPickups(itemManager, healingPotion, shield, sword);
            player.SetEnemy(enemyManager, normalEnemy, scaredEnemy, randomEnemy);

            hud = new HUD(player, itemManager, enemyManager, map, sword, healingPotion, shield);

            while (!gameOver)
            {
                Input();

                player.MoveTo(input);
                itemManager.UpdateItems(input);
                enemyManager.UpdateEnemies(input);

                itemManager.DrawItems();
                enemyManager.DrawEnemies();
                player.Draw();

                hud.Display();
            }

            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
