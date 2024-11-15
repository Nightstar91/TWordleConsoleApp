using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWordleConsoleApp
{
    public class Word
    {
        public string? mysteryWord;
        public List<string> listOfWords = new List<string>();

        private static Random random = new Random(); // Random number generator code excerpt by Jorge Candeias [https://outcompute.com/2014/12/02/why-are-my-csharp-numbers-not-random/]
        public Word() 
        {
            // Initializing list of word
            listOfWords.Add("noted");
            listOfWords.Add("there");
            listOfWords.Add("store");
            listOfWords.Add("faith");
            listOfWords.Add("grass");
            listOfWords.Add("motor");
            listOfWords.Add("times");
            listOfWords.Add("third");
            listOfWords.Add("video");
            listOfWords.Add("japan");
            listOfWords.Add("adult");
            listOfWords.Add("newly");
            listOfWords.Add("eight");
            listOfWords.Add("queen");
            listOfWords.Add("tower");
            listOfWords.Add("taxes");
            listOfWords.Add("among");
            listOfWords.Add("smart");
            listOfWords.Add("refer");
            listOfWords.Add("field");

            // Set the mystery word
            mysteryWord = PickRandomWord();
        }

        // Random number generator code excerpt by Jorge Candeias [https://outcompute.com/2014/12/02/why-are-my-csharp-numbers-not-random/]
        public static int GetSomeRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }


        public string PickRandomWord()
        {
            return listOfWords[GetSomeRandomNumber(0,listOfWords.Count - 1)];
        }
    }
}
