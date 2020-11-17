using System;
using Raylib_cs;

namespace Novemberprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Color lightestGreen = new Color(155, 188, 15, 255);
            Color lightGreen = new Color(139, 172, 15, 255);
            Color darkGreen = new Color (48, 98, 48, 255);
            Color darkestGreen = new Color (15, 56, 15, 255);

            Raylib.InitWindow(1000, 800, "Slime Shooter");

            Raylib.SetTargetFPS(60); //Sätter fps till 60.

            while (!Raylib.WindowShouldClose())
            {
            Raylib.BeginDrawing();
      
            Raylib.ClearBackground(lightGreen);
            
            Raylib.DrawRectangle(100, 100, 30, 60, darkGreen);
            
            Raylib.EndDrawing();
            }

        }
    }
}
