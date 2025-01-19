using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    internal interface IDiceConfig
    {
        public List<BoggleDie> GetDice(int count);
    }
}
