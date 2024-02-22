using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    //Blocks enemy damage-1
    internal class Shield : GameObject
    {
        private static char avatar = '0';
        private Player player;
        private int shieldBonus = -1;
        private bool pickedUp = false;
        bool delete = false;

        public Shield(Map map)
        {
            coord2D.y = 4;
            coord2D.x = 30;
        }
        public void Update(ConsoleKeyInfo input)
        {
            if (delete == false)
            {
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(avatar);
            }
            if (delete == true)
            {
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(' ');
            }
        }
        public int ShieldBonus
        {
            get { return shieldBonus; }
        }

        public void PickUp(Player player)
        {
            //new Map(player);
            if (!pickedUp && map.CurrentMapPath == map.map3)
            {
                if (player.coord2D.y == coord2D.y && player.coord2D.x == coord2D.x)
                {
                    player.EquipShield();
                    pickedUp = true;
                }
            }

        }
        public static char Avatar => avatar;
    }
}
