using System;

namespace TextBasedRPG
{
    internal class Player : Entity
    {
        private static char avatar = Settings.PlayerAvatar;
        private static char blank = ' ';
        private NormalEnemy normalEnemy;
        private ScaredEnemy scaredEnemy;
        private RandomEnemy randomEnemy;
        private ItemManager itemManager;
        private EnemyManager enemyManager;
        public Sword equippedSword;
        public Shield equippedShield;
        private HealingPotion healingPotion;
        private HUD hud;
        public bool swordEquipped = false;
        public bool shieldEquipped = false;

        public Player(EnemyManager enemyManager, ItemManager itemManager, Map map, HUD hud)
        {
            this.hud = hud;
            this.itemManager = itemManager;
            this.enemyManager = enemyManager;
            healthSystem = new HealthSystem(Settings.PlayerInitialHealth);
            coord2D = new Coord2D();
            coord2D.y = Settings.PlayerInitialY;
            coord2D.x = Settings.PlayerInitialX;
        }


        public void SetHUD(HUD hud)
        {
            this.hud = hud;
        }
        public void SetPickups(ItemManager itemManager, HealingPotion healingPotion, Shield shield, Sword sword)
        {
            this.equippedShield = shield;
            this.healingPotion = healingPotion;
            this.equippedSword = sword;
            this.itemManager = itemManager;
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

            if (map.map[newX, newY] != '#')
            {
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

                if (!collidedWithEnemy)
                {
                    coord2D.x = newX;
                    coord2D.y = newY;
                }

                foreach (Item item in itemManager.Items)
                {
                    if (newX == item.coord2D.x && newY == item.coord2D.y)
                    {
                        if (item is Sword)
                        {
                            item.PickUp(this, itemManager);
                            break;
                        }
                        else if (item is Shield)
                        {
                            shieldEquipped = true;
                            item.PickUp(this, itemManager);
                            break;
                        }
                        else if (item is HealingPotion)
                        {
                            item.PickUp(this, itemManager);
                            
                            break;
                        }
                    }
                }

                if (healthSystem.health <= 0)
                {
                    GameManager.gameOver = true;
                }

                Draw();
            }
        }


        public void Draw()
        {
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
        }
    }
}
