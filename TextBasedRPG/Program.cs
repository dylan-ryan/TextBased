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
        static GameManager gameManager = new GameManager();
        static void Main(string[] args)
        {
            gameManager.Play();
        }
    }
}
