using System;

namespace TextBasedRPG
{
    internal class Player : Entity
    {
        private static char avatar = '@';
        private static char blank = ' ';
        private NormalEnemy normalEnemy;
        private ScaredEnemy scaredEnemy;
        private RandomEnemy randomEnemy;
        private EnemyManager enemyManager;
        public Sword equippedSword;
        public Shield equippedShield;
        private HealingPotion healingPotion;
        public bool swordEquipped = false;
        public bool shieldEquipped = false;

        public Player(EnemyManager enemyManager, Map map)
        {
            this.enemyManager = enemyManager;
            healthSystem = new HealthSystem(10);
            coord2D = new Coord2D();
            coord2D.y = 10;
            coord2D.x = 10;
        }

        public void UseHealthPotion()
        {
            healthSystem.health += healingPotion.HealAmount;
        }

        public void SetPickups(ItemManager itemManager, HealingPotion healingPotion, Shield shield, Sword sword)
        {
            this.equippedShield = shield;
            this.healingPotion = healingPotion;
            this.equippedSword = sword;
        }

        public void SetEnemy(EnemyManager enemyManager, NormalEnemy normalEnemy, ScaredEnemy scaredEnemy, RandomEnemy randomEnemy)
        {
            this.scaredEnemy = scaredEnemy;
            this.randomEnemy = randomEnemy;
            this.normalEnemy = normalEnemy;
            this.enemyManager = enemyManager;
        }

        public void MoveTo(ConsoleKeyInfo input)
        {
            Console.CursorVisible = false;
            int newX = coord2D.x;
            int newY = coord2D.y;
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(blank);
            int totalDamage = 1 + (swordEquipped ? equippedSword.DamageBonus : 0);

            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
            {
                newY--;
            }
            else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            {
                newX--;
            }
            else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            {
                newY++;
            }
            else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {
                newX++;
            }
            bool collidedWithEnemy = false;

            foreach (Enemy enemy in enemyManager.Enemies)
            {
                if (newX == enemy.coord2D.x && newY == enemy.coord2D.y && enemy.healthSystem.health > 0)
                {
                    enemy.healthSystem.TakeDamage(totalDamage);
                    collidedWithEnemy = true;
                    break;
                }
            }

            if (!collidedWithEnemy && map.map[newX, newY] != '#')
            {
                coord2D.x = newX;
                coord2D.y = newY;

                if (coord2D.x == equippedSword.coord2D.x && coord2D.y == equippedSword.coord2D.y)
                {
                    swordEquipped = true;
                    equippedSword.PickUp(this);
                    equippedSword.delete = true;
                }
                if (coord2D.x == healingPotion.coord2D.x && coord2D.y == healingPotion.coord2D.y)
                {
                    UseHealthPotion();
                    healingPotion.PickUp(this);
                    healingPotion.delete = true;
                }
                if (coord2D.x == equippedShield.coord2D.x && coord2D.y == equippedShield.coord2D.y)
                {
                    shieldEquipped = true;
                    equippedShield.PickUp(this);
                    equippedShield.delete = true;
                }
            }

            if (healthSystem.health <= 0)
            {
                GameManager.gameOver = true;
            }

            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
        }

       
        
    }
}