using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Wall
    {
        Color lightGreen = new Color(139, 172, 15, 255);

        static public Rectangle leftRec = new Rectangle(0, 150, 50, 850);
        static public Rectangle rightRec = new Rectangle(950, 150, 50, 850);
        static public Rectangle upperRec = new Rectangle(0, 150, 1000, 50);
        static public Rectangle lowerRec = new Rectangle(0, 750, 1000, 50);
        
        public static List<Rectangle> wallList = new List<Rectangle>() {leftRec, rightRec, upperRec, lowerRec}; 

        public void Draw(){
            Raylib.DrawRectangleRec(leftRec, lightGreen);
            Raylib.DrawRectangleRec(rightRec, lightGreen);
            Raylib.DrawRectangleRec(upperRec, lightGreen);
            Raylib.DrawRectangleRec(lowerRec, lightGreen);
        }
    }
}
