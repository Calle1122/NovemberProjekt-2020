using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class UI
    {
        //Skapar massa variabler:
        public int score = 0; //Håller koll på spelarens score
        public int coins = 0; //Håller koll på spelarens coins (inte implementerat i spelet. fyller ingen funktion)
        public int hiScore = 0; //Håller koll på spelarens hiScore
        Color darkestGreen = new Color (15, 56, 15, 255); //Mörkgrön färg


        //DrawUI() - metoden:
        public void DrawUI(){
            //Skriver ut (4) olika texter:
            Raylib.DrawText("Score: " + score, 30, 80, 50, darkestGreen);
            Raylib.DrawText("HiScore: " + hiScore, 500, 80, 50, darkestGreen);
            Raylib.DrawText("Health: ", 30, 20, 50, darkestGreen);
            Raylib.DrawText("Ability: ", 500, 20, 50, darkestGreen);
        }

        //AddScore() - metoden:
        public void AddScore(){
            //Adderar 1 till score och coins.
            score++;
            coins++;
        }

        //ScoreFix() - metoden
        public void ScoreFix(){
            //if-satsen körs ifall score är större än hiScore
            if(score > hiScore){
                //Sätter "hiScore" till "score"
                hiScore = score;
            }

            //Sätter "score" till 0
            score = 0;
        }

    }
}
