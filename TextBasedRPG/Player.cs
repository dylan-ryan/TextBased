using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player
    {
        public int x;
        public int y;
        public HealthSystem healthSystem;
        public Player()
        {
            healthSystem = new HealthSystem(100);
        }
    }
}
