using System;

namespace TextBasedRPG
{
    internal abstract class Item : GameObject
    {
        protected char avatar;
        protected char blank;
        private Player player;

        public Item(Map map, Player player)
        {
            Item.map = map;
            this.player = player;
        }

        public abstract void PickUp(Player player, ItemManager itemManager);

        public abstract void Update(ConsoleKeyInfo input);

        public abstract bool IsDeleted();

        public abstract void Draw();

    }
}
