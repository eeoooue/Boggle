using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleCLI
{
    internal class Presenter
    {
        public void SayInColour(string message, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.WriteLine($"Enter a word from the grid to score points! (current score: {points})");
            Console.WriteLine("Enter 'START OVER' for a new grid");
            Console.WriteLine();
        }

        public void PrintDieFace(string letters)
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
