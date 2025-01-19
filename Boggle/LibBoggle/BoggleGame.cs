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
        private List<GuessOutcome> History = new List<GuessOutcome>();

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
            History.Clear();
            Points = 0;
            BoggleGrid.Randomize(Randomizer);
        }

        public void SubmitGuess(string guess)
        {
            GuessOutcome outcome = ScoringJudge.GetGuessOutcome(guess);
            if(outcome is PointsScoredOutcome successfulGuess)
            {
                Points += successfulGuess.Points;
            }
            History.Add(outcome);
        }

        public string GetCurrentFeedback()
        {
            if (History.Count > 0)
            {
                GuessOutcome mostRecentGuess = History[History.Count - 1];
                return mostRecentGuess.GetMessage();
            }

            return "Guess a word!";
        }
    }
}
