using System;

namespace TextBasedRPG
{
    internal class ScaredEnemy : Enemy
    {
        private Player player;
        private ItemManager itemManager;

        public ScaredEnemy(Player player, Map map, ItemManager itemManager, int x, int y) : base(map, player)
        {
            avatar = Settings.ScaredEnemyAvatar;
            blank = ' ';
            this.player = player;
            this.itemManager = itemManager;
            healthSystem = new HealthSystem(Settings.ScaredEnemyInitialHealth);
            coord2D = new Coord2D();
            coord2D.x = x;
            coord2D.y = y;
        }

        public override void SimpleAI(ConsoleKeyInfo input)
        {
            if (healthSystem.health <= 0)
                return;

            int playerX = player.coord2D.x;
            int playerY = player.coord2D.y;

            int totalDamage = 1 + (player.shieldEquipped ? player.equippedShield.ShieldBonus : 0);

            int deltaX = coord2D.x - playerX;
            int deltaY = coord2D.y - playerY;

            int newX = coord2D.x + Math.Sign(deltaX) * 1;
            int newY = coord2D.y + Math.Sign(deltaY) * 1;

            if (ItemExistsAt(newX, newY))
                return;

            if (map.map[newX, newY] != '#' && map.map[newX, newY] != 'L')
            {
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(blank);
                coord2D.x = newX;
                coord2D.y = newY;
            }
        }


        private bool ItemExistsAt(int x, int y)
        {
            foreach (Item item in itemManager.Items)
            {
                if (item.coord2D.x == x && item.coord2D.y == y)
                {
                    return true;
                }
            }
            return false;
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
