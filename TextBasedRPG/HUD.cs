using System;

namespace TextBasedRPG
{
    internal class HUD
    {
        private Player player;
        private EnemyManager enemyManager;
        private ItemManager itemManager;
        private Map map; // Add Map reference
        private Sword sword; // Add Sword reference
        private HealingPotion healingPotion; // Add HealingPotion reference
        private Shield shield; // Add Shield reference

        public HUD(Player player, ItemManager itemManager, EnemyManager enemyManager, Map map, Sword sword, HealingPotion healingPotion, Shield shield) // Update constructor to receive additional parameters
        {
            this.player = player;
            this.itemManager = itemManager;
            this.enemyManager = enemyManager;
            this.map = map; // Assign Map reference
            this.sword = sword; // Assign Sword reference
            this.healingPotion = healingPotion; // Assign HealingPotion reference
            this.shield = shield; // Assign Shield reference
        }

        public void Display()
        {
            if (map.CurrentMapPath == map.map1)
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("                                                                                  ");
                Console.WriteLine($"Health: {player.healthSystem.health} ");
                if (player.coord2D.y == sword.coord2D.y && player.coord2D.x == sword.coord2D.x)
                {
                    Console.SetCursorPosition(0, 25);
                    Console.WriteLine("                                                                              ");
                    Console.WriteLine("You picked up a sword! Damage +1");
                }
                if (player.coord2D.y == healingPotion.coord2D.y && player.coord2D.x == healingPotion.coord2D.x)
                {
                    Console.SetCursorPosition(0, 25);
                    Console.WriteLine("                                                                              ");
                    Console.WriteLine("You picked up a potion! Health +5");
                }
                if (player.coord2D.y == shield.coord2D.y && player.coord2D.x == shield.coord2D.x)
                {
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("                                                                              ");
                    Console.WriteLine("You picked up a shield! Enemy damage -1");
                }
            }
        }
    }
}
