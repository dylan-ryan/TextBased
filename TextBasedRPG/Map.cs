using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // File.*

namespace TextBasedRPG
{
    internal class Map
    {
            string map1 = @"map.txt";
            string[] MapRows;
            public char[,] map;
        public Map()
        {
            MapRows= File.ReadAllLines(map1);
            int width = MapRows[0].Length;
            int height = MapRows.Length;
            map = new char[width, height];

            Console.SetCursorPosition(0,0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("");
                    map[x, y] = MapRows[y][x];
                    Console.Write(map[x, y]); // debug (display the info)
                }
                Console.WriteLine();
            }
           
        }

       
        
        
    }
}
