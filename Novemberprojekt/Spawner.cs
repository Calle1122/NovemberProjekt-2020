using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Novemberprojekt
{
    public class Spawner
    {
        Random generator = new Random();

        Color lightGreen = new Color(139, 172, 15, 255);

        public int SpawnerId(){
            int spawnerId = generator.Next(1,5);

            return spawnerId;
        }

        public void Draw(){
            Raylib.DrawCircle(110, 260, 30f, lightGreen);
            Raylib.DrawCircle(900, 260, 30f, lightGreen);
            Raylib.DrawCircle(110, 700, 30f, lightGreen);
            Raylib.DrawCircle(900, 700, 30f, lightGreen);
        }
    }
}
