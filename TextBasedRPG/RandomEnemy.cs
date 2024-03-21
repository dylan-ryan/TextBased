using System;

namespace TextBasedRPG
{
    internal class RandomEnemy : Enemy
    {
        private Player player;
        private bool isSpawned = false;
        private Random random;
        ItemManager itemManager;

        public RandomEnemy(Player player, Map map, ItemManager itemManager, int x, int y) : base(map, player)
        {
            avatar = Settings.RandomEnemyAvatar;
            blank = ' ';
            this.player = player;
            healthSystem = new HealthSystem(Settings.RandomEnemyInitialHealth);
            coord2D = new Coord2D();
            coord2D.x = x;
            coord2D.y = y;
            this.itemManager = itemManager;
            random = new Random();
        }

        public override void SimpleAI(ConsoleKeyInfo input)
        {
            if (healthSystem.health <= 0)
            {
                return;
            }

            isSpawned = true;

            int totalDamage = 1 + (player.shieldEquipped ? player.equippedShield.ShieldBonus : 0);

            if (isSpawned)
            {
                int range = 1;
                int mapWidth = map.map.GetLength(0);
                int mapHeight = map.map.GetLength(1);

                int newX = coord2D.x + random.Next(-range, range + 1);
                int newY = coord2D.y + random.Next(-range, range + 1);

                if (newX >= 0 && newX < mapWidth && newY >= 0 && newY < mapHeight && map.map[newX, newY] != '#' && map.map[newX, newY] != 'L')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(blank);

                    coord2D.x = newX;
                    coord2D.y = newY;

                    if (coord2D.x == player.coord2D.x && coord2D.y == player.coord2D.y)
                    {
                        player.healthSystem.TakeDamage(totalDamage);
                    }
                }
            }
        }

        public override bool IsDefeated()
        {
            return healthSystem.health <= 0;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
        }
    }
}