﻿using System;

namespace TextBasedRPG
{
    internal abstract class Enemy : Entity
    {
        protected char avatar;
        protected char blank;

        public Enemy(Map map)
        {
            Item.map = map;
        }

        public abstract void SimpleAI(ConsoleKeyInfo input);

        public abstract bool IsDefeated();

        public virtual void Draw()
        {
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(IsDefeated() ? blank : avatar);
        }
    }
}