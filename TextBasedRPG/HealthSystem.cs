using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class HealthSystem
    {
        public int health;

        //constructor
        public HealthSystem(int health)
        {
            this.health = health;

        }
        public void TakeDamage(int hp)
        {
            health -= hp;
        }

        public void Heal(int hp)
        {
            health += hp;
        }
    }
}
