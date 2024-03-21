using System;

namespace TextBasedRPG
{
    internal class Shield : Item
    {
        private static char avatar = Settings.ShieldAvatar;
        private Player player;
        private int shieldBonus = Settings.ShieldBonus;
        public bool delete = false;

        public Shield(Player player, Map map, int x, int y) : base(map, player)
        {
            this.player = player;
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
        public int ShieldBonus
        {
            get { return shieldBonus; }
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
            player.shieldEquipped = true;
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
