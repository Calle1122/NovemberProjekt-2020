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
        int enemyHp;
        float enemySpeed;

        public static List<Enemy> enemies = new List<Enemy>();

        Color darkestGreen = new Color (15, 56, 15, 255);

        public Enemy(int spawnX, int spawnY){
            int enemyType = generator.Next(1,3);

            if(enemyType == 1){
                enemyHp = 1;
                enemySpeed = 6f;

                Rectangle enemyRec = new Rectangle(spawnX, spawnY, 20, 20);
            }

            else {
                enemyHp = 3;
                enemySpeed = 2;

                Rectangle enemyRec = new Rectangle(spawnX, spawnY, 40, 40);
            }
            
            enemies.Add(this);
        }
    }
}
