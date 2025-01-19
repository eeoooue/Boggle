using LibBoggle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoggleWPF.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public HeaderViewModel Header { get; set; }
        public GridViewModel Grid { get; set; }

        public FooterViewModel Footer { get; set; }

        private BoggleGame _game;

        public MainViewModel()
        {
            _game = new BoggleGame();

            Grid = new GridViewModel(_game.Grid);
            Header = new HeaderViewModel();
            Footer = new FooterViewModel(SubmitGuess, StartOver);

            StartNewGame();
        }

        private void StartNewGame()
        {
            _game.NewGame();
            Grid.UpdateGrid(_game.Grid);
            Header.UpdateScore(_game.Points);
            Footer.Clear();
        }

        private void SubmitGuess()
        {
            string guess = Footer.UserInput;
            var outcome = _game.SubmitGuess(guess);
            Footer.Clear();
            Header.UpdateScore(_game.Points);
            Footer.ShowOutcome(outcome);
        }

        private void StartOver()
        {
            StartNewGame();
        }
    }
}
