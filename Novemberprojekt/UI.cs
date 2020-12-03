using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class UI
    {
        public int score = 0;
        public int hiScore = 0;
        Color darkestGreen = new Color (15, 56, 15, 255);

        public void DrawUI(){
            Raylib.DrawText("Score: " + score, 30, 70, 70, darkestGreen);
            Raylib.DrawText("HiScore: " + hiScore, 500, 70, 70, darkestGreen);
        }

        public void AddScore(){
            score++;
        }
    }
}
