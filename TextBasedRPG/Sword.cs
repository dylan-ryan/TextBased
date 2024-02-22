using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Sword : GameObject
    {
        private static char avatar = '/';
        private Player player;
        private int damageBonus = 1;
        private bool pickedUp = false;
        bool delete = false;
        public Sword(Map map)
        {
            coord2D.y = 3;
            coord2D.x = 6;
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
        public int DamageBonus
        {
            get { return damageBonus; }
        }
        public void PickUp(Player player)
        {
            if (!pickedUp && map.CurrentMapPath == map.map1)
            {
                if (player.coord2D.y == coord2D.y && player.coord2D.x == coord2D.x)
                {
                    player.EquipSword();
                    delete = true;
                    pickedUp = true;
                }
            }
        }
        public static char Avatar => avatar;
    }
}