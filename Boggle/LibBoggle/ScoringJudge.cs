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

        public GuessOutcome GetGuessOutcome(string[,] grid, string guess)
        {
            guess = guess.ToUpper();
            if (!Dictionary.ContainsWord(guess))
            {
                return new WordNotInDictionary(guess);
            }

            if (guess.Length < 3)
            {
                return new WordTooShort(guess);
            }

            if (!WordExistsInGrid(grid, guess))
            {
                return new WordNotInGrid(guess);
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
            switch (word.Length)
            {
                case < 3:
                    return 0;
                case < 5:
                    return 1;
                case 5:
                    return 2;
                case 6:
                    return 3;
                case 7:
                    return 5;
                default:
                    return 11;
            }
        }

        private bool WordExistsInGrid(string[,] grid, string word)
        {
            GridSearcher searcher = new GridSearcher(word, grid);
            return searcher.found;
        }
    }
}
