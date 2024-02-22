using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class RandomEnemy : Entity
    {
        static char avatar = '%';
        static char blank = ' ';
        private Player player;
        private bool isSpawned = false;

        public bool IsSpawned
        {
            get { return isSpawned; }
        }

        public RandomEnemy(Player player)
        {
            this.player = player;
            map = new Map(player);
            healthSystem = new HealthSystem(5);
            coord2D = new Coord2D();
            coord2D.x = 59;
            coord2D.y = 10;
        }

        public void Spawn()
        {
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
            isSpawned = true;
        }

        public void SimpleAI()
        {
            if (isSpawned && healthSystem.health > 0)
            {
                int[] directions = { -1, 0, 1, 0, 0, -1, 0, 1 };
                int randomIndex = new Random().Next(0, directions.Length / 2) * 2;

                int newX = coord2D.x + directions[randomIndex];
                int newY = coord2D.y + directions[randomIndex + 1];

                if (newX != player.coord2D.x || newY != player.coord2D.y)
                {
                    if (map.map[newX, newY] != '#')
                    {
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(blank);
                        coord2D.x = newX;
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                if (newX == player.coord2D.x && newY == player.coord2D.y)
                {
                    player.healthSystem.TakeDamage(1);
                }
            }
        }
    }
}
