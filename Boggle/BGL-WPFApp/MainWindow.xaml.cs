using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BGL_Library;

namespace BGL_WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public BoggleGame myGame;
        public Button[] buttons;

        int m;
        int n;

        public MainWindow()
        {
            InitializeComponent();

            m = 4;
            n = 4;
            int dice = 16;

            myGame = BoggleGame.GetInstance(m, n, dice);
            buttons = new Button[m * n];

            CreateButtons();
            InitGuessBox();
            NewBoard();
        }

        private void PanelSay(string message, Brush colour)
        {
            SystemPanel.Foreground = colour;
            SystemPanel.Text = message;
        }

        private void NewBoard()
        {
            myGame.NewGrid();
            UpdateButtons(myGame.GetGrid());
            PanelSay("Welcome to Boggle!", Brushes.SteelBlue);
        }

        private void InitGuessBox()
        {
            guessBox.KeyDown += new KeyEventHandler(guessBox_KeyDown);
        }

        private void GuessWord(string word)
        {
            GuessOutcome feedback = myGame.SubmitGuess(word);
            switch (feedback)
            {
                case GuessOutcome.AlreadyFound:
                    PanelSay($"'{word}' has already been found. [score: {myGame.points}]", Brushes.Red);
                    break;

                case GuessOutcome.Correct:
                    PanelSay($"found '{word}' [score: {myGame.points}]", Brushes.Green);
                    break;

                case GuessOutcome.InvalidWord:
                    PanelSay($"'{word}' isn't a valid word. [score: {myGame.points}]", Brushes.Red);
                    break;

                case GuessOutcome.NotInBoard:
                    PanelSay($"'{word}' couldn't be found. [score: {myGame.points}]", Brushes.Red);
                    break;

                default:
                    break;
            }
        }

        private void guessBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string guess = guessBox.Text.ToLower();
                guessBox.Text = "";
                if (guess == "start over")
                {
                    NewBoard();
                    return;
                }
                GuessWord(guess);
            }
        }

        private void CreateButtons()
        {
            int p = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Button button = new Button()
                    {
                        Content = "",
                        Width = 80,
                        Height = 80,
                        FontSize = 32,
                    };

                    buttons[p++] = button;

                    GameBoard.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                }
            }
        }

        private void UpdateButtons(string[,] grid)
        {
            int p = 0;
            for(int i=0; i<m; i++)
            {
                for(int j=0; j<n; j++)
                {
                    buttons[p++].Content = grid[i, j];
                }
            }
        }
    }
}
