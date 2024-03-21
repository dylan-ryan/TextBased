using System;

namespace TextBasedRPG
{
    internal class HealingPotion : Item
    {
        private static char avatar = 'H';
        private Player player;
        private int healAmount = 5;
        public bool delete = false;
        public HealingPotion(Player player, Map map, int x, int y) : base(map, player)
        {
            coord2D.x = x;
            coord2D.y = y;
        }
        public override void Update(ConsoleKeyInfo input)
        {
            if (!delete)
            {
                int top = Math.Min(coord2D.y, Console.BufferHeight - 1);
                Console.SetCursorPosition(coord2D.x, top);
                Console.Write(avatar);

            }
            else
            {
                int top = Math.Min(coord2D.y, Console.BufferHeight - 1);
                Console.SetCursorPosition(coord2D.x, top);
                Console.Write(' ');
            }
        }
        public int HealAmount
        {
            get { return healAmount; }
        }
        public override void PickUp(Player player, ItemManager itemManager)
        {
            if (!delete)
            {
                if (player.coord2D.y == coord2D.y && player.coord2D.x == coord2D.x)
                {
                    Use(player);
                    delete = true;
                    itemManager.Items.Remove(this);
                }
            }
        }
        public void Use(Player player)
        {
            player.healthSystem.health += healAmount; // Heal the player
        }

        public override bool IsDeleted()
        {
            return delete;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
        }

        public static char Avatar => avatar;
    }
}
