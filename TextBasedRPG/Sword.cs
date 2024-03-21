using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Sword : Item
    {
        private static char avatar = '/';
        private Player player;
        private int damageBonus = 1;
        public bool delete = false;
        public Sword(Map map, int x, int y) : base(map)
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
        public int DamageBonus
        {
            get { return damageBonus; }
        }
        public void PickUp(Player player)
        {
            if (!delete)
            {
                if (player.coord2D.y == coord2D.y && player.coord2D.x == coord2D.x)
                {
                    delete = true;
                }
            }
        }

        public override bool IsDeleted()
        {
            return delete = true;
        }

        public static char Avatar => avatar;
    }
}