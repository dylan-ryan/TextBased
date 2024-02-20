using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class GameManager
    {
         static public bool gameOver = false;
         static public bool gameWin = false;
         private static ConsoleKeyInfo input;
         public static void Input()
         {
            input = Console.ReadKey(true);
         }

        public void Play()
        {
            Player player = new Player();
            ScaredEnemy scaredEnemy = new ScaredEnemy(player);
            RandomEnemy randomEnemy = new RandomEnemy(player);
            Enemy enemy = new Enemy(player);
            player.SetEnemy(enemy,scaredEnemy,randomEnemy);

            while (gameOver != true)
            {
                Input();
                player.MoveTo(input);
                enemy.SimpleAI(input);

                Console.SetCursorPosition(0, 19);
                Console.SetCursorPosition(0, 20);
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
