using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Player
    {

        //Skapar massa variabler:
        Color darkGreen = new Color (48, 98, 48, 255); //Mörkgrön färg

        public int playerHealth = 3; //Används för att räkna spelarens HP

        public bool destroyThis = false;

        public KeyboardKey lastKeyPressed; //Används för att kolla vilken riktning spelaren tittar åt

        public Rectangle playerRec; //Spelarens rectangle (sprite)

        public KeyboardKey upKey; //Uppåt knappen
        public KeyboardKey downKey; //Neråt knappen
        public KeyboardKey rightKey; //Höger knappen
        public KeyboardKey leftKey; //Vänster knappen


        //Konstruktorn:
        //Tar in följande värden: x- och yStart vilket talar om vart spelarens utgångspunkt är och...
        //Knappar för alla (4) riktningar.
        public Player(float xStart, float yStart, KeyboardKey up, KeyboardKey down, KeyboardKey right, KeyboardKey left)
    {
      //Sätter spelarens sprite position till x- och yStart. 
      playerRec = new Rectangle(xStart, yStart, 30, 50);

      //sätter knapparna för riktningarna till de inmatade KeyboardKeysen.
      upKey = up;
      downKey = down;
      rightKey = right;
      leftKey = left;   
    }

    //Update()-metoden:
    public void Update()
    {
      //Ifall man trycker på Up-Key...
      if (Raylib.IsKeyDown(upKey))
      {
        //Förflyttar karaktären uppåt
        playerRec.y -= 4f;
        //Sätter "lastKeyPressed" till 'W'-tangenten
        lastKeyPressed = KeyboardKey.KEY_W;
      }
      //Ifall man trycker på Down-Key...
      if (Raylib.IsKeyDown(downKey))
      {
        //Förflyttar karaktären nedåt
        playerRec.y += 4f;
        //Sätter "lastKeyPressed" till 'S'-tangenten
        lastKeyPressed = KeyboardKey.KEY_S;
      }
      //Ifall man trycker på Right-Key...
      if (Raylib.IsKeyDown(rightKey))
      {
          //Förflyttar karaktären åt höger
          playerRec.x += 4f;
          //Sätter "lastKeyPressed" till 'D'-tangenten
          lastKeyPressed = KeyboardKey.KEY_D;
      }
      //Ifall man trycker på Left-Key...
      if (Raylib.IsKeyDown(leftKey))
      {
          //Förflyttar karaktären åt vänster
          playerRec.x -= 4f;
          //Sätter "lastKeyPressed" till 'A'-tangenten
          lastKeyPressed = KeyboardKey.KEY_A;
      }

      //Ifall spelarens x-position är mindre än 50:
      if (playerRec.x < 50){
        //Sätter spelarens x-position till 50
        //Detta görs för att spelaren inte ska hamna utanför skärmen eller i väggarna
        playerRec.x = 50;
      }

      //Ifall spelarens x-position är större än 920:
      if (playerRec.x > 920){
        //Sätter spelarens x-position till 920
        playerRec.x = 920;
      }

      //Ifall spelarens y-position är mindre än 200:
      if (playerRec.y < 200){
        //Sätter spelarens y-position till 200
        playerRec.y = 200;
      }

      //Ifall spelarens y-position är större än 700:
      if (playerRec.y > 700){
        //Sätter spelarens y-position till 700
        playerRec.y = 700;
      }

      //Följande kod körs för varje enemy i listan med alla aktiva Enemies
      foreach (Enemy e in Enemy.enemies)
        {
            //Ifall spelaren kolliderar med fienden och "destroyThis" = false, körs koden:
            if (Raylib.CheckCollisionRecs(playerRec, e.enemyRec) && destroyThis == false)
            {
              //Sätter "destroyThis" till true, för specifika enemies som kolliderar med spelaren
                e.DestroyThis = true; //Destroy this tar alltså bort enemyn från listan av alla enemies
                //Subtraherar spelarens Hp med 1
                playerHealth --;
            }
        }
    }

    //Draw() - metoden:
    public void Draw()
    {
      //Ritar ut spelarens sprite
      Raylib.DrawRectangleRec(playerRec, darkGreen);
    }

    //DrawHP() - metoden:
    public void DrawHP()
    {
      //Ifall spelarens HP = 1:
      if (playerHealth == 1){
        //Rita ut 1 Hp-ruta
        Raylib.DrawRectangle(210, 20, 40, 40, darkGreen);
      }

      //Ifall spelarens HP = 2:
      if (playerHealth == 2){
        //Rita ut 2 Hp-rutor
        Raylib.DrawRectangle(210, 20, 40, 40, darkGreen);
        Raylib.DrawRectangle(280, 20, 40, 40, darkGreen);
      }

      //Ifall spelarens HP = 3:
      if (playerHealth == 3){
        //Rita ut 3 Hp-rutor
        Raylib.DrawRectangle(210, 20, 40, 40, darkGreen);
        Raylib.DrawRectangle(280, 20, 40, 40, darkGreen);
        Raylib.DrawRectangle(350, 20, 40, 40, darkGreen);
      }

      //Ifall spelarens HP < 0:
      if(playerHealth < 0){
        //Sätter spelarens HP till 0
        playerHealth = 0;
      }
    }

    //CheckPlayerHp() - metoden:
    public bool CheckPlayerHp(){

      //Ifall spelarens hp = 0:
      if(playerHealth == 0){
        //Returnerar true
        return true;
      }

      //Annars...:
      else{
        //Returnerar false
        return false;
      }
    }

    //ResetPlayerHp() - metoden:
    public void ResetPlayerHp(){
      //Sätter spelarens Hp till 3
      playerHealth = 3;
    }

    //DrawTopHat() - metoden
    public void DrawTopHat(){

      //Ritar ut 2 rektanglar över spelarens sprite som föreställer en "Top Hat"
      Raylib.DrawRectangle((int)playerRec.x - 10, (int)playerRec.y - 10, 50, 10, darkGreen);
      Raylib.DrawRectangle((int)playerRec.x, (int)playerRec.y - 30, 30, 30, darkGreen);
    }

    public void DrawCAP(){
      //Ritar ut 2 rektanglar över spelarens sprite som föreställer en "Cap"
      Raylib.DrawRectangle((int)playerRec.x, (int)playerRec.y - 10, 50, 15, darkGreen);
      Raylib.DrawRectangle((int)playerRec.x, (int)playerRec.y - 30, 35, 30, darkGreen);
    }

  }

}
