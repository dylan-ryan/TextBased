using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ScaredEnemy : Entity
    {
        static char avatar = 'S';
        static char blank = ' ';
        private Player player;
        public ScaredEnemy(Player player)
        {
            this.player = player;
            map = new Map();
            healthSystem = new HealthSystem(2);
            coord2D = new Coord2D();
            coord2D.x = 25;
            coord2D.y = 8;
        }

        public void SimpleAI(ConsoleKeyInfo input)
        {

            //ConsoleKeyInfo input = Console.ReadKey(true);

            int playerX = player.coord2D.x;
            int playerY = player.coord2D.y;
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
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);
                            player.healthSystem.TakeDamage(1);
                        }
                        else if (newX != playerX || playerY != newY)
                        {
                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.y = newY;
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(avatar);
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newY--;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);
                        }
                    }
                    if (playerX < newX)
                    {
                        newX++;
                        if (newX == playerX && playerY == newY)
                        {
                            newX--;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);

                            player.healthSystem.TakeDamage(1);
                        }
                        else if (newX != playerX || playerY != newY)
                        {

                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.x = newX;
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(avatar);
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newX--;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);
                        }
                    }
                    if (playerX > newX)
                    {
                        newX--;
                        if (newX == playerX && playerY == newY)
                        {
                            newX++;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);

                            player.healthSystem.TakeDamage(1);
                        }
                        else if (newX != playerX || playerY != newY)
                        {
                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.x = newX;
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(avatar);
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newX++;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);
                        }
                    }
                    if (playerY > newY)
                    {
                        newY--;
                        if (newX == playerX && playerY == newY)
                        {
                            newY++;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);

                            player.healthSystem.TakeDamage(1);
                        }
                        else if (newX != playerX || playerY != newY)
                        {

                            if (map.map[newX, newY] != '#')
                            {
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(blank);
                                coord2D.y = newY;
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.SetCursorPosition(coord2D.x, coord2D.y);
                                Console.Write(avatar);
                            }
                        }
                        if (map.map[newX, newY] == '#')
                        {
                            newY++;
                            Console.SetCursorPosition(coord2D.x, coord2D.y);
                            Console.Write(avatar);
                        }
                    }
                }
            }
        }
    }
}
