using System;
using Raylib_cs;

namespace Novemberprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 800, "Slime Shooter");

            Raylib.SetTargetFPS(60); //Sätter fps till 60.

            while (!Raylib.WindowShouldClose())
            {
            Raylib.BeginDrawing();
      
            Raylib.ClearBackground(Color.GREEN);
            
            Raylib.DrawRectangle(100, 100, 30, 60, Color.DARKGREEN);
            
            Raylib.EndDrawing();
            }

        }
    }
}
