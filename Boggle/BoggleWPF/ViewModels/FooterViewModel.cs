using LibBoggle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoggleWPF.ViewModels
{
    internal class FooterViewModel : BaseViewModel
    {
        public ICommand SubmitGuessCommand { get; }
        public ICommand StartOverCommand { get; }

        public FooterViewModel(Action submitGuessAction, Action startOverAction)
        {
            // Initialize commands with actions passed from MainViewModel
            SubmitGuessCommand = new RelayCommand(submitGuessAction);
            StartOverCommand = new RelayCommand(startOverAction);
        }

        private string _userInput = "";
        public string UserInput
        {
            get => _userInput;
            set { _userInput = value; OnPropertyChanged(); }
        }

        private string _message = "";
        public string Message
        {
            get => _message;
            set { _message = value; OnPropertyChanged(); }
        }

        public void ShowOutcome(GuessOutcome outcome)
        {
            Message = outcome.GetMessage();
        }

        public void Clear()
        {
            UserInput = string.Empty;
            Message = string.Empty;
        }
    }
}
