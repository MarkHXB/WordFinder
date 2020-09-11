using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonIndexer
{
    public class ListHandling
    {
        public Button currentButton { get; set; }
        public string currentWord { get; set; }
        public ListHandling(Button button)
        {
            this.currentButton=button;
        }   
        public ListHandling(string word)
        {
            this.currentWord = word;
        }
    }
}
