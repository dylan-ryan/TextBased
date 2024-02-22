﻿using System;
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
        private Shield shield;
        private Map map;
        private HealingPotion healingPotion;
        private Sword sword;

        public HUD(Player player, Enemy enemy, ScaredEnemy scaredEnemy, RandomEnemy randomEnemy, Shield shield, Map map, HealingPotion healingPotion, Sword sword)
        {
            this.player = player;
            this.enemy = enemy;
            this.scaredEnemy = scaredEnemy;
            this.randomEnemy = randomEnemy;
            this.shield = shield;
            this.map = map;
            this.healingPotion = healingPotion;
            this.sword = sword;
        }

        public void Display()
        {
            if (map.CurrentMapPath == map.map1)
            {
                Console.SetCursorPosition(0, 19);
                Console.WriteLine("                                                                          ");
                Console.WriteLine($"Health: {player.healthSystem.health} Enemy Health: {scaredEnemy.healthSystem.health}");
                if (player.coord2D.y == sword.coord2D.y && player.coord2D.x == sword.coord2D.x)
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("                                                                          ");
                    Console.WriteLine("You picked up a sword! Damage +1");
                }
            }
            if (map.CurrentMapPath == map.map2)
            {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("                                                                          ");
                    Console.WriteLine($"Health: {player.healthSystem.health} Enemy Health: {randomEnemy.healthSystem.health}");
                if (player.coord2D.y == healingPotion.coord2D.y && player.coord2D.x == healingPotion.coord2D.x)
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("                                                                          ");
                    Console.WriteLine("You picked up a potion! Health +5");
                }
            }
            if (map.CurrentMapPath == map.map3)
            {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("                                                                          ");
                    Console.WriteLine($"Health: {player.healthSystem.health} Enemy Health: {enemy.healthSystem.health}");
                if (player.coord2D.y == shield.coord2D.y && player.coord2D.x == shield.coord2D.x)
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("                                                                          ");
                    Console.WriteLine("You picked up a shield! Enemy damage -1");
                }
            }
            
        }
    }
}