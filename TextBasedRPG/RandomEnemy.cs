using System;

namespace TextBasedRPG
{
    internal class RandomEnemy : Enemy
    {
        private Player player;
        private bool isSpawned = false;
        private Random random;

        public RandomEnemy(Player player, Map map, int x, int y) : base(map)
        {
            avatar = '%';
            blank = ' ';
            this.player = player;
            healthSystem = new HealthSystem(1);
            coord2D = new Coord2D();
            coord2D.x = x;
            coord2D.y = y;
            random = new Random();
        }

        public override void SimpleAI(ConsoleKeyInfo input)
        {
            isSpawned = true;

            int totalDamage = 1 + (player.shieldEquipped ? player.equippedShield.ShieldBonus : 0);

            if (isSpawned && healthSystem.health > 0)
            {
                int range = 1;
                int mapWidth = map.map.GetLength(0);
                int mapHeight = map.map.GetLength(1);

                int newX = coord2D.x + random.Next(-range, range + 1);
                int newY = coord2D.y + random.Next(-range, range + 1);

                if (newX >= 0 && newX < mapWidth && newY >= 0 && newY < mapHeight && map.map[newX, newY] != '#')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(blank);
                    coord2D.x = newX;
                    coord2D.y = newY;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }

                if (coord2D.x == player.coord2D.x && coord2D.y == player.coord2D.y)
                {
                    player.healthSystem.TakeDamage(totalDamage);
                }
            }
        }

        public override bool IsDefeated()
        {
            return healthSystem.health <= 0;
        }
    }
}