using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player : Entity
    {
        static char avatar = '@';
        static char blank = ' ';
        private Enemy enemy;
        public Player()
        {
            map = new Map();
            healthSystem = new HealthSystem(3);
            coord2D = new Coord2D();
            coord2D.y = 10;
            coord2D.x = 10;
        }

        public void SetEnemy(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void MoveTo(ConsoleKeyInfo input)
        { 
            //ConsoleKeyInfo input = Console.ReadKey(true);
            Console.CursorVisible = false;

            int enemyX = enemy.coord2D.x;
            int enemyY = enemy.coord2D.y;
            int newX = coord2D.x;
            int newY = coord2D.y;
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(blank);
            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
            {
                newY--;

                if (newX == enemyX && enemyY == newY )
                {

                    if (enemy.healthSystem.health > 0)
                    {
                        newY++;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                        enemy.healthSystem.TakeDamage(1);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }

                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health > 0)
                {

                if (map.map[newX, newY] != '#')
                {
                    coord2D.y = newY;
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
            if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            {
                newX--;
                if (newX == enemyX && enemyY == newY)
                {
                    if (enemy.healthSystem.health > 0)
                    {
                    newX++;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        enemy.healthSystem.TakeDamage(1);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health == 0)
                {
                    if (map.map[newX, newY] != '#')
                    {
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
            if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            {
                newY++;
                if (newX == enemyX && enemyY == newY)
                {
                    if (enemy.healthSystem.health > 0)
                    {
                    newY--;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        enemy.healthSystem.TakeDamage(1);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health == 0)
                {
                    if (map.map[newX, newY] != '#')
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    if (map.map[newX, newY] == '#')
                    {
                        newY--;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
            }
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {
                newX++;
                if (newX == enemyX && enemyY == newY)
                {
                    if (enemy.healthSystem.health > 0)
                    {
                    newX--;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        enemy.healthSystem.TakeDamage(1);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health == 0)
                {
                    if (map.map[newX, newY] != '#')
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    if (map.map[newX, newY] == '#')
                    {
                        newX--;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
            }
            if (map.map[coord2D.x, coord2D.y] == 'L')
            {
                healthSystem.TakeDamage(1);
            }
            if (healthSystem.health <= 0)
            {
                GameManager.gameOver = true;
            }
            
        }
    }
}
