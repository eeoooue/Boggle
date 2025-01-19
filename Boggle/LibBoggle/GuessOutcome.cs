using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    public abstract class GuessOutcome
    {
        public string Guess = "";

        public GuessOutcome(string guess)
        {
            Guess = guess.ToUpper();
        }

        public abstract string GetMessage();
    }
}
