using LibBoggle;
using LibBoggle.GuessOutcomes;

namespace BoggleCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoggleGame game = new BoggleGame();

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Boggle!");
                game.NewGame();

                do
                {
                    PrintGrid(game.Grid, game.Points);
                    string input = Console.ReadLine().ToLower();

                    if (input == "start over")
                    {
                        break;
                    }

                    Console.Clear();
                    InterpretGuess(ref game, input);

                } while (true);

            } while (true);
        }

        static void InterpretGuess(ref BoggleGame game, string input)
        {
            GuessOutcome outcome = game.SubmitGuess(input);

            switch (outcome)
            {
                case PointsScoredOutcome:
                    SayInColour(outcome.GetMessage(), ConsoleColor.Green);
                    break;
                default:
                    SayInColour(outcome.GetMessage(), ConsoleColor.Red);
                    break;
            }
        }

        static void SayInColour(string message, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintGrid(string[,] grid, int points)
        {
            Console.WriteLine();

            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                Console.Write("|");
                for (int j = 0; j < n; j++)
                {
                    PrintDieFace(grid[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Enter a word from the grid to score points! (current score: {points})");
            Console.WriteLine("Enter 'START OVER' for a new grid");
            Console.WriteLine();
        }

        static void PrintDieFace(string letters)
        {
            if (letters == null)
            {
                letters = " ";
            }
            if (letters.Length == 1)
            {
                letters = $"{letters} ";
            }
            Console.Write($"  {letters} |");
        }
    }
}
