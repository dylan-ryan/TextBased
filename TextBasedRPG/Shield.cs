using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    //Blocks enemy damage-1
    internal class Shield : Item
    {
        private static char avatar = '0';
        private Player player;
        private int shieldBonus = -1;
        public bool delete = false;

        public Shield(Map map, int x, int y) : base(map)
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
        public int ShieldBonus
        {
            get { return shieldBonus; }
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
