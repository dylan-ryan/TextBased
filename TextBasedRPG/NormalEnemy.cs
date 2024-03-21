using System;

namespace TextBasedRPG
{
    internal class NormalEnemy : Enemy
    {
        private Player player;
        private ItemManager itemManager;

        public NormalEnemy(Player player, Map map, ItemManager itemManager, int x, int y) : base(map, player)
        {
            avatar = Settings.NormalEnemyAvatar;
            blank = ' ';
            this.player = player;
            this.itemManager = itemManager;
            healthSystem = new HealthSystem(Settings.NormalEnemyInitialHealth);
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

            int deltaX = Math.Sign(playerX - coord2D.x);
            int deltaY = Math.Sign(playerY - coord2D.y);

            int newX = coord2D.x + deltaX;
            int newY = coord2D.y + deltaY;

            if (map.map[newX, newY] != '#' && (newX != playerX || newY != playerY))
            {
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(blank);
                coord2D.x = newX;
                coord2D.y = newY;
            }
            else
            {
                if (Math.Abs(playerX - coord2D.x) + Math.Abs(playerY - coord2D.y) == 1)
                    player.healthSystem.TakeDamage(totalDamage);
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