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
        bool delete = false;
        public Sword()
        {
            coord2D.y = 6;
            coord2D.x = 10;

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
            if (player.coord2D.y == coord2D.y && player.coord2D.x == coord2D.x)
            {
                player.EquipSword();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("You picked up a sword! Damage +1");
                delete = true;
            }
        }

        public static char Avatar => avatar;
    }
}