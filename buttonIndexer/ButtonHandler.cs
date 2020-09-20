using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonIndexer
{
    //Out Of Service...
    public class ButtonHandler
    {
        private Button button;

        public ButtonHandler(Button aButton)
        {
            Button = aButton;
        }
        public Button Button
        {
            get { return button; }
            set
            {
                button = value;
            }
        }
    }
}
