using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    class Program
    {

        //GameScreens som bestämmer vilken "scen" som ska visas i spelet skapas
        enum GameScreens {
        Title,
        Help,
        Settings, 
        CustomPlayer,
        Game,
        End
        }

        
        //Main koden:
        static void Main(string[] args)
        {

            //Massa variabler skapas nedan

            bool endGame = false;

            int shaderCount = 0; //Denna används för att bestämma vilken färg spelet ska vara
            int hatCount = 0; //Denna används för att hålla koll på vilken hatt spelaren har på sig

            //Alla float-"Time" variabler används för funktioner som kräver någon form av klocka eller tidräkning

            float startTime = 0;
            float maxStartTime = 6;

            float currentTime = 0;
            float maxTime = 6;

            float superTime = 0;
            float superMaxTime = 10;

            //Color variablerna är de olika färgerna som används i spelet

            Color lightestGreen = new Color(155, 188, 15, 255);
            Color lightGreen = new Color(139, 172, 15, 255);
            Color darkGreen = new Color(48, 98, 48, 255);
            Color darkestGreen = new Color(15, 56, 15, 255);

            //Colors nedan används endast som overlays när man använder olika "shaders"

            Color silentNight = new Color(65, 46, 100, 150);
            Color pinkParty = new Color(255, 0, 221, 150);
            Color redHills = new Color(255, 85, 0, 150);
            Color waterBubbles = new Color(0, 255, 191, 150);
            Color greeeeen = new Color(0, 255, 26, 150);

            //Initialize window. Spelfönstret "skapas".

            Raylib.InitWindow(1000, 800, "Slime Shooter");

            //Target FPS = 60fps
            Raylib.SetTargetFPS(60);

            //Skapar en instans av klassen Player (Alltså spelaren)
            Player myPlayer = new Player(500, 400, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_D, KeyboardKey.KEY_A);

            //Här definieras spelarens collider som spelarens rectangle-sprite.
            Rectangle playerCollider = myPlayer.playerRec;

            //Skapar en instans av klassen Walls (Banans boundries/borders)
            Wall gameWalls = new Wall();

            //Skapar en instans av klassen UI (Spelets HUD/GUI/UI eller vad det nu kallas)
            UI gameUI = new UI();

            //Skapar en instans av klassen Spawner (Sakerna som faktiskt "skapar" fiender i spelet)
            Spawner mobSpawners = new Spawner();

            //Skapar en instans av klassen Enemy (Spelets fiender)
            Enemy activeEnemies = new Enemy(gameUI);

            //Här defineiras "screen" = TitleScreen
            GameScreens screen = GameScreens.Title;

            //While nedan körs sålänge spelfönstret inte stängs
            while (!Raylib.WindowShouldClose())
            {

                //Börjar rita (sker varje frame)
                Raylib.BeginDrawing();


                //TITLE SCREEN:
                //if loopen körs alltså eftersom "screen" är satt till TitleScreen

                if(screen == GameScreens.Title){

                    //Denna rektangel används för att animera "ENTER" texten
                    Rectangle flashingRec = new Rectangle(360, 420, 250, 10);

                    //Ifall man klickar på ENTER-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        //Sätter "screen" till Game, vilket innebär att själva spelet startar
                        screen = GameScreens.Game;
                    }

                    //Ifall man klickar på C-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_C))
                    {
                        //Sätter "screen" till CustomPlayer, vilket gör att customize scenen visas
                        screen = GameScreens.CustomPlayer;
                    }

                    //Ifall man klickar på H-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_H))
                    {
                        //Sätter "screen" till Help, vilket gör att Hjälp skärmen visas
                        screen = GameScreens.Help;
                    }

                    //Ifall man klickar på S-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                    {
                        //Sätter "screen" till Settings, vilket gör att inställningar visas
                        screen = GameScreens.Settings;
                    }

                    //Sätter bakgrundsfärgen till ljusgrön
                    Raylib.ClearBackground(lightGreen);
                    //Ritar upp texten "Press ENTER to start"
                    Raylib.DrawText("Press ENTER to start", 115, 350, 70, darkestGreen);

                    //Raderna nedan ritar upp text för olika knappar som används för olika funktioner
                    Raylib.DrawText("Press 'H' for Help", 315, 600, 40, darkestGreen);
                    Raylib.DrawText("Press 'S' for Settings", 280, 670, 40, darkestGreen);
                    Raylib.DrawText("Press 'C' for Customization", 220, 735, 40, darkestGreen);

                    //Denna rektangel tänkte användas för att skapa en logga för spelet, men fungerade inte som tänkt.
                    //Raylib.DrawRectangle(275, 50, 450, 250, darkestGreen);
                    
                    //Koden nedan används för att animera en rektangel under ordet ENTER
                    startTime += Raylib.GetFrameTime();

                    //De olika if-satserna används för att bestämma när rektangeln ska visas och när den ska vara osynlig
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
                
                //Koden nedan visas ifall "screen" = Settings

                if (screen == GameScreens.Settings){

                    //Ifall man klickar på B-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        //Sätter "screen" tillbaka till Title-Screen (B används som "Back")
                        screen = GameScreens.Title;
                    }

                    //Ifall man klickar på ENTER-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        //Lägger till 1, till variabeln "shaderCount" som används för att 'bläddra' mellan olika shaders
                        shaderCount++;

                        //If-satsen nedan gör så att "shaderCount" blir 0 ifall den blir större än 5 (som är max antal shaders som finns)
                        if(shaderCount > 5){
                            shaderCount = 0;
                        }  
                    }

                    //Sätter bakgrundsfärgen till ljusgrön
                    Raylib.ClearBackground(lightestGreen);

                    //Skriver ut texten "SETTINGS"
                    Raylib.DrawText("SETTINGS", 295, 150, 70, darkGreen);

                    //Ritar ut ett sträck under texten
                    Raylib.DrawRectangle(295, 230, 390, 15, darkGreen);

                    //Skriver ut texten "Toggle shaders with ENTER key"
                    Raylib.DrawText("Toggle shaders with ENTER key", 250, 300, 30, darkGreen);

                    //Skriver ut symboler som ska indikera att man kan bläddra mellan olika alternativ
                    Raylib.DrawText("<               >", 180, 400, 100, darkGreen);

                    //Alla 6 if-satser nedan används enbart för att skriva ut namnet på den aktiva 'shadern'
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

                    //Skriver ut texten "Press 'B' to go Back"
                    Raylib.DrawText("Press 'B' to go Back", 200, 700, 60, darkestGreen);

                }


                
                //CUSTOM PLAYER SCREEN:

                //Koden nedan visas ifall "screen" = CustomPlayer

                if(screen == GameScreens.CustomPlayer){

                    //Ifall man trycker på B-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        //Sätter "screen" = TitleScreen
                        screen = GameScreens.Title;
                    }
                    
                    //Ändrar/Sätter bakgrundsfärgen till ljusgrön
                    Raylib.ClearBackground(lightestGreen);

                    //Skriver ut texten "HATS" och ritar ett streck under texten
                    Raylib.DrawText("HATS", 380, 75, 80, darkGreen);
                    Raylib.DrawRectangle(345, 150, 300, 15, darkGreen);

                    //Skriver ut texten "Press ENTER to toggle between Hats"
                    Raylib.DrawText("Press ENTER to toggle between Hats", 210, 190, 30, darkestGreen);

                    //Raderna nedan används för att rita ut rektanglar som används som gränssnitt.
                    Raylib.DrawRectangle(630, 300, 15, 350, darkestGreen);
                    Raylib.DrawRectangle(900, 300, 15, 350, darkestGreen);
                    Raylib.DrawRectangle(630, 300, 270, 15, darkestGreen);
                    Raylib.DrawRectangle(630, 635, 270, 15, darkestGreen);

                    Raylib.DrawRectangle(750, 450, 50, 100, darkGreen);

                    //Skriver ut pilar som används för att indikera att man kan bläddra mellan olika alternativ
                    Raylib.DrawText("<          >", 80, 430, 100, darkestGreen);

                    //Ifall man trycker på ENTER-Key...
                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)){

                        //Adderar 1 till variabeln "hatCount" som används för att hålla koll på vilken hatt som är aktiv
                        hatCount = hatCount + 1;

                        //if-satsen nedan används för att sätta tillbaka "hatCount" till 0, ifall den överstiger 'maxvärdet'
                        if(hatCount > 2){
                            hatCount = 0;
                        }
                    }

                    //if-satserna nedan används för att skriva och rita olika texter och saker beroende på vilken hatt som är aktiv
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

                    //Skriver ut texten "Press 'B' to go Back"
                    Raylib.DrawText("Press 'B' to go Back", 200, 700, 60, darkestGreen);

                }




                //HELP SCREEN:

                //Koden nedan körs ifall "screen" = Help

                if (screen == GameScreens.Help){

                    //Ifall man klickar på B-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
                    {
                        //"screen" = TitleScreen (igen)
                        screen = GameScreens.Title;
                    }

                    //Sätter bakgrunden till ljusgrön färg
                    Raylib.ClearBackground(lightestGreen);

                    //Skriver ut texten "CONTROLS"
                    Raylib.DrawText("CONTROLS", 295, 150, 70, darkGreen);
                    //Ritar ut ett sträck under texten
                    Raylib.DrawRectangle(295, 230, 390, 15, darkGreen);

                    //Raderna nedan skriver ut spelets Controls
                    Raylib.DrawText("Move:  W/A/S/D", 300, 300, 50, darkGreen);
                    Raylib.DrawText("Shoot:  SPACE", 300, 400, 50, darkGreen);
                    Raylib.DrawText("Ability:  L-SHIFT", 300, 500, 50, darkGreen);

                    //Skriver ut texten "Press 'B' to go Back"
                    Raylib.DrawText("Press 'B' to go Back", 200, 700, 60, darkestGreen);

                }

                


                
                //GAME SCREEN:

                //Koden nedan körs ifall "screen" = Game (alltså är följande kod den biten man 'spelar')

                if(screen == GameScreens.Game){

                    //Startar en timer (används för att skapa enemies)
                    currentTime += Raylib.GetFrameTime();

                    //if-satsen körs ifall timern överstiger ett förbestämt maxvärde
                    if (currentTime > maxTime)
                    {
                        //timern sätts då till 0 och startar om
                        currentTime = 0;

                        //En fiende spawnar/skapas
                        Enemy newEnemy = new Enemy(gameUI);

                        //det förbestämda maxvärdet minskar (så att fiender spawnar/skapas snabbare och snabbare)
                        maxTime -= 0.25f;

                        //följande if-sats används för att det förbestämda maxvärdet inte ska bli mindre än en halv sekund
                        if(maxTime < 0.5){
                            maxTime = 0.5f;
                        }
                    }

                    //denna int används för att berätta för spelet vart fienden ska spawna/skapas
                    int spawner = mobSpawners.SpawnerId();

                    //Metoden "SpawnEnemy()" körs. "spawner" matas in i metoden för att berätta vart fienden ska spawna/skapas
                    activeEnemies.SpawnEnemy(spawner);

                    //Följande tre update-funktioner används för att, varje frame, uppdatera positionen för spelaren, fiender och bullets
                    myPlayer.Update();
                    Bullet.UpdateAll();
                    Enemy.UpdateAll(myPlayer.playerRec.x, myPlayer.playerRec.y);

                    //"keyPressed" lagrar den senaste knappen spelaren tryckt på med hjälp av metoden "lastKeyPressed()"
                    KeyboardKey keyPressed = myPlayer.lastKeyPressed;

                    //Sätter bakgrundsfärgen till ljusgrön
                    Raylib.ClearBackground(lightestGreen);

                    //Alla Draw()-metoder ritar ut olika saker. Exempelvis spawners, UI, spelaren, fiender osv.
                    mobSpawners.Draw();
                    gameUI.DrawUI();
                    myPlayer.Draw();
                    myPlayer.DrawHP();
                    Bullet.DrawAll();
                    Enemy.DrawAll();
                    gameWalls.Draw();

                    //De två if-satserna nedan ritar ut hattar på spelaren
                    if(hatCount == 1){
                        myPlayer.DrawTopHat();
                    }

                    if(hatCount == 2){
                        myPlayer.DrawCAP();
                    }

                    //Denna if-sats användes i testsyfte för att spawna fiender:
                    /*if (Raylib.IsKeyPressed(KeyboardKey.KEY_G))
                    //{
                    //    Enemy newEnemy = new Enemy(gameUI);
                    }*/

                    //Ifall man trycker på SPACE-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        //Skapar en instans av klassen Bullet (alltså skjuter spelaren ett skott)
                        //De värden som metoden tar in används för att bestämma vart kulan ska skapas och i vilken riktning den ska skjutas

                        Bullet newBullet = new Bullet(myPlayer.playerRec.x, myPlayer.playerRec.y, keyPressed);
                    }

                    //"superTime" används för att räkna när Super-Ability kan användas
                    superTime += Raylib.GetFrameTime();

                    //Ifall "superTime" är större än det förbestämda "superMaxTime" (max tiden) så körs koden:
                    if (superTime > superMaxTime)
                    {
                        //Texten "READY!" skrivs ut för att tala om för spelaren att ablity är redo
                        Raylib.DrawText("READY!", 680, 20, 50, darkGreen);

                        //Ifall man trycker på SHIFT-Key...
                        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_SHIFT)){

                        //Koden nedan KAOS och absolut inte effektiv, men den gör jobbet.
                        //Koden nedan skapar 8 bullets som skjuts ut i 8 olika riktningar.

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

                        //"superTime" sätts tillbaka till 0 och startas om (timern)
                        superTime = 0;

                        }
                    }

                    //om "superTime" är mindre än det förbestämda "superMaxTime" så körs koden:
                    if (superTime < superMaxTime){

                        //Skriver ut texten "LOADING..."
                        Raylib.DrawText("LOADING...", 680, 20, 50, darkGreen);
                    }

                    //"endGame är en bool som kollar ifall spelet ska avslutas
                    //metoden CheckPlayerHP() sätter endGame till true ifall spelarens HP är 0
                    endGame = myPlayer.CheckPlayerHp();

                    //if endGame = true körs koden:
                    if(endGame == true){
                        //Sätter "screen" = End (innebär att spelet avslutas och att man kommer till GAME OVER SCREEN)
                        screen = GameScreens.End;
                    }

                    
                }


                //END GAME SCREEN:

                //Koden nedan körs ifall "screen" = END

                if(screen == GameScreens.End){

                    //Sätter bakgrundsfärgen till mörkgrön
                    Raylib.ClearBackground(darkestGreen);
                    //Skriver ut texten "You Died!"
                    Raylib.DrawText("You Died!", 355, 350, 70, lightGreen);

                    //Skriver ut texten "Score: " och sedan det score man fick då man spelade
                    Raylib.DrawText("Score: " + gameUI.score, 405, 450, 50, lightestGreen);

                    //Skriver ut texten "Press 'R' to Restart"
                    Raylib.DrawText("Press 'R' to Restart", 250, 650, 50, lightestGreen);

                    //Ifall man trycker på R-Key...
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        //Sätter "screen" till TitleScreen ("R" för Restart)
                        screen = GameScreens.Title;

                        //ScoreFix() - metoden körs för att uppdatera Highscore till Score ifall Score > Highscore.
                        gameUI.ScoreFix();

                        //ResetPlayerHp() - metoden körs för att sätta tillbaka Hp = 3 (ifall man spelar igen)
                        myPlayer.ResetPlayerHp();

                        //Sätter tillbaka maxTime = 6 så att fiender inte spawnar snabbt från början (ifall man spelar igen)
                        maxTime = 6;
                    }
                }


                //IF OVERLAY IS ON
                //Koden nedan körs endast ifall man aktiverat en 'shader'

                //Varje if-sats ritar ut en rektangel som täcker hela skrämen
                //Rektangelns färg är beroende på den aktiva shadern och rektangeln visas i en lägre opacity
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

                //EndDrawing() innebär att allt är färdigritat för den framen, sedan loopas allt och körs igen
                Raylib.EndDrawing();

            }

        }
    }
}
