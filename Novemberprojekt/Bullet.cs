using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    
    public class Bullet
    {
        KeyboardKey initKey;
        public float bulletVelocity;
        public static List<Bullet> bullets = new List<Bullet>();

        Color darkGreen = new Color (48, 98, 48, 255);

        public Rectangle bulletRec;

        public Bullet(float xStart, float yStart, KeyboardKey keyPressed)
    {
      bulletRec = new Rectangle(xStart, yStart, 10, 10);

      bullets.Add(this);

      initKey = keyPressed;

    }

    public void Update(){
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
        
    }

    public static void UpdateAll(){
        foreach (Bullet b in bullets)
            {
                b.Update();
            }
    }

    public void Draw(){
        Raylib.DrawRectangleRec(bulletRec, darkGreen);
    }

    public static void DrawAll(){
        foreach (Bullet b in bullets)
            {
                b.Draw();
            }
    }
        
    }
}
