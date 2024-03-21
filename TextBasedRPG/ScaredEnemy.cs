using System;

namespace TextBasedRPG
{
    internal class ScaredEnemy : Enemy
    {
        private Player player;
        public ScaredEnemy(Player player, Map map, int x, int y) : base(map, player)
        {
            avatar = 'S';
            blank = ' ';
            this.player = player;
            healthSystem = new HealthSystem(2);
            coord2D = new Coord2D();
            coord2D.x = x;
            coord2D.y = y;
        }

        public override void SimpleAI(ConsoleKeyInfo input)
        {
            int playerX = player.coord2D.x;
            int playerY = player.coord2D.y;

            int totalDamage = 1 + (player.shieldEquipped ? player.equippedShield.ShieldBonus : 0);

            int newX = coord2D.x;
            int newY = coord2D.y;
            if (healthSystem.health > 0)
            {
                if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow || input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
                {
                    if (playerY < newY)
                    {
                        newY++;
                        if (newX == playerX && playerY == newY)
                        {
                            newY--;
                            player.healthSystem.TakeDamage(totalDamage);
                        }
                        else if (newX != playerX || playerY != newY)
                        {
                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.y = newY;
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newY--;
                        }
                    }
                    if (playerX < newX)
                    {
                        newX++;
                        if (newX == playerX && playerY == newY)
                        {
                            newX--;
                            player.healthSystem.TakeDamage(totalDamage);
                        }
                        else if (newX != playerX || playerY != newY)
                        {

                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.x = newX;
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newX--;
                        }
                    }
                    if (playerX > newX)
                    {
                        newX--;
                        if (newX == playerX && playerY == newY)
                        {
                            newX++;
                            player.healthSystem.TakeDamage(totalDamage);
                        }
                        else if (newX != playerX || playerY != newY)
                        {
                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.x = newX;
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newX++;
                        }
                    }
                    if (playerY > newY)
                    {
                        newY--;
                        if (newX == playerX && playerY == newY)
                        {
                            newY++;
                            player.healthSystem.TakeDamage(totalDamage);
                        }
                        else if (newX != playerX || playerY != newY)
                        {

                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.y = newY;
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newY++;
                        }
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
