using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL_Library
{
    public class BoggleGame
    {
        private static BoggleGame? _instance;

        private BoggleGrid grid;
        private WordJudge judge;
        public int points = 0;
        private BoggleGame(int rows=4, int columns=4, int dice=16)
        {
            // private constructor for Singleton pattern
            grid = BoggleGrid.GetInstance(rows, columns, dice);
            judge = WordJudge.GetInstance();
        }

        public static BoggleGame GetInstance(int rows=4, int cols=4, int dice=16)
        {
            if(_instance == null)
            {
                _instance = new BoggleGame(rows, cols, dice);
            }
            return _instance;
        }

        public void NewGrid()
        {
            grid.RefreshGrid();
            points = 0;
        }
        public string[,] GetGrid()
        {
            return grid.grid;
        }

        public int WordScore(string word)
        {
            return judge.WordScore(word);
        }
        
        public GuessOutcome SubmitGuess(string word)
        {
            GuessOutcome verdict = judge.GetGuessOutcome(word, GetGrid());
            if(verdict == GuessOutcome.Correct)
            {
                points += WordScore(word);
            }
            return verdict;
        }
    }
}
