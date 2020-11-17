using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    
    public class Bullet
    {

        public static List<Bullet> bullets = new List<Bullet>();

        Color darkGreen = new Color (48, 98, 48, 255);

        public Rectangle bulletRec;

        public Bullet(float xStart, float yStart)
    {
      bulletRec = new Rectangle(xStart, yStart, 10, 10);

      bullets.Add(this);

    }

    public void Update(){
        bulletRec.y -= 6f;
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
