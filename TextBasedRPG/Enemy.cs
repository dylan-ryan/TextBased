using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Enemy : Entity
    {
        static char avatar = '$';
        static char blank = ' ';
        
        //Player player;
        public Enemy()
        {
            player = new Player();
            //player = new Player();
            coord2D = new Coord2D();
            healthSystem = new HealthSystem();
            map = new Map();
            coord2D.x = 25;
            coord2D.y = 8;
            healthSystem.health = 3;
        }

        public void SimpleAI()
        {
            //Console.CursorVisible = false;
            player.MoveTo();

            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            //Console.Write(avatar);

            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow || input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {

                Console.SetCursorPosition(coord2D.x, coord2D.y);
                Console.Write(blank);
                //qq11 = new Map();
                
                if (player.coord2D.y > coord2D.y)
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(blank);
                        coord2D.y = coord2D.y + 1;
                    if (player.coord2D.y != coord2D.y & player.coord2D.x != coord2D.x)
                    {
                        if (map.map[coord2D.x, coord2D.y] == '#')
                        {
                            coord2D.y = coord2D.y - 1;
                        }
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    else  Console.Write(avatar);
                }
                if (player.coord2D.x > coord2D.x)
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(blank);
                        coord2D.x = coord2D.x + 1;
                    if (player.coord2D.x != coord2D.x & player.coord2D.y != coord2D.y)
                    {
                        if (map.map[coord2D.x, coord2D.y] == '#')
                        {
                            coord2D.x = coord2D.x - 1;
                        }
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    else Console.Write(avatar);
                }
                if (player.coord2D.x < coord2D.x)
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(blank);
                        coord2D.x = coord2D.x - 1;
                    if (player.coord2D.x != coord2D.x & player.coord2D.y != coord2D.y)
                    {
                        if (map.map[coord2D.x, coord2D.y] == '#')
                        {
                            coord2D.x = coord2D.x + 1;
                        }
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    else  Console.Write(avatar);
                }
                if (player.coord2D.y < coord2D.y)
                {
                    Console.SetCursorPosition(coord2D.x, coord2D.y);
                    Console.Write(blank);
                        coord2D.y = coord2D.y - 1;
                    if (player.coord2D.y != coord2D.y & player.coord2D.x != coord2D.x)
                    {
                        if (map.map[coord2D.x, coord2D.y] == '#')
                        {
                            coord2D.y = coord2D.y + 1;
                        }
                        Console.SetCursorPosition(coord2D.x, coord2D.y);
                        Console.Write(avatar);
                    }
                    else  Console.Write(avatar);
                }
                
                //Console.SetCursorPosition(coord2D.x, coord2D.y);
                //Console.Write(avatar);
            }
            //if ( || input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            //{
            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            //Console.Write(blank);
            //qq11 = new Map();
            //coord2D.x = coord2D.x - 1;
            //if (qq11.map[coord2D.x, coord2D.y] != '#')
            //{
            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            //Console.Write(avatar);
            // }
            //if (qq11.map[coord2D.x, coord2D.y] == '#')
            //{
            //coord2D.x = coord2D.x + 1;
            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            // Console.Write(avatar);
            // }
            // }
            // if ( ||input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            //{
            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            //Console.Write(blank);
            // qq11 = new Map();
            //  coord2D.y = coord2D.y + 1;
            // if (qq11.map[coord2D.x, coord2D.y] != '#')
            //{
            //  Console.SetCursorPosition(coord2D.x, coord2D.y);
            //Console.Write(avatar);
            // }
            //if (qq11.map[coord2D.x, coord2D.y] == '#')
            //{
            //  coord2D.y = coord2D.y - 1;
            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            // Console.Write(avatar);
            // }
            //  }
            //if ( || input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            //{
            //Console.SetCursorPosition(coord2D.x, coord2D.y);
            //Console.Write(blank);
            // qq11 = new Map();
            //      coord2D.x = coord2D.x + 1;
            //        if (qq11.map[coord2D.x, coord2D.y] != '#')
            //        {
            //           Console.SetCursorPosition(coord2D.x, coord2D.y);
            //           Console.Write(avatar);
            //       }
            //      if (qq11.map[coord2D.x, coord2D.y] == '#')
            //     {
            //         coord2D.x = coord2D.x - 1;
            //        Console.SetCursorPosition(coord2D.x, coord2D.y);
            //        Console.Write(avatar);
            //   }
            //}
            //if (qq11.map[coord2D.x, coord2D.y] == 'L')
            //{
            //healthSystem.TakeDamage(1);
            //}
            //if (healthSystem.health <= 0)
            // {
            // Program.gameOver = true;
            //}
        }
    }
}
