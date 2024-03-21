using System;

namespace TextBasedRPG
{
    internal abstract class Enemy : Entity
    {
        protected char avatar;
        protected char blank;
        private Player player;

        public Enemy(Map map, Player player)
        {
            Item.map = map;
            this.player = player;
        }


        public abstract void SimpleAI(ConsoleKeyInfo input);

        public abstract bool IsDefeated();

        public abstract void Draw();

    }
}