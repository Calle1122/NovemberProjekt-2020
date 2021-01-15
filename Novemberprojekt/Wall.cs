using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Wall
    {
        //Skapar massa variabler:
        Color lightGreen = new Color(139, 172, 15, 255); //Ljusgrön färg

        static public Rectangle leftRec = new Rectangle(0, 150, 50, 850); //Vänster vägg sprite
        static public Rectangle rightRec = new Rectangle(950, 150, 50, 850); //Höger vägg sprite
        static public Rectangle upperRec = new Rectangle(0, 150, 1000, 50); //Uppe vägg sprite
        static public Rectangle lowerRec = new Rectangle(0, 750, 1000, 50); //Nere vägg sprite
        
        //Lista med alla 4 wall-sprites
        public static List<Rectangle> wallList = new List<Rectangle>() {leftRec, rightRec, upperRec, lowerRec}; 

        //Draw() - metoden
        public void Draw(){
            //Ritar ut alla 4 väggar
            Raylib.DrawRectangleRec(leftRec, lightGreen);
            Raylib.DrawRectangleRec(rightRec, lightGreen);
            Raylib.DrawRectangleRec(upperRec, lightGreen);
            Raylib.DrawRectangleRec(lowerRec, lightGreen);
        }
    }
}
