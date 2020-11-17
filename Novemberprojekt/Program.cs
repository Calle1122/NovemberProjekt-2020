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
            Raylib.SetTargetFPS(60);

            Player myPlayer = new Player(500, 400, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_D, KeyboardKey.KEY_A);

            while (!Raylib.WindowShouldClose())
            {
            myPlayer.Update();

            Raylib.BeginDrawing();
      
            Raylib.ClearBackground(lightestGreen);
            
            Raylib.DrawRectangle(100, 100, 30, 60, lightGreen);
            
            myPlayer.Draw();

            Raylib.EndDrawing();

            }

        }
    }
}
