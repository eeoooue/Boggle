using LibBoggle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleWPF.ViewModels
{
    internal class FooterViewModel : BaseViewModel
    {
        private string _userInput;
        public string UserInput
        {
            get => _userInput;
            set { _userInput = value; OnPropertyChanged(); }
        }

        private string _message;
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
