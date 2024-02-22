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
        Player player;
        public string map1 = @"map.txt";
        public string map2 = @"map2.txt";
        public string map3 = @"map3.txt";
        string[] MapRows;
        public char[,] map;
        internal string currentMapPath;

        public Map(Player player)
        {
            this.player = player;
            LoadMap(map1);
        }

        public string CurrentMapPath
        {
            get { return currentMapPath; }
        }

        public void ChangeMap(string newMapPath)
        {
            LoadMap(newMapPath);
        }

        public void LoadMap(string mapPath)
        {
            Console.Clear();
            MapRows = File.ReadAllLines(mapPath);
            int width = MapRows[0].Length;
            int height = MapRows.Length;
            map = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = MapRows[y][x];
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
            currentMapPath = mapPath;
        }
    }
}


