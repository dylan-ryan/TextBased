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
        //Enemy enemy;

        public Player()
        {
            //enemy = new Enemy();
            coord2D = new Coord2D();
            healthSystem = new HealthSystem();
            map = new Map();
            coord2D.x = 10;
            coord2D.y = 10;
            healthSystem.health = 3;
        }

        public void MoveTo()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(coord2D.x, coord2D.y);
            Console.Write(avatar);
            

            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
            {

                //if (map.map[coord2D.x, coord2D.y] != '$')
                //{
                map = new Map();
                coord2D.y = coord2D.y - 1;
                if (map.map[coord2D.x, coord2D.y] != '#')
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
                if (map.map[coord2D.x, coord2D.y] == '#' )
                { 
                    coord2D.y = coord2D.y + 1;
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(avatar);
                }
                //}
            }
            if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            {
               // if (map.map[coord2D.x, coord2D.y] != '$')
                //{
                    map = new Map();
                    coord2D.x = coord2D.x - 1;
                    if (map.map[coord2D.x, coord2D.y] != '#')
                    {
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    if (map.map[coord2D.x, coord2D.y] == '#')
                    {
                        coord2D.x = coord2D.x + 1;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                //}
            }
            if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            {
                //if (true)
                //{
                    map = new Map();
                    coord2D.y = coord2D.y + 1;
                    if (map.map[coord2D.x, coord2D.y] != '#')
                    {
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    if (map.map[coord2D.x, coord2D.y] == '#')
                    {
                        coord2D.y = coord2D.y - 1;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                //}
            }
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {
                //if (map.map[coord2D.x, coord2D.y] != '$')
               // {
                    map = new Map();
                    coord2D.x = coord2D.x + 1;
                    if (map.map[coord2D.x, coord2D.y] != '#')
                    {
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    if (map.map[coord2D.x, coord2D.y] == '#')
                    {
                        coord2D.x = coord2D.x - 1;
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                //}
            }
            if (map.map[coord2D.x, coord2D.y] == 'L')
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
