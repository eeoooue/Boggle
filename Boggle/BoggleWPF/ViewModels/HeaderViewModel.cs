using LibBoggle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleWPF.ViewModels
{
    public class HeaderViewModel : BaseViewModel
    {
        public string Title {  get { return "Boggle"; } }
        public string Message  { get { return $"Score: {Score}"; } }

        private int _score;
        public int Score
        {
            get => _score;
            set { _score = value; OnPropertyChanged(); OnPropertyChanged(nameof(Message)); }
        }

        public void UpdateScore(int score)
        {
            Score = score;
        }
    }

}
