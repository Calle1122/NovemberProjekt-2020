using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Wall
    {
        Color lightGreen = new Color(139, 172, 15, 255);

        public void Draw(){
            Raylib.DrawRectangle(0, 150, 50, 850, lightGreen);
            Raylib.DrawRectangle(950, 150, 50, 850, lightGreen);
            Raylib.DrawRectangle(0, 150, 1000, 50, lightGreen);
            Raylib.DrawRectangle(0, 750, 1000, 50, lightGreen);
        }
    }
}
