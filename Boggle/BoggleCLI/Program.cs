using LibBoggle;
using LibBoggle.GuessOutcomes;

namespace BoggleCLI
{
    internal class Program
    {
        private static Presenter Presenter = new Presenter();

        static void Main(string[] args)
        {
            BoggleGame game = new BoggleGame();

            while (true)
            {
                PlayBoggle(game);
            }
        }

        static void PlayBoggle(BoggleGame game)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Boggle!");
            game.NewGame();

            while (true)
            {
                Presenter.PrintGrid(game.Grid, game.Points);
                string input = Console.ReadLine().ToLower();

                if (input == "start over")
                {
                    break;
                }

                Console.Clear();
                InterpretGuess(ref game, input);
            }
        }

        static void InterpretGuess(ref BoggleGame game, string input)
        {
            GuessOutcome outcome = game.SubmitGuess(input);

            switch (outcome)
            {
                case PointsScoredOutcome:
                    Presenter.SayInColour(outcome.GetMessage(), ConsoleColor.Green);
                    break;
                default:
                    Presenter.SayInColour(outcome.GetMessage(), ConsoleColor.Red);
                    break;
            }
        }
    }
}
