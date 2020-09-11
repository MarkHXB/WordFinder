using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buttonIndexer
{
    public class GameProccess
    {
        public string word1 { get; set; }
        public string word2 { get; set; }
        public string word3 { get; set; }
        public GameProccess(string word1)
        {
            this.word1 = word1;
        }
        public GameProccess(string word1,string word2)
        {
            this.word1 = word1;
            this.word2 = word2;
        }
        public GameProccess(string word1,string word2,string word3)
        {
            this.word1 = word1;
            this.word2 = word2;
            this.word3 = word3;
        }
    }
}
