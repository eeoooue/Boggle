using LibBoggle.DiceConfigs;
using LibBoggle.GuessOutcomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    public class BoggleGame
    {
        private IDiceConfig DiceConfig;
        private BoggleGrid BoggleGrid;
        private ScoringJudge ScoringJudge;
        private WordDictionary WordDictionary;
        private Randomizer Randomizer = new Randomizer();
        private List<GuessOutcome> Guesses = new List<GuessOutcome>();

        public int Points = 0;

        public string[,] Grid { get { return BoggleGrid.Grid; } }
        
        public BoggleGame()
        {
            DiceConfig = new DefaultBoggleDice();
            WordDictionary = new WordDictionary("Dictionary_Large.txt");
            ScoringJudge = new ScoringJudge(WordDictionary);
            BoggleGrid = new BoggleGrid(4, 4, DiceConfig);
            NewGame();
        }

        public void NewGame()
        {
            ScoringJudge.Reset();
            Guesses.Clear();
            Points = 0;
            BoggleGrid.Randomize(Randomizer);
        }

        public GuessOutcome SubmitGuess(string guess)
        {
            GuessOutcome outcome = ScoringJudge.GetGuessOutcome(BoggleGrid.Grid, guess);
            if(outcome is PointsScoredOutcome successfulGuess)
            {
                Points += successfulGuess.Points;
            }
            Guesses.Add(outcome);
            return outcome;
        }

        public GuessOutcome? GetMostRecentGuess()
        {
            if (Guesses.Count > 0)
            {
                return Guesses[Guesses.Count - 1];
            }

            return null;
        }

        public string GetCurrentFeedback()
        {
            if (GetMostRecentGuess() is GuessOutcome previousGuess)
            {
                return previousGuess.GetMessage();
            }

            return "Guess a word!";
        }
    }
}
