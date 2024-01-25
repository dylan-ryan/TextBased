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
            Enemy enemy = new Enemy();
            Entity entity = new Entity();
            Map map = new Map();
            
            while (gameOver != true)
            {
                entity.Input();
                player.MoveTo();
                enemy.SimpleAI();
                
                Console.SetCursorPosition(0,19);
                Console.WriteLine("Health: " + player.healthSystem.health + " Enemy Health: " + enemy.healthSystem.health);
            }
            while (gameOver != false)
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey(true);
                break;
            }
        }
    }
}
