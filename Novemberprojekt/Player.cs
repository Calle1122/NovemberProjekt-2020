using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Player
    {
        Color darkGreen = new Color (48, 98, 48, 255);

        public int playerHealth = 3;

        public bool destroyThis = false;

        public KeyboardKey lastKeyPressed;

        public Rectangle playerRec;

        public KeyboardKey upKey;
        public KeyboardKey downKey;
        public KeyboardKey rightKey;
        public KeyboardKey leftKey;

        public Player(float xStart, float yStart, KeyboardKey up, KeyboardKey down, KeyboardKey right, KeyboardKey left)
    {
      playerRec = new Rectangle(xStart, yStart, 30, 50);
      upKey = up;
      downKey = down;
      rightKey = right;
      leftKey = left;   
    }

    public void Update()
    {
      if (Raylib.IsKeyDown(upKey))
      {
        playerRec.y -= 4f;
        lastKeyPressed = KeyboardKey.KEY_W;
      }
      if (Raylib.IsKeyDown(downKey))
      {
        playerRec.y += 4f;
        lastKeyPressed = KeyboardKey.KEY_S;
      }
      if (Raylib.IsKeyDown(rightKey))
      {
          playerRec.x += 4f;
          lastKeyPressed = KeyboardKey.KEY_D;
      }
      if (Raylib.IsKeyDown(leftKey))
      {
          playerRec.x -= 4f;
          lastKeyPressed = KeyboardKey.KEY_A;
      }

      if (playerRec.x < 50){
        playerRec.x = 50;
      }

      if (playerRec.x > 920){
        playerRec.x = 920;
      }

      if (playerRec.y < 200){
        playerRec.y = 200;
      }

      if (playerRec.y > 700){
        playerRec.y = 700;
      }

      foreach (Enemy e in Enemy.enemies)
        {
            if (Raylib.CheckCollisionRecs(playerRec, e.enemyRec) && destroyThis == false)
            {
                e.DestroyThis = true;
                playerHealth --;
            }
        }
    }

    public void Draw()
    {
      Raylib.DrawRectangleRec(playerRec, darkGreen);
    }

    public void DrawHP()
    {
      if (playerHealth == 1){
        Raylib.DrawRectangle(210, 20, 40, 40, darkGreen);
      }

      if (playerHealth == 2){
        Raylib.DrawRectangle(210, 20, 40, 40, darkGreen);
        Raylib.DrawRectangle(280, 20, 40, 40, darkGreen);
      }

      if (playerHealth == 3){
        Raylib.DrawRectangle(210, 20, 40, 40, darkGreen);
        Raylib.DrawRectangle(280, 20, 40, 40, darkGreen);
        Raylib.DrawRectangle(350, 20, 40, 40, darkGreen);
      }

      if(playerHealth < 0){
        playerHealth = 0;
      }
    }

    public bool CheckPlayerHp(){
      if(playerHealth == 0){
        return true;
      }

      else{
        return false;
      }
    }

    public void ResetPlayerHp(){
      playerHealth = 3;
    }

    public void DrawTopHat(){
      Raylib.DrawRectangle((int)playerRec.x - 10, (int)playerRec.y - 10, 50, 10, darkGreen);
      Raylib.DrawRectangle((int)playerRec.x, (int)playerRec.y - 30, 30, 30, darkGreen);
    }

    public void DrawCAP(){
      Raylib.DrawRectangle((int)playerRec.x, (int)playerRec.y - 10, 50, 15, darkGreen);
      Raylib.DrawRectangle((int)playerRec.x, (int)playerRec.y - 30, 35, 30, darkGreen);
    }

  }

}
