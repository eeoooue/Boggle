﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL_Library
{

    public class Dictionary
    {
        public HashSet<string> words = new HashSet<string>();

        public Dictionary()
        {
            LoadWords("Dictionary_Large.txt");
        }

        private void LoadWords(string filename)
        {

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //Console.WriteLine(line);
                    words.Add(line);
                }
            }

            Console.WriteLine($"{words.Count} words loaded into dictionary");
        }

    }

}
