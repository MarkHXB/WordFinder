using System;
using System.Collections.Generic;

namespace buttonIndexer
{
    public class functions
    {
        public static void fillTheGap(string currentWord, int gapCount,List<ListHandling>buttonList)
        {
            char[] letterList = currentWord.ToCharArray();
            bool[] avaliableGap = new bool[gapCount];
            for (int i = 0; i < gapCount; i++)
            {
                avaliableGap[i] = true;
            }

            bool van = true;
            int helyek = 0;
            while (van != false || helyek != gapCount)
            {
                Random r = new Random();

                int currentRandom = r.Next(0, gapCount);

                if (avaliableGap[currentRandom])
                {
                    
                    char currentLetter = letterList[currentRandom];
                    buttonList[helyek].currentButton.Text = Convert.ToString(currentLetter);
                    avaliableGap[currentRandom] = false;
                    helyek++;
                }
                if (helyek >= gapCount)
                    van = false;
            }
        }
        public static void fillMoreGap(List<string> completeWords, List<ListHandling> buttonList,int level,int spaces)
        {
            bool[] avaliableGap = new bool[spaces];
            for (int i = 0; i < spaces; i++)
            {
                avaliableGap[i] = true;
            }

            int helyek = 0;
            int gapCount = 0;
            char[] letters = new char[spaces];
            string w = "";

            foreach (var item in completeWords)
            {
                gapCount += item.Length;
                w += item;
            }

            letters = w.ToCharArray();
            bool van = true;

             while (van != false)
             {
                    Random r = new Random();

                    int random = r.Next(0, spaces);

                if (avaliableGap[random])
                {
                        char currentLetter = letters[random];
                        buttonList[helyek].currentButton.Text = Convert.ToString(currentLetter);
                        avaliableGap[random] = false;
                        helyek++;
                }

                if (helyek >= spaces)
                {
                    van = false;
                }
             }
        }
    }
}
