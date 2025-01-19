using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    internal class WordDictionary
    {
        private HashSet<string> Words = new HashSet<string>();

        public WordDictionary(string filename)
        {
            LoadWords(filename);
        }

        private void LoadWords(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string? content = reader.ReadLine();
                    if (content is string line)
                    {
                        string word = line.Trim();
                        Words.Add(word.ToUpper());
                    }
                }
            }
        }

        public bool ContainsWord(string word)
        {
            return Words.Contains(word);
        }
    }
}
