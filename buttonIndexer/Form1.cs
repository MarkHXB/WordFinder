using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonIndexer
{
    public partial class Form1 : Form
    {
        //Lists
        public List<ListHandling> buttons = new List<ListHandling>();
        public List<string> words = new List<string>();
        public List<string> completedWords = new List<string>();
        public List<ButtonHandler> buttonHandling = new List<ButtonHandler>();

        //public variables
        public bool reapirAble = true;
        public string currentWord = "";
        public bool start = true;
        public int level = 1;

        //Default Settings
        public Color defaultButtonColor = Color.Blue;
        public Color afterButtonClickColor = Color.Gray;
        public Color stopButtonClickColor = Color.Red;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadTheButtonList(buttons);
            words.Add("tree");
            words.Add("apple");
            words.Add("peer");
            words.Add("watcher");
            words.Add("stick");
            words.Add("car");
            words.Add("programming");
            words.Add("unique");
            words.Add("umbrella");
            words.Add("task");
            foreach (var word in words)
            {
                listView1.Items.Add(word);
            }
        }
        private void loadTheButtonList(List<ListHandling> buttons)
        {
            buttons.Add(new ListHandling(button1));
            buttons.Add(new ListHandling(button2));
            buttons.Add(new ListHandling(button3));
            buttons.Add(new ListHandling(button4));
            buttons.Add(new ListHandling(button5));
            buttons.Add(new ListHandling(button6));
            buttons.Add(new ListHandling(button7));
            buttons.Add(new ListHandling(button8));
            buttons.Add(new ListHandling(button9));
            buttons.Add(new ListHandling(button10));
            buttons.Add(new ListHandling(button11));
            buttons.Add(new ListHandling(button12));
            buttons.Add(new ListHandling(button13));
            buttons.Add(new ListHandling(button14));
            buttons.Add(new ListHandling(button15));
            buttons.Add(new ListHandling(button16));
            buttons.Add(new ListHandling(button17));
            buttons.Add(new ListHandling(button18));
            buttons.Add(new ListHandling(button13));
            buttons.Add(new ListHandling(button19));
            buttons.Add(new ListHandling(button20));
            buttons.Add(new ListHandling(button21));
            buttons.Add(new ListHandling(button22));
            buttons.Add(new ListHandling(button23));
            buttons.Add(new ListHandling(button24));
            buttons.Add(new ListHandling(button25));
            buttons.Add(new ListHandling(button26));
            buttons.Add(new ListHandling(button27));
        }
        private void közös_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void becomeUnable(Button button)
        {
            if (!reapirAble)
            {
                button.BackColor = stopButtonClickColor;
                button.Enabled = false;
            }
            else
            {
                button.Visible = false;
                textBox1.Text += button.Text;
            }
        }
        private void checkTheResult(string guesWord,string helyesWord, List<ListHandling> buttons)
        {
            if (guesWord.Equals(helyesWord))
            {
                MessageBox.Show("Helyes");
                reapirAble = false;
                foreach (var item in buttons)
                {
                    item.currentButton.BackColor = defaultButtonColor;
                }
                textBox1.Text = "";
            }
            else
            {
                textBox1.Text = "";
                foreach (var item in buttons)
                {
                    item.currentButton.BackColor = defaultButtonColor;
                }
                foreach (ButtonHandler item in buttonHandling)
                {
                    if(item.Button.Visible == false)
                    {
                        item.Button.Visible = true;
                    }
                }
            }
        }
        private void checkMoreResult(List<string> completeWords, List<ListHandling> buttons)
        {
            string guesWord = textBox1.Text;
            int counter = 0;
            bool voltTalalat = false;

            foreach (string word in completedWords)
            {
                if (word.Equals(guesWord))
                {
                    MessageBox.Show("Helyes");
                    voltTalalat = true;
                    textBox1.Text = "";
                }
                buttons[counter].currentButton.BackColor = defaultButtonColor;
                counter++;
            }
            if (!voltTalalat)
            {
                textBox1.Text = "";
                foreach (var item in buttons)
                {
                    item.currentButton.BackColor = defaultButtonColor;
                }
                foreach (ButtonHandler item in buttonHandling)
                {
                    if (item.Button.Visible == false)
                    {
                        item.Button.Visible = true;
                    }
                }
            }
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            reapirAble = true;

            foreach (var item in buttons)
            {
                item.currentButton.BackColor = Color.Blue;
                item.currentButton.Enabled = true;
            }

            //Check how many words the user wants.
            if(!radiobtn2.Checked && !radiobtn3.Checked)
            {
                currentWord = words[r.Next(1, words.Count)];

                int gapCount = currentWord.Length;

                makeButtonsVisible(gapCount, buttons);
                functions.fillTheGap(currentWord, gapCount, buttons);

                radiobtnHide(radiobtn2);
                radiobtnHide(radiobtn3);
            }
            else if(radiobtn2.Checked)
            {
                int gapCount = 0;
                level = 2;

                for (int i = 0; i < level; i++)
                {
                   string word = words[r.Next(1, words.Count)];
                    gapCount += word.Length;
                    completedWords.Add(word);
                }     
       
                radiobtnHide(radiobtn2);
                radiobtnHide(radiobtn3);

                makeButtonsVisible(gapCount,buttons);
                functions.fillMoreGap(completedWords, buttons, level,gapCount);

            }
            else
            {
                int gapCount = 0;
                level = 3;

                for (int i = 0; i < level; i++)
                {
                    string word = words[r.Next(1, words.Count)];
                    gapCount += word.Length;
                    completedWords.Add(word);
                }
                
                radiobtnHide(radiobtn2);
                radiobtnHide(radiobtn3);

                makeButtonsVisible(gapCount, buttons);
                functions.fillMoreGap(completedWords, buttons, level,gapCount);
            }

            fillButton.Visible = false;
            playButton.Visible = true;

        }
        private static void radiobtnHide(RadioButton r)
        {
            r.Visible = false;
        }
        private void makeButtonsVisible(int gapCount,List<ListHandling>buttons)
        {
            for (int i = 0; i < gapCount; i++)
            {
                buttons[i].currentButton.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (level > 1)
                checkMoreResult(completedWords, buttons);
            else
                checkTheResult(textBox1.Text, currentWord,buttons);
        }

        private void char_CLICK(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            buttonHandling.Add(new ButtonHandler(button));

            becomeUnable(button);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            reapirAble = true;

            foreach (var item in buttons)
            {
                item.currentButton.BackColor = Color.Blue;
                item.currentButton.Enabled = true;
            }

            //Check how many words the user wants.
            if (!radiobtn2.Checked && !radiobtn3.Checked)
            {
                currentWord = words[r.Next(1, words.Count)];

                int gapCount = currentWord.Length;

                makeButtonsVisible(gapCount, buttons);
                functions.fillTheGap(currentWord, gapCount, buttons);

                radiobtnHide(radiobtn2);
                radiobtnHide(radiobtn3);
            }
            else if (radiobtn2.Checked)
            {
                int gapCount = 0;
                level = 2;

                for (int i = 0; i < level; i++)
                {
                    string word = words[r.Next(1, words.Count)];
                    gapCount += word.Length;
                    completedWords.Add(word);
                }

                radiobtnHide(radiobtn2);
                radiobtnHide(radiobtn3);

                makeButtonsVisible(gapCount, buttons);
                functions.fillMoreGap(completedWords, buttons, level, gapCount);

            }
            else
            {
                int gapCount = 0;
                level = 3;

                for (int i = 0; i < level; i++)
                {
                    string word = words[r.Next(1, words.Count)];
                    gapCount += word.Length;
                    completedWords.Add(word);
                }

                radiobtnHide(radiobtn2);
                radiobtnHide(radiobtn3);

                makeButtonsVisible(gapCount, buttons);
                functions.fillMoreGap(completedWords, buttons, level, gapCount);
            }
        }
    }
}
