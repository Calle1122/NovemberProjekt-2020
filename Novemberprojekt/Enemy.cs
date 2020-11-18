using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Enemy
    {
        Random generator = new Random();
        int Score = 0;
        int HiScore;

        public static List<Enemy> enemies = new List<Enemy>();

        Color darkestGreen = new Color (15, 56, 15, 255);

        public Enemy(){
            int enemyType = generator.Next(1,3);

            if(enemyType == 1){
                //Gör en liten snabb enemy
            }

            else {
                //Gör en stor långsam enemy
            }
            
            enemies.Add(this);
        }
    }
}
