using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Bullet
    {
        Color darkGreen = new Color (48, 98, 48, 255);

        public Rectangle bulletRec;

        public Bullet(float xStart, float yStart)
    {
      bulletRec = new Rectangle(xStart, yStart, 10, 10);
         
    }

    public void Update(){
        bulletRec.y -= 6f;
    }

    public void Draw(){
        Raylib.DrawRectangleRec(bulletRec, darkGreen);
    }
        
    }
}
