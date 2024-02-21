using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player : Entity
    {
        private static char avatar = '@';
        private static char blank = ' ';
        private Enemy enemy;
        private ScaredEnemy scaredEnemy;
        private RandomEnemy randomEnemy;
        private Sword equippedSword = new Sword();
        public Shield equippedShield = new Shield();
        bool swordEquipped = false;
        public bool shieldEquipped = false;

        public Player()
        {
            map = new Map();
            healthSystem = new HealthSystem(3);
            coord2D = new Coord2D();
            coord2D.y = 10;
            coord2D.x = 10;
        }

        public void EquipSword()
        {
            equippedSword = new Sword();
        }
        public void EquipShield()
        {
            equippedShield = new Shield();
        }

        public void SetEnemy(Enemy enemy, ScaredEnemy scaredEnemy, RandomEnemy randomEnemy)
        {
            this.scaredEnemy = scaredEnemy;
            this.randomEnemy = randomEnemy;
            this.enemy = enemy;
        }
        

        public void MoveTo(ConsoleKeyInfo input)
        {
            Console.CursorVisible = false;
            int enemyX = enemy.coord2D.x;
            int enemyY = enemy.coord2D.y;
            int sEnemyX = scaredEnemy.coord2D.x;
            int sEnemyY = scaredEnemy.coord2D.y;
            int rEnemyX = randomEnemy.coord2D.x;
            int rEnemyY = randomEnemy.coord2D.y;
            int newX = coord2D.x;
            int newY = coord2D.y;
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(blank);
            int totalDamage = 1 + (swordEquipped ? equippedSword.DamageBonus : 0);

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
                        enemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                if (newX == sEnemyX && sEnemyY == newY )
                {

                    if (scaredEnemy.healthSystem.health > 0)
                    {
                        newY++;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                        scaredEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }  
                if (newX == rEnemyX && rEnemyY == newY )
                {

                    if (randomEnemy.healthSystem.health > 0)
                    {
                        newY++;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                        randomEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health > 0 ||
                    newX != sEnemyX || sEnemyY != newY || scaredEnemy.healthSystem.health > 0 ||
                    newX != rEnemyX || rEnemyY != newY || randomEnemy.healthSystem.health > 0)
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
                        enemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                if (newX == sEnemyX && sEnemyY == newY)
                {
                    if (scaredEnemy.healthSystem.health > 0)
                    {
                    newX++;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        scaredEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }  
                if (newX == rEnemyX && rEnemyY == newY)
                {
                    if (randomEnemy.healthSystem.health > 0)
                    {
                    newX++;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        randomEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health > 0 ||
                    newX != sEnemyX || sEnemyY != newY || scaredEnemy.healthSystem.health > 0 ||
                    newX != rEnemyX || rEnemyY != newY || randomEnemy.healthSystem.health > 0)
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
                        enemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                } 
                if (newX == sEnemyX && sEnemyY == newY)
                {
                    if (scaredEnemy.healthSystem.health > 0)
                    {
                    newY--;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        scaredEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                } 
                if (newX == rEnemyX && rEnemyY == newY)
                {
                    if (randomEnemy.healthSystem.health > 0)
                    {
                    newY--;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        randomEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.y = newY;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health > 0 ||
                    newX != sEnemyX || sEnemyY != newY || scaredEnemy.healthSystem.health > 0 ||
                    newX != rEnemyX || rEnemyY != newY || randomEnemy.healthSystem.health > 0)
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
                        newY--;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
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
                        enemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                } 
                if (newX == sEnemyX && sEnemyY == newY)
                {
                    if (scaredEnemy.healthSystem.health > 0)
                    {
                    newX--;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        scaredEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                if (newX == rEnemyX && rEnemyY == newY)
                {
                    if (randomEnemy.healthSystem.health > 0)
                    {
                    newX--;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                        randomEnemy.healthSystem.TakeDamage(totalDamage);
                    }
                    else
                    {
                        coord2D.x = newX;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                }
                else if (newX != enemyX || enemyY != newY || enemy.healthSystem.health > 0 ||
                    newX != sEnemyX || sEnemyY != newY || scaredEnemy.healthSystem.health > 0 ||
                    newX != rEnemyX || rEnemyY != newY || randomEnemy.healthSystem.health > 0)
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
                        newX--;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                
            }
            if (coord2D.x == equippedSword.coord2D.x && coord2D.y == equippedSword.coord2D.y)
            {
                swordEquipped = true;
                equippedSword.PickUp(this);
            }
            if (coord2D.x == equippedShield.coord2D.x && coord2D.y == equippedShield.coord2D.y)
            {
                shieldEquipped = true;
                equippedShield.PickUp(this);
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
