using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Player
    {
        Color darkGreen = new Color (48, 98, 48, 255);

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
      }
      if (Raylib.IsKeyDown(downKey))
      {
        playerRec.y += 4f;
      }
      if (Raylib.IsKeyDown(rightKey))
      {
          playerRec.x += 4f;
      }
      if (Raylib.IsKeyDown(leftKey))
      {
          playerRec.x -= 4f;
      }
    }

    public void Draw()
    {
      Raylib.DrawRectangleRec(playerRec, darkGreen);
    }


    }
}
