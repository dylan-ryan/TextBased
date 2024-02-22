using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    //Heals to max
    internal class HealingPotion : GameObject
    {
        private static char avatar = 'H';
        private Player player;
        private int healAmount = 5;
        private bool pickedUp = false;
        bool delete = false;
        public HealingPotion(Map map)
        {
            coord2D.y = 6;
            coord2D.x = 8;
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
        public int HealAmount
        {
            get { return healAmount; }
        }
        public void PickUp(Player player)
        {
            if (!pickedUp && map.CurrentMapPath == map.map2)
            {
                if (player.coord2D.y == coord2D.y && player.coord2D.x == coord2D.x)
                {
                    player.UseHealthPotion();
                    pickedUp = true;
                    delete = true;
                }
            }
            else return;
        }
        public static char Avatar => avatar;
    }
}
