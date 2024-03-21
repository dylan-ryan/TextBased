using System;

namespace TextBasedRPG
{
    internal class GameManager
    {
        public static bool gameOver = false;
        public static bool gameWin = false;
        private static ConsoleKeyInfo input;
        private HUD hud;
        public static Player player;
        public static EnemyManager enemyManager;
        public static ItemManager itemManager;
        public static HealingPotion healingPotion;
        public static Sword sword;
        public static Shield shield;
        public static Map map;
        private Item item;

        public GameManager()
        {
            map = new Map(player); // Now it's safe to initialize the Map
            player = new Player(enemyManager, itemManager, map, hud); // Pass HUD to Player constructor
        }

        public void Input()
        {
            input = Console.ReadKey(true);
        }

        public void Play()
        {
            int width = map.MapRows[0].Length;
            int height = map.MapRows.Length;

            // Initialize ItemManager after HUD
            itemManager = new ItemManager(player, map, enemyManager, hud);
            enemyManager = new EnemyManager(player, map, itemManager);

            Sword sword = new Sword(player, map, hud, height, width); // Pass HUD to Sword constructor
            Shield shield = new Shield(player, map, hud, height, width); // Pass HUD to Shield constructor
            HealingPotion healingPotion = new HealingPotion(player, map, hud, height, width); // Pass HUD to HealingPotion constructor
            ScaredEnemy scaredEnemy = new ScaredEnemy(player, map, itemManager, height, width);
            NormalEnemy normalEnemy = new NormalEnemy(player, map, itemManager, height, width);
            RandomEnemy randomEnemy = new RandomEnemy(player, map, itemManager, height, width);


            enemyManager.SpawnScaredEnemies(2);
            enemyManager.SpawnRandomEnemies(25);
            enemyManager.SpawnNormalEnemies(2);
            itemManager.SpawnSword(1);
            itemManager.SpawnShield(1);
            itemManager.SpawnHealthPotion(25);


            player.SetPickups(itemManager, healingPotion, shield, sword);
            player.SetEnemy(enemyManager, normalEnemy, scaredEnemy, randomEnemy);
            
            hud = new HUD(player,enemyManager,sword,shield); // Initialize HUD first


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
