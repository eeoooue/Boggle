using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleWPF.ViewModels
{
    public class GridViewModel : BaseViewModel
    {
        public ObservableCollection<TileViewModel> Tiles { get; set; }

        public GridViewModel(string[,] grid)
        {
            Tiles = new ObservableCollection<TileViewModel>();
            UpdateGrid(grid);
        }

        public void UpdateGrid(string[,] grid)
        {
            Tiles.Clear();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Tiles.Add(new TileViewModel(grid[i, j]));
                }
            }
        }
    }
}
