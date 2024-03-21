using System;

namespace TextBasedRPG
{
    internal class NormalEnemy : Enemy
    {
        private Player player;

        public NormalEnemy(Player player, Map map, int x, int y) : base(map, player)
        {
            avatar = '$';
            blank = ' ';
            this.player = player;
            healthSystem = new HealthSystem(2);
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
