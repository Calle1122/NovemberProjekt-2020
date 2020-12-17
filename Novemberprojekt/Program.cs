using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    class Program
    {

        enum GameScreens {
        Title,
        Help,
        Settings, 
        CustomPlayer,
        Game,
        End
        }

        

        static void Main(string[] args)
        {
            bool endGame = false;

            int shaderCount = 0;
            int hatCount = 0;

            float startTime = 0;
            float maxStartTime = 6;

            float currentTime = 0;
            float maxTime = 6;

            float superTime = 0;
            float superMaxTime = 10;

            Color lightestGreen = new Color(155, 188, 15, 255);
            Color lightGreen = new Color(139, 172, 15, 255);
            Color darkGreen = new Color(48, 98, 48, 255);
            Color darkestGreen = new Color(15, 56, 15, 255);

            Color silentNight = new Color(65, 46, 100, 150);
            Color pinkParty = new Color(255, 0, 221, 150);
            Color redHills = new Color(255, 85, 0, 150);
            Color waterBubbles = new Color(0, 255, 191, 150);
            Color greeeeen = new Color(0, 255, 26, 150);

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

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_C))
                    {
                        screen = GameScreens.CustomPlayer;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_H))
                    {
                        screen = GameScreens.Help;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_H))
                    {
                        screen = GameScreens.Help;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                    {
                        screen = GameScreens.Settings;
                    }

                    Raylib.ClearBackground(lightGreen);
                    Raylib.DrawText("Press ENTER to start", 115, 350, 70, darkestGreen);

                    Raylib.DrawText("Press 'H' for Help", 315, 600, 40, darkestGreen);
                    Raylib.DrawText("Press 'S' for Settings", 280, 670, 40, darkestGreen);
                    Raylib.DrawText("Press 'C' for Customization", 220, 735, 40, darkestGreen);

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



                //SETTINGS SCREEN:

                if (screen == GameScreens.Settings){
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        screen = GameScreens.Title;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        shaderCount++;

                        if(shaderCount > 5){
                            shaderCount = 0;
                        }  
                    }

                    Raylib.ClearBackground(lightestGreen);
                    Raylib.DrawText("SETTINGS", 295, 150, 70, darkGreen);

                    Raylib.DrawRectangle(295, 230, 390, 15, darkGreen);

                    Raylib.DrawText("Toggle shaders with ENTER key", 250, 300, 30, darkGreen);

                    Raylib.DrawText("<               >", 180, 400, 100, darkGreen);

                    if(shaderCount == 0){
                        Raylib.DrawText("NORMAL", 330, 400, 90, darkGreen);
                    }

                    if(shaderCount == 1){
                        Raylib.DrawText("SILENT NIGHT", 250, 410, 70, darkGreen);
                    }

                    if(shaderCount == 2){
                        Raylib.DrawText("PINK PARTY", 280, 410, 70, darkGreen);
                    }

                    if(shaderCount == 3){
                        Raylib.DrawText("RED HILLS", 300, 410, 80, darkGreen);
                    }

                    if(shaderCount == 4){
                        Raylib.DrawText("WATER BUBBLES", 250, 420, 60, darkGreen);
                    }

                    if(shaderCount == 5){
                        Raylib.DrawText("GREEEEEN", 260, 400, 90, darkGreen);
                    }

                    Raylib.DrawText("Press 'B' to go Back", 200, 700, 60, darkestGreen);

                }


                
                //CUSTOM PLAYER SCREEN:

                if(screen == GameScreens.CustomPlayer){
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        screen = GameScreens.Title;
                    }
                    
                    Raylib.ClearBackground(lightestGreen);

                    Raylib.DrawText("HATS", 380, 75, 80, darkGreen);
                    Raylib.DrawRectangle(345, 150, 300, 15, darkGreen);

                    Raylib.DrawText("Press ENTER to toggle between Hats", 210, 190, 30, darkestGreen);

                    Raylib.DrawRectangle(630, 300, 15, 350, darkestGreen);
                    Raylib.DrawRectangle(900, 300, 15, 350, darkestGreen);
                    Raylib.DrawRectangle(630, 300, 270, 15, darkestGreen);
                    Raylib.DrawRectangle(630, 635, 270, 15, darkestGreen);

                    Raylib.DrawRectangle(750, 450, 50, 100, darkGreen);

                    Raylib.DrawText("<          >", 80, 430, 100, darkestGreen);

                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)){

                        hatCount = hatCount + 1;

                        if(hatCount > 2){
                            hatCount = 0;
                        }
                    }

                    if(hatCount == 0){
                        Raylib.DrawText("No Hat", 180, 440, 80, darkestGreen);
                    }

                    if(hatCount == 1){
                        Raylib.DrawText("Top Hat", 150, 440, 80, darkestGreen);

                        Raylib.DrawRectangle(740, 435, 70, 15, darkGreen);
                        Raylib.DrawRectangle(750, 400, 50, 50, darkGreen);
                    }

                    if(hatCount == 2){
                        Raylib.DrawText("CAP", 220, 440, 90, darkestGreen);

                        Raylib.DrawRectangle(760, 430, 70, 20, darkGreen);
                        Raylib.DrawRectangle(750, 400, 60, 50, darkGreen);
                    }

                    Raylib.DrawText("Press 'B' to go Back", 200, 700, 60, darkestGreen);

                }




                //HELP SCREEN:

                if (screen == GameScreens.Help){
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        screen = GameScreens.Title;
                    }

                    Raylib.ClearBackground(lightestGreen);
                    Raylib.DrawText("CONTROLS", 295, 150, 70, darkGreen);

                    Raylib.DrawRectangle(295, 230, 390, 15, darkGreen);

                    Raylib.DrawText("Move:  W/A/S/D", 300, 300, 50, darkGreen);
                    Raylib.DrawText("Shoot:  SPACE", 300, 400, 50, darkGreen);
                    Raylib.DrawText("Ability:  L-SHIFT", 300, 500, 50, darkGreen);

                    Raylib.DrawText("Press 'B' to go Back", 200, 700, 60, darkestGreen);

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
                    myPlayer.DrawHP();
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


                    superTime += Raylib.GetFrameTime();

                    if (superTime > superMaxTime)
                    {
                        Raylib.DrawText("READY!", 680, 20, 50, darkGreen);

                        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT)){
                        keyPressed = KeyboardKey.KEY_W;
                        Bullet newBullet = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_D;
                        Bullet newBullet1 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_S;
                        Bullet newBullet2 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_A;
                        Bullet newBullet3 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_O;
                        Bullet newBullet4 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_P;
                        Bullet newBullet5 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_K;
                        Bullet newBullet6 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                        keyPressed = KeyboardKey.KEY_L;
                        Bullet newBullet7 = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);

                        superTime = 0;

                        }
                    }

                    if (superTime < superMaxTime){
                        Raylib.DrawText("LOADING...", 680, 20, 50, darkGreen);
                    }


                    endGame = myPlayer.CheckPlayerHp();

                    if(endGame == true){
                        screen = GameScreens.End;
                    }

                    
                }


                //END GAME SCREEN:


                if(screen == GameScreens.End){
                    Raylib.ClearBackground(darkestGreen);
                    Raylib.DrawText("You Died!", 355, 350, 70, lightGreen);

                    Raylib.DrawText("Score: " + gameUI.score, 405, 450, 50, lightestGreen);

                    Raylib.DrawText("Press 'R' to Restart", 250, 650, 50, lightestGreen);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        screen = GameScreens.Title;

                        gameUI.ScoreFix();
                        myPlayer.ResetPlayerHp();

                        maxTime = 6;
                    }
                }


                //IF OVERLAY IS ON

                if(shaderCount == 1){
                    Raylib.DrawRectangle(0, 0, 1500, 1500, silentNight);
                }

                else if(shaderCount == 2){
                    Raylib.DrawRectangle(0, 0, 1500, 1500, pinkParty);
                }

                else if(shaderCount == 3){
                    Raylib.DrawRectangle(0, 0, 1500, 1500, redHills);
                }

                else if(shaderCount == 4){
                    Raylib.DrawRectangle(0, 0, 1500, 1500, waterBubbles);
                }

                else if(shaderCount == 5){
                    Raylib.DrawRectangle(0, 0, 1500, 1500, greeeeen);
                }

                Raylib.EndDrawing();

            }

        }
    }
}
