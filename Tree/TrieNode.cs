using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public String Word;

        public void Insert(String Word, char[] WordAsArray, int insertLocation)
        {
            // if this is the last node, simply insert this word into the Word 
            if (insertLocation == WordAsArray.Length)
            {
                this.Word = Word;
                return;
            }
            else
            {
                char _c = WordAsArray[insertLocation];
                int _i = TrieConstants.LetterToNumber[_c];

                if (Children[_i] == null)
                {
                    Children[_i] = new TrieNode();
                }

                Children[_i].Insert(Word, WordAsArray, ++insertLocation);
            }
        }

        public String[] FindByHints(char[] HintsAsArray, int searchLocation)
        {
            if (searchLocation == HintsAsArray.Length)
                return this.FindAll();
            else
            {
                char _c = HintsAsArray[searchLocation];
                int _i = TrieConstants.LetterToNumber[_c];

                if (Children[_i] != null)
                    return Children[_i].FindByHints(HintsAsArray, ++searchLocation);
                else
                    return new String[0];
            }
        }

        public String[] FindAll()
        {
            List<String> _retVal = new List<String>();
            if (this.Word != null)
                _retVal.Add(this.Word);

            for (int _i = 0; _i < 26; _i++)
            {
                if (Children[_i] != null)
                    _retVal.AddRange(Children[_i].FindAll());
            }

            return _retVal.ToArray();
        }
    }
}
