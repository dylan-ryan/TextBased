using System;

namespace TextBasedRPG
{
    internal abstract class Item : GameObject
    {
        protected char avatar;
        protected char blank;

        public Item(Map map)
        {
            Item.map = map;
        }

        public abstract void Update(ConsoleKeyInfo input);

        public abstract bool IsDeleted();

        public virtual void Draw()
        {
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(IsDeleted() ? blank : avatar);
        }
    }
}
