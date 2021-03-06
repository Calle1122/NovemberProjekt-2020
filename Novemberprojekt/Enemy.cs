using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Enemy
    {
        public bool destroyThis = false;


        public bool DestroyThis
        {
            get
            {
                return destroyThis;
            }
            set
            {
                destroyThis = value;
                if (destroyThis)
                {
                    uI.AddScore();
                }

            }
        }

        Random generator = new Random();

        UI uI;

        int enemyHp;
        float enemySpeed;


        int xValue;
        int yValue;

        public Rectangle enemyRec = new Rectangle(0, 0, 0, 0);

        public static List<Enemy> enemies = new List<Enemy>();

        Color darkestGreen = new Color(15, 56, 15, 255);

        public Enemy(UI theUI)
        {
            this.uI = theUI;

            int enemyType = generator.Next(1, 3);

            if (enemyType == 1)
            {
                enemyHp = 1;
                enemySpeed = 4f;

                int spawnId = generator.Next(1, 5);

                if(spawnId == 1){
                    enemyRec = new Rectangle(110, 260, 20, 20);
                }

                else if(spawnId == 2){
                    enemyRec = new Rectangle(900, 260, 20, 20);
                }

                else if(spawnId == 3){
                    enemyRec = new Rectangle(110, 700, 20, 20);
                }

                else{
                    enemyRec = new Rectangle(900, 700, 20, 20);
                }
            }

            else if (enemyType == 2)
            {
                enemyHp = 3;
                enemySpeed = 2f;

                int spawnId = generator.Next(1, 5);

                if(spawnId == 1){
                    enemyRec = new Rectangle(110, 260, 40, 40);
                }

                else if(spawnId == 2){
                    enemyRec = new Rectangle(900, 260, 40, 40);
                }

                else if(spawnId == 3){
                    enemyRec = new Rectangle(110, 700, 40, 40);
                }

                else{
                    enemyRec = new Rectangle(900, 700, 40, 40);
                }

            }

            enemies.Add(this);
        }

        public void DestroyEnemy(Rectangle bulletCollider)
        {
            enemies.RemoveAll(x => Raylib.CheckCollisionRecs(bulletCollider, enemyRec));
        }

        public static void DestroyEnemyCheckAll(Rectangle bulletCollider)
        {

            foreach (Enemy e in enemies)
            {
                e.DestroyEnemy(bulletCollider);
            }
        }

        public void SpawnEnemy(int SpawnerId)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                if (SpawnerId == 1)
                {
                    xValue = 110;
                    yValue = 260;
                }

                else if (SpawnerId == 2)
                {
                    xValue = 900;
                    yValue = 260;
                }

                else if (SpawnerId == 3)
                {
                    xValue = 110;
                    yValue = 700;
                }

                else
                {
                    xValue = 900;
                    yValue = 700;
                }

                enemyRec.x = xValue;
                enemyRec.y = yValue;



            }
        }

        public void Update(int playerX, int playerY)
        {
            if (playerX > enemyRec.x)
            {
                enemyRec.x += enemySpeed;
            }

            if (playerX < enemyRec.x)
            {
                enemyRec.x -= enemySpeed;
            }

            if (playerY > enemyRec.y)
            {
                enemyRec.y += enemySpeed;
            }

            if (playerY < enemyRec.y)
            {
                enemyRec.y -= enemySpeed;
            }
        }

        public static void UpdateAll(float playerX, float playerY)
        {
            int playerXint = (int)playerX;
            int playerYint = (int)playerY;

            foreach (Enemy e in enemies)
            {
                e.Update(playerXint, playerYint);
            }

            enemies.RemoveAll(e => e.destroyThis == true);

        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(enemyRec, darkestGreen);
        }

        public static void DrawAll()
        {
            foreach (Enemy e in enemies)
            {
                e.Draw();
            }
        }


    }
}
