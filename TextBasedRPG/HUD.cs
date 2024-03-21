using System;

namespace TextBasedRPG
{
    internal class HUD
    {
        private Player player;
        private ItemManager itemManager;
        private Map map;
        private Item item;
        private Shield shield;
        private Sword sword;
        private HealingPotion healingPotion;

        public HUD()
        {
        }

        public void Display(Player player, ItemManager itemManager, Map map,Shield shield, Sword sword, HealingPotion healingPotion)
        {
            this.player = player;
            this.itemManager = itemManager;
            this.map = map;
            this.shield = shield;
            this.sword = sword;
            this.healingPotion = healingPotion;

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("                                                                                  ");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("                                                                                  ");
            Console.SetCursorPosition(0, 26);
            Console.WriteLine($"Health: {player.healthSystem.health}");

            foreach (Item item in itemManager.Items)
            {
                if (player.coord2D.x == item.coord2D.x && player.coord2D.y == item.coord2D.y)
                {
                    Console.SetCursorPosition(0, 25);

                    if (item is Sword)
                    {
                        Console.WriteLine("                                                                              ");
                        Console.WriteLine($"You picked up a sword! Damage +{Settings.SwordDamageBonus}");
                    }
                    else if (item is Shield)
                    {
                        Console.WriteLine("                                                                              ");
                        Console.WriteLine($"You picked up a shield! Enemy damage {Settings.ShieldBonus}");
                    }
                    else if (item is HealingPotion)
                    {
                        Console.WriteLine("                                                                              ");
                        Console.WriteLine($"You picked up a potion! Health +{Settings.HealingPotionHealAmount}");
                    }
                    break;
                }
            }
        }

    }
}