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
        public static Sword sword;
        public static Shield shield;
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

            itemManager = new ItemManager(player, map, enemyManager);
            enemyManager = new EnemyManager(player, map, itemManager);

            Sword sword = new Sword(player, map, height, width);
            Shield shield = new Shield(player, map, height, width);
            HealingPotion healingPotion = new HealingPotion(player, map, height, width);
            ScaredEnemy scaredEnemy = new ScaredEnemy(player, map, itemManager, height, width);
            NormalEnemy normalEnemy = new NormalEnemy(player, map, itemManager, height, width);
            RandomEnemy randomEnemy = new RandomEnemy(player, map, itemManager, height, width);

            enemyManager.SpawnScaredEnemies(2);
            enemyManager.SpawnRandomEnemies(25);
            enemyManager.SpawnNormalEnemies(2);
            itemManager.SpawnSword(2);
            itemManager.SpawnShield(2);
            itemManager.SpawnHealthPotion(25);

            hud = new HUD();

            player.SetPickups(itemManager, healingPotion, shield, sword);
            player.SetEnemy(enemyManager, normalEnemy, scaredEnemy, randomEnemy);


            while (!gameOver)
            {
                Input();

                player.MoveTo(input);
                itemManager.UpdateItems(input);
                enemyManager.UpdateEnemies(input);

                itemManager.DrawItems();
                enemyManager.DrawEnemies();
                player.Draw();

                hud.Display(player, itemManager, map, shield, sword, healingPotion);

                if (player.healthSystem.health <= 0)
                {
                    gameOver = true;
                    break;
                }

                if (enemyManager.Enemies.Count == 0)
                {
                    gameWin = true;
                    break;
                }
                if (gameOver)
                {
                    break;
                }
            }

            if (gameWin)
            {
                Console.Clear();
                Console.WriteLine("You Win");
            }
            else if (gameOver)
            {
                Console.Clear();
                Console.WriteLine("Game Over");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

    }
}
