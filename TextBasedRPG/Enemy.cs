using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Enemy : Entity
    {

        public Enemy()
        {
            coord2D = new Coord2D();
            healthSystem = new HealthSystem(100);

            coord2D.x = 10;
            coord2D.y = 10;
        }
    }
}
