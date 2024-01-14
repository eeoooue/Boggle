using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL_Library
{
    public enum GuessOutcome
    {
        AlreadyFound,
        Correct,
        InvalidWord,
        NotInBoard,
    }

    internal class WordJudge
    {
        private static WordJudge? _instance;
        private BoggleDictionary wordlist;
        private HashSet<string> seen;

        private WordJudge()
        {
            wordlist = new BoggleDictionary();
            seen = new HashSet<string>();
        }

        public static WordJudge GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WordJudge();
            }
            return _instance;
        }

        public int WordScore(string word)
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

        public bool DictionaryContains(string word)
        {
            if (!wordlist.Loaded)
            {
                return true;
            }

            return wordlist.words.Contains(word);
        }

        public GuessOutcome GetGuessOutcome(string word, string[,] grid)
        {
            if (seen.Contains(word))
            {
                return GuessOutcome.AlreadyFound;
            }

            if (word.Length < 3 || !DictionaryContains(word))
            {
                return GuessOutcome.InvalidWord;
            }

            GridSearcher finder = new GridSearcher(word, grid);

            if (finder.found)
            {
                seen.Add(word);
                return GuessOutcome.Correct;
            }

            return GuessOutcome.NotInBoard;
        }
    }
}
