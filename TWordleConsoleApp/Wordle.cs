using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TWordleConsoleApp.Library;

namespace TWordleConsoleApp
{
    public class Wordle
    {
        private Player player;
        private Word word;
        private bool isAnswerCorrect;
        private bool validAnswer;


        public Wordle(string _playerName)
        {
            // Calling the constuctor for the player class 
            player = new Player(_playerName);

            word = new Word();
        }

        public void StartGame()
        {

        }

        public void RoundFramework()
        {

        }


        public bool CompareWord(Word hiddenWord, string playerWord)
        {
            return true;
        }

        public string DisplayEndScreen(Word hiddenWord, bool didPlayerWin)
        {
            if (didPlayerWin)
                return "YOU WON";

            else
                return "YOU LOSE";

        }

        public void Test()
        {
            TestInfo();
            TestInfo();
            TestInfo();
            TestInfo();
            TestInfo();
            TestInfo();

            player.ResetAttempt();
            TestInfo();

            WriteMessage($"mystery word is {word.mysteryWord}!");
            Pause();
            ClearConsole();
        }

        public void TestInfo()
        {
            WriteMessage($"HELLO THERE {player.name}, you have {player.attempt} attempt left!");
            player.DecreaseAttempt();
            Pause();
            ClearConsole();
        }
    }
}
