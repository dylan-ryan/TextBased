using System;

namespace TextBasedRPG
{
    internal class HUD
    {
        private Player player;
        private EnemyManager enemyManager;
        private Sword sword;
        private Shield shield;

        public HUD(Player player, EnemyManager enemyManager, Sword sword, Shield shield)
        {
            this.player = player;
            this.enemyManager = enemyManager;
            this.sword = sword;
            this.shield = shield;
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 25);
            Console.Write("Player Health: ");
            if (player.healthSystem.health < 10)
            {
                Console.Write(" ");
            }
            Console.WriteLine(player.healthSystem.health);
            Console.SetCursorPosition(0, 26);
            Console.Write("Enemies Remaining: ");
            if (enemyManager.Enemies.Count < 10)
            {

                Console.Write(" ");
            }
            Console.WriteLine(enemyManager.Enemies.Count);

            if (player.swordEquipped)
            {
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("Sword Collected: Damage +" + sword.DamageBonus);
            }

            if (player.shieldEquipped)
            {
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("Shield Collected: Enemy Damage " + shield.ShieldBonus);
            }

            Console.SetCursorPosition(0, 0);
        }

    }
}
