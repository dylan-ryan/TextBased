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
        private static Player player;
        private static Map map;
         public static void Input()
         {
            input = Console.ReadKey(true);
         }

        public void Play()
        {
            player = new Player();
            map = new Map(player);


            RandomEnemy randomEnemy = new RandomEnemy(player);
            Enemy enemy = new Enemy(player);
            Sword sword = new Sword();
            ScaredEnemy scaredEnemy = new ScaredEnemy(player);
            Shield shield = new Shield();
            HealingPotion healingPotion = new HealingPotion();
            player.SetEnemy(enemy,scaredEnemy,randomEnemy);

            while (!gameOver)
            {
                Input();
                sword.Update(input);
                shield.Update(input);
                healingPotion.Update(input);
                player.MoveTo(input);
                scaredEnemy.SimpleAI(input);
                CheckMapSwitch();



                if (map.CurrentMapPath == map.map2 && !randomEnemy.IsSpawned)
                {
                    randomEnemy.Spawn();
                }

                if (randomEnemy.IsSpawned)
                {
                    randomEnemy.SimpleAI();
                }

                if (map.CurrentMapPath == map.map3)
                {
                    enemy.SimpleAI(input);
                }

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
        public void CheckMapSwitch()
        {
            int map2SwitchX = 62;
            int map2SwitchY = 17;

            int map3SwitchX = 62;
            int map3SwitchY = 1;

            if (map.CurrentMapPath == map.map1 && player.coord2D.x == map2SwitchX && player.coord2D.y == map2SwitchY)
            {
                player.coord2D.x = 1;
                player.coord2D.y = 17;
                map.ChangeMap(map.map2);
            }
            else if (map.CurrentMapPath == map.map2 && player.coord2D.x == map3SwitchX && player.coord2D.y == map3SwitchY)
            {
                player.coord2D.x = 1;
                player.coord2D.y = 1;
                map.ChangeMap(map.map3);
            }
        }
    }
}
