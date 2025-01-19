using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle.GuessOutcomes
{
    public class WordNotInDictionary : GuessOutcome
    {
        public WordNotInDictionary(string guess) : base(guess)
        {

        }

        public override string GetMessage()
        {
            return $"Sorry, '{Guess}' isn't in our dictionary.";
        }
    }
}
