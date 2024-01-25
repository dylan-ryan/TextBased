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
        
        static char avatar = '@';
                                   
        //static ConsoleKeyInfo input;
        Map qq11 = new Map();

        public Player()
        {
            coord2D = new Coord2D();
            healthSystem = new HealthSystem();
            qq11 = new Map();
            coord2D.x = 10;
            coord2D.y = 10;
            healthSystem.health = 3;
        }

        public void MoveTo()
        {
            
            Console.CursorVisible = false;
            //input = Console.ReadKey(true);
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
            

            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
            {

                //Console.SetCursorPosition(coord2D.x, coord2D.y);
                //Console.Write(blank);
                qq11 = new Map();
                coord2D.y = coord2D.y - 1;
                if (qq11.map[coord2D.x, coord2D.y] != '#')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
                if (qq11.map[coord2D.x, coord2D.y] == '#' )
                { 
                    coord2D.y = coord2D.y + 1;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
            }
            if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            {
                //Console.SetCursorPosition(coord2D.x, coord2D.y);
                //Console.Write(blank);
                qq11 = new Map();
                coord2D.x = coord2D.x - 1;
                if (qq11.map[coord2D.x, coord2D.y] != '#')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
                if (qq11.map[coord2D.x,coord2D.y] == '#')
                {
                    coord2D.x = coord2D.x + 1;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
            }
            if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            {
                //Console.SetCursorPosition(coord2D.x, coord2D.y);
                //Console.Write(blank);
                qq11 = new Map();
                coord2D.y = coord2D.y + 1;
                if (qq11.map[coord2D.x, coord2D.y] != '#')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
                if (qq11.map[coord2D.x, coord2D.y] == '#')
                {
                    coord2D.y = coord2D.y - 1;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
            }
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {
                //Console.SetCursorPosition(coord2D.x, coord2D.y);
                //Console.Write(blank);
                qq11 = new Map();
                coord2D.x = coord2D.x + 1;
                if (qq11.map[coord2D.x, coord2D.y] != '#')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
                if (qq11.map[coord2D.x, coord2D.y] == '#')
                {
                    coord2D.x = coord2D.x - 1;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
            }
            if (qq11.map[coord2D.x, coord2D.y] == 'L')
            {
                healthSystem.TakeDamage(1);
            }
            if(healthSystem.health <= 0)
            {
                Program.gameOver = true;
            }

            
        }
    }
}
