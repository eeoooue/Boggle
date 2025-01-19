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
            game.NewGame();

            while (true)
            {
                Console.Clear();
                Presenter.PresentGame(game);

                string input = GetUserInput();
                if (input == "START OVER")
                {
                    return;
                }

                game.SubmitGuess(input);
            }
        }

        static string GetUserInput()
        {
            string? input = Console.ReadLine();
            if (input is string text)
            {
                return text.ToUpper();
            }
            return "";
        }
    }
}
