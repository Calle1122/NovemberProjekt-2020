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
            Raylib.DrawText("Score: " + score, 30, 80, 50, darkestGreen);
            Raylib.DrawText("HiScore: " + hiScore, 500, 80, 50, darkestGreen);
            Raylib.DrawText("Health: ", 30, 20, 50, darkestGreen);
            Raylib.DrawText("Ability: ", 500, 20, 50, darkestGreen);
        }

        public void AddScore(){
            score++;
        }

        public void ScoreFix(){
            if(score > hiScore){
                hiScore = score;
            }

            score = 0;
        }

    }
}
