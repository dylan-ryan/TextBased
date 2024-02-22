using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class HUD
    {
        private Player player;
        private Enemy enemy;
        private ScaredEnemy scaredEnemy;
        private RandomEnemy randomEnemy;

        public HUD(Player player, Enemy enemy, ScaredEnemy scaredEnemy, RandomEnemy randomEnemy)
        {
            this.player = player;
            this.enemy = enemy;
            this.scaredEnemy = scaredEnemy;
            this.randomEnemy = randomEnemy;
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 19);
            Console.WriteLine($"Health: {player.healthSystem.health} Enemy Health: {enemy.healthSystem.health} ScaredEnemy Health: {scaredEnemy.healthSystem.health} RandomEnemy Health: {randomEnemy.healthSystem.health} ");
        }
    }
}