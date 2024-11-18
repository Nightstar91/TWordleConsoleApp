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
        // Declaring class variable
        private Player player;
        private Word word;

        private bool isAnswerCorrect;
        private bool validAnswer;

        private string userInput;

        private int indexForHint;
        private char[] gameWordArray;
        private char[] playerWordArray;

        public Wordle(string _playerName)
        {
            // Calling the constuctor for the player class and word class
            player = new Player(_playerName);
            word = new Word();

            // Converting mystery word into a char array for analyze
            gameWordArray = word.mysteryWord.ToCharArray();
        }



        public void StartGame()
        {
            // checking to see if player still have any attempt (start at 6 attempt)
            while(player.attempt > 0)
            {
                // For formatting
                ClearConsole();

                // Start the round
                RoundFramework();

                // Checking to see if the player win so we can break out of the loop early
                if (isAnswerCorrect)
                    // Set the player attempt to break out of the loop
                    player.attempt = 0;

                else
                    // Player didn't answer correctly, must keep playing
                    player.DecreaseAttempt();
            }

            ClearConsole();
            WriteMessage(DisplayEndScreen(isAnswerCorrect));
            Pause();
        }


        // Main framework for each round of Wordle
        public void RoundFramework()
        {
            userInput = "";
            validAnswer = false;

            while(validAnswer != true)
            {
                // For formatting
                ClearConsole();

                // Giving player hint for round 2 and round 4
                if (player.attempt == 4 || player.attempt == 2)
                {
                    WriteMessage(GiveHint(gameWordArray), ConsoleColor.Yellow);
                }

                // Prompting the user for an answer
                WriteMessage("Guess the mysterious FIVE letter word\n", ConsoleColor.Yellow);
                userInput = Console.ReadLine();


                // Check to see if the user inputted a five letter answer
                if(userInput.Length == 5)
                {
                    // For Formatting
                    ClearConsole();

                    // Prompting the user on inputting a valid response
                    WriteMessage($"You have inputted {userInput}, let see if you are correct.\n");
                    Pause();

                    userInput = userInput.ToLower();

                    // Convert the player word into a char array
                    playerWordArray = userInput.ToCharArray();

                    // Setting the boolean to true break out of the validation loop
                    validAnswer = true;
                }
                else
                {
                    // Prompting the user for an invalid response and instructing them on what is valid
                    WriteMessage($"You have inputted a word that IS NOT FIVE LETTER LONG\nPlease input a five letter word this time!\n", ConsoleColor.Red);
                    Pause();

                    // Keeping the boolean false until the user input a valid response
                    validAnswer = false;
                }
            }

            // Checking to see if the user correctly guess the word
            isAnswerCorrect = CompareWord(word, userInput);

            // For formatting
            ClearConsole();

            // Selection structure to determine if the player correctly guess the word
            if(isAnswerCorrect)
            {
                // Displaying that the user has answered correctly
                WriteMessage($"You have correctly guess the word!\nIt was {word.mysteryWord}!\n", ConsoleColor.Green);
                Pause();
            }
            else
            {
                // Displaying that the user has answered incorrectly 
                WriteMessage($"INCORRECT! it was not {userInput}!\nYou still have {player.attempt - 1} attempt left!\n\n");

                AnalyzeWordToWord(playerWordArray, gameWordArray);

                // Display which character was correctly in position 
                Pause();
            }
        }


        // Method use for a comparison test
        public bool CompareWord(Word hiddenWord, string playerWord)
        {
            // Normalizing the data so it can go through the comparison test
            if (hiddenWord.mysteryWord.ToLower() == playerWord.ToLower())
            {
                // Player correctly guess the word
                return true;
            }
            else
            {
                // Player incorrectly guess the word
                return false;
            }
        }


        public void AnalyzeWordToWord(char[] playerWord, char[] gameWord)
        {

            // Scanning through the player array to analyze
            for(int i = 0; i < playerWord.Length; i++)
            {
                // Checking to see if the letter in the same index are completely identical (appear green)
                if (gameWord[i] == playerWord[i])
                {
                    WriteCharacter($"[{playerWord[i]}] ", ConsoleColor.Green);
                }
                // Otherwise the letter is not in the correct position (appear red)
                else
                {
                    WriteCharacter($"[{playerWord[i]}] ", ConsoleColor.Red);
                }

            }
        }

        public string GiveHint(char[] word)
        {
            indexForHint = Word.GetSomeRandomNumber(0, 4);

            return $"[HINT] The word contain the letter [{word[indexForHint]}]\n\n";
        }


        public string DisplayEndScreen(bool didPlayerWin)
        {
            if (didPlayerWin)
                return $"Congratulation {player.name}, YOU WON";

            else
                return $"YOU LOSE, the word was {word.mysteryWord}. Better luck next time {player.name}";

        }
    }
}
