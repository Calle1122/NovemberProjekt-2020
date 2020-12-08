﻿using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    class Program
    {

        enum GameScreens {
        Title,
        Game,
        End
        }

        static void Main(string[] args)
        {
            float startTime = 0;
            float maxStartTime = 6;

            float currentTime = 0;
            float maxTime = 6;

            Color lightestGreen = new Color(155, 188, 15, 255);
            Color lightGreen = new Color(139, 172, 15, 255);
            Color darkGreen = new Color(48, 98, 48, 255);
            Color darkestGreen = new Color(15, 56, 15, 255);

            Raylib.InitWindow(1000, 800, "Slime Shooter");
            Raylib.SetTargetFPS(60);


            Player myPlayer = new Player(500, 400, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_D, KeyboardKey.KEY_A);

            Rectangle playerCollider = myPlayer.playerRec;

            Wall gameWalls = new Wall();

            UI gameUI = new UI();

            Spawner mobSpawners = new Spawner();

            Enemy activeEnemies = new Enemy(gameUI);

            GameScreens screen = GameScreens.Title;

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();

                //TITLE SCREEN:


                if(screen == GameScreens.Title){

                    Rectangle flashingRec = new Rectangle(360, 420, 250, 10);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        screen = GameScreens.Game;
                    }

                    Raylib.ClearBackground(lightGreen);
                    Raylib.DrawText("Press ENTER to start", 115, 350, 70, darkestGreen);


                    startTime += Raylib.GetFrameTime();

                    if (startTime > maxStartTime)
                    {
                        startTime = 0;
                    }

                    if(startTime < 3 && startTime > 2){
                        Raylib.DrawRectangleRec(flashingRec, darkestGreen);
                    }

                    if(startTime < 6 && startTime > 5){
                        Raylib.DrawRectangleRec(flashingRec, darkestGreen);
                    }

                }

                

                //GAME SCREEN:


                if(screen == GameScreens.Game){
                        currentTime += Raylib.GetFrameTime();
                    if (currentTime > maxTime)
                    {
                        currentTime = 0;

                        Enemy newEnemy = new Enemy(gameUI);

                        maxTime -= 0.25f;

                        if(maxTime < 0.5){
                            maxTime = 0.5f;
                        }
                    }

                    int spawner = mobSpawners.SpawnerId();

                    activeEnemies.SpawnEnemy(spawner);

                    myPlayer.Update();
                    Bullet.UpdateAll();
                    Enemy.UpdateAll(myPlayer.playerRec.x, myPlayer.playerRec.y);

                    KeyboardKey keyPressed = myPlayer.lastKeyPressed;

                    

                    Raylib.ClearBackground(lightestGreen);

                    mobSpawners.Draw();
                    gameUI.DrawUI();
                    myPlayer.Draw();
                    Bullet.DrawAll();
                    Enemy.DrawAll();
                    gameWalls.Draw();

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_G))
                    {
                        Enemy newEnemy = new Enemy(gameUI);
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        Bullet newBullet = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                    }
                }


                //END GAME SCREEN:


                if(screen == GameScreens.End){

                }


                Raylib.EndDrawing();

            }

        }
    }
}
