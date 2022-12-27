using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL_Library
{
    public class Dice
    {

        public string[] faces;
        private int currentFace = 0;
        private Random randomizer;

        public Dice(string[] faceContents)
        {
            faces = faceContents;
            randomizer = new Random();
            RollDie();
        }

        public Dice(string faceContents) : this (faceContents.Split(','))
        {
            // overload
        }

        public void RollDie()
        {
            currentFace = randomizer.Next(faces.Length);
        }

        public string GetCurrentFace()
        {
            return faces[currentFace];
        }
    }
}
