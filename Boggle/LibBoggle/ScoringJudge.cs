using LibBoggle.GuessOutcomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    internal class ScoringJudge
    {
        private HashSet<string> WordsFound = new HashSet<string>();

        public int NumberOfWordsFound { get { return WordsFound.Count; } }

        private WordDictionary Dictionary;

        public ScoringJudge(WordDictionary dictionary)
        {
            Dictionary = dictionary;
        }

        public GuessOutcome GetGuessOutcome(string guess)
        {
            guess = guess.ToUpper();

            if (!WordExistsInGrid(guess))
            {
                return new WordNotInGrid(guess);
            }

            if (!Dictionary.ContainsWord(guess))
            {
                return new WordNotInDictionary(guess);
            }

            if (WordsFound.Contains(guess))
            {
                return new WordAlreadyFoundOutcome(guess);
            }

            int points = ScoreWord(guess);
            WordsFound.Add(guess);

            return new PointsScoredOutcome(guess, points);
        }

        public void Reset()
        {
            WordsFound.Clear();
        }

        private int ScoreWord(string word)
        {
            throw new NotImplementedException();
        }

        private bool WordExistsInGrid(string word)
        {
            throw new NotImplementedException();
        }
    }
}
