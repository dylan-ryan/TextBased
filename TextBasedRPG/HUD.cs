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
            Console.WriteLine("Player Health: " + player.healthSystem.health);
            Console.WriteLine("Enemies Remaining: " + enemyManager.Enemies.Count);

            if (player.swordEquipped)
            {
                Console.WriteLine("Sword Collected: Damage +" + sword.DamageBonus);
            }

            if (player.shieldEquipped)
            {
                Console.WriteLine("Shield Collected: Damage " + shield.ShieldBonus);
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}
