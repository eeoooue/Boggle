using BGL_Library;

namespace BoggleCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoggleGame myGame = BoggleGame.GetInstance(4, 4, 16);

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Boggle!");
                myGame.NewGrid();

                do
                {
                    PrintGrid(myGame.GetGrid(), myGame.points);
                    string input = Console.ReadLine().ToLower();

                    if (input == "start over")
                    {
                        break;
                    }

                    Console.Clear();
                    InterpretGuess(ref myGame, input);

                } while (true);

            } while (true);
        }

        static void InterpretGuess(ref BoggleGame myGame, string input)
        {
            GuessOutcome outcome = myGame.SubmitGuess(input);

            switch (outcome)
            {
                case GuessOutcome.AlreadyFound:
                    SayInColour($"'{input}' has already been found!", ConsoleColor.Red);
                    break;

                case GuessOutcome.Correct:
                    SayInColour($"well done! you found '{input}' (+{myGame.WordScore(input)} points)", ConsoleColor.Green);
                    break;

                case GuessOutcome.InvalidWord:
                    SayInColour($"'{input}' isn't a valid word for Boggle", ConsoleColor.Red);
                    break;

                case GuessOutcome.NotInBoard:
                    SayInColour($"'{input}' couldn't be found", ConsoleColor.Red);
                    break;

                default:
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
