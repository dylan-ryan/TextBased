using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Entity : GameObject
    {
        public static ConsoleKeyInfo input;
        public HealthSystem healthSystem;
        public Player player;
        public Enemy enemy;
         public Entity()
        {
        }

        public void Input()
        {
            input = Console.ReadKey(true);
        }
    }
}
