using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    internal class BoggleDie
    {
        public string Face { get { return Faces[CurrentFace]; } }

        private string[] Faces;
        private int CurrentFace = 0;

        public BoggleDie(string[] faceValues)
        {
            Faces = faceValues;
        }

        public BoggleDie(string faceValues) : this(faceValues.Split(',')) { }

        public void Roll(Randomizer randomizer)
        {
            CurrentFace = randomizer.RollD6() - 1;
        }
    }
}
