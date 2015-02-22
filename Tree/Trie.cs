using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Trie
    {
        TrieNode RootNode = new TrieNode();

        public void Insert(String Word)
        {
            RootNode.Insert(Word, Word.ToLower().ToCharArray(), 0);
        }

        public String[] FindByHint(String HintChars)
        {
            return RootNode.FindByHints(HintChars.ToLower().ToCharArray(), 0);
        }
    }
}
