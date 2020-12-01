using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    
    public class Bullet
    {
        public bool destroyThis = false;

        KeyboardKey initKey;
        public float bulletVelocity;
        public static List<Bullet> bullets = new List<Bullet>();

        //Skapas eftersom man inte kan göra .Remove(this) av orginella listan i en foreach loop.
        public static List<Bullet> bulletsCopy = new List<Bullet>();

        Color darkGreen = new Color (48, 98, 48, 255);

        public Rectangle bulletRec;

        public Bullet(float xStart, float yStart, KeyboardKey keyPressed)
    {
      bulletRec = new Rectangle(xStart, yStart, 10, 10);

      bullets.Add(this);

      initKey = keyPressed;

    }

    public void Update(){
        bulletsCopy = bullets;

        if (initKey == KeyboardKey.KEY_W){
            bulletRec.y -= 6f;
        }

        else if (initKey == KeyboardKey.KEY_S){
            bulletRec.y += 6f;
        }

        else if (initKey == KeyboardKey.KEY_D){
            bulletRec.x += 6f;
        }

        else if (initKey == KeyboardKey.KEY_A){
            bulletRec.x -= 6f;
        }

        foreach (Enemy e in Enemy.enemies)
        {
            if (Raylib.CheckCollisionRecs(bulletRec, e.enemyRec) && destroyThis == false)
            {
                this.destroyThis = true;
                e.destroyThis = true;
            }
        }

    }

    public static void UpdateAll(){
        foreach (Bullet b in bullets)
            {
                b.Update();
            }

        bullets.RemoveAll(b => b.destroyThis == true);
    }

    public void Draw(){
        Raylib.DrawRectangleRec(bulletRec, darkGreen);
    }

    public static void DrawAll(){
        foreach (Bullet b in bullets)
            {
                if (b.bulletRec.y > 150){
                    b.Draw();
                }  
            }
    }

    public void DestroyBullet(){
        
        bullets.RemoveAll(x => x.destroyThis == true);
        
    }

    public static void DestroyBulletsAll(){
        foreach (Bullet b in bullets){
                        b.DestroyBullet();
                    }

    }
             
    }
}
