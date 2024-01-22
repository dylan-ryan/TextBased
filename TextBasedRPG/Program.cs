using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // File.*

namespace TextBasedRPG
{
    internal class Program
    {
        static public bool gameOver = false;
        
        static void Main(string[] args)
        {
            Player player = new Player();
           // Map map = new Map();
            while (gameOver != true)
            {
                player.MoveTo();
            }
        }
    }
}
