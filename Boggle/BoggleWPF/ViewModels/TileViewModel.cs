using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleWPF.ViewModels
{
    public class TileViewModel : BaseViewModel
    {
        public string Letter { get; set; }

        public TileViewModel(string letter)
        {
            Letter = letter;
        }
    }
}
