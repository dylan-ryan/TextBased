using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player : Entity
    {
        //constructor
        static char[,] map;
        static char avatar = '@';
        static ConsoleKeyInfo input;
        public Player()
        {
            coord2D = new Coord2D();
            healthSystem = new HealthSystem(100);

            coord2D.x = 0;
            coord2D.y = 0;
            
        }

        public void MoveTo()
        {

            input = Console.ReadKey(true);
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);

            if (input.Key == ConsoleKey.W)
            {
                coord2D.y = coord2D.y - 1;
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(avatar);
            }
            if (input.Key == ConsoleKey.A)
            {
                coord2D.x = coord2D.x - 1;
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(avatar);
            }
            if (input.Key == ConsoleKey.S)
            {
                coord2D.y = coord2D.y + 1;
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(avatar);
            }
            if (input.Key == ConsoleKey.D)
            {
                coord2D.x = coord2D.x + 1;
                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(avatar);
            }
        }
    }
}
