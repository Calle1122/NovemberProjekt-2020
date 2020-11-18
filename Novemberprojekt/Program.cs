using System;
using System.Collections.Generic;
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

            Rectangle playerCollider = myPlayer.playerRec; 

            Wall gameWalls = new Wall();        

            UI gameUI = new UI();    

            Spawner mobSpawners = new Spawner();

            while (!Raylib.WindowShouldClose())
            {
            myPlayer.Update();
            Bullet.UpdateAll();

            KeyboardKey keyPressed = myPlayer.lastKeyPressed;

            Raylib.BeginDrawing();
      
            Raylib.ClearBackground(lightestGreen);
            
            mobSpawners.Draw();
            gameUI.DrawUI();
            myPlayer.Draw();
            Bullet.DrawAll();
            gameWalls.Draw();
            

            if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Bullet newBullet = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
            }

            //Följande kodblock fungerar inte!
            foreach (Rectangle r in Wall.wallList){
                bool areOverlapping = Raylib.CheckCollisionRecs(playerCollider, r);

                if (areOverlapping == true){
                    Raylib.DrawText("Colliding: " + areOverlapping, 500, 0, 50, darkestGreen);
                }
            }

            

            Raylib.EndDrawing();

            }

        }
    }
}
