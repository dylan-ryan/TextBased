using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ScaredEnemy : Entity
    {
        static char avatar = '&';
        static char blank = ' ';
        private Player player;
        public ScaredEnemy(Player player)
        {
            this.player = player;
            map = new Map();
            healthSystem = new HealthSystem(2);
            coord2D = new Coord2D();
            coord2D.x = 25;
            coord2D.y = 8;
        }
    }
}
