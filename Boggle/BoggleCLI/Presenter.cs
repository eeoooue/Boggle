using LibBoggle;
using LibBoggle.GuessOutcomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleCLI
{
    internal class Presenter
    {
        public void PresentGame(BoggleGame game)
        {
            PresentHeader(game);
            PrintGrid(game.Grid, game.Points);

            Console.WriteLine($"Enter a word from the grid to score points!");
            Console.WriteLine("Enter 'START OVER' for a new grid.");

            GuessOutcome? outcome = game.GetMostRecentGuess();
            if (outcome is GuessOutcome previousOutcome)
            {
                PresentOutcome(previousOutcome);
            }
        }

        public void PresentHeader(BoggleGame game)
        {
            Console.WriteLine($"Boggle: {game.Points} pts");
        }

        public void PrintGrid(string[,] grid, int points)
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
        }

        public void PrintDieFace(string letters)
        {
            if (letters.Length <= 1)
            {
                letters = $"{letters} ";
            }
            Console.Write($"  {letters} |");
        }

        public void PresentOutcome(GuessOutcome outcome)
        {
            if (outcome is PointsScoredOutcome)
            {
                SayInColour(outcome.GetMessage(), ConsoleColor.Green);
            }
            else
            {
                SayInColour(outcome.GetMessage(), ConsoleColor.Red);
            }
        }

        public void SayInColour(string message, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
