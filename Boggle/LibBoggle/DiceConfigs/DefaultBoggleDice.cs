using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle.DiceConfigs
{
    internal class DefaultBoggleDice : IDiceConfig
    {
        public List<BoggleDie> GetDice(int count)
        {
            string[] diceMaps = {
                "A,A,E,E,G,N",
                "A,B,B,J,O,O",
                "A,C,H,O,P,S",
                "A,F,F,K,P,S",
                "A,O,O,T,T,W",
                "C,I,M,O,T,U",
                "D,E,I,L,R,X",
                "D,E,L,R,V,Y",
                "D,I,S,T,T,Y",
                "E,E,G,H,N,W",
                "E,E,I,N,S,U",
                "E,H,R,T,V,W",
                "E,I,O,S,S,T",
                "E,L,R,T,T,Y",
                "H,I,M,N,U,Qu",
                "H,L,N,N,R,Z"
            };

            List<BoggleDie> result = new List<BoggleDie>();

            for (int i = 0; i < count; i++)
            {
                BoggleDie die = new BoggleDie(diceMaps[i % diceMaps.Length]);
            }

            return result;
        }




    }
}
