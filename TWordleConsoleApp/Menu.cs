using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static TWordleConsoleApp.Library;

namespace TWordleConsoleApp
{
    public class Menu
    {
        public string? playerName;
        public string userInput;
        private Wordle wordleGame;
        private bool nameValidation;

        public void StartScreen()
        {
            userInput = "";
            nameValidation = false;

            while(nameValidation != true)
            {
                // Prompt the user
                WriteMessage("Please enter a name:");

                // Storing what the user typed
                userInput = Console.ReadLine();

                // For formatting
                ClearConsole();

                if (userInput != "")
                {
                    // Prompt the user they enter a valid response
                    WriteMessage($"Hello there {userInput}, Welcome to Wordle!");
                    playerName = userInput;
                    Pause();
                    ClearConsole();
                    nameValidation = true;

                }
                else
                {
                    WriteMessage("Please enter something into the prompt!");
                    Pause();
                    ClearConsole();
                }
            }
            // Enter the menu
            MenuScreen();
        }


        public void MenuScreen()
        {
            userInput = "";

            while(userInput != "3")
            {
                // For formatting
                ClearConsole();

                // Prompt the user
                WriteMessage("Please type in the following option...\n", ConsoleColor.Yellow);
                WriteMessage("1. Play The Game\n2. Instruction\n3. Quit Game");

                // Storing what the user typed
                userInput = Console.ReadLine();

                // For formatting
                ClearConsole();

                switch(userInput)
                {
                    case "1":
                        //Play game and bring the player object into the game class
                        wordleGame = new Wordle(playerName);
                        wordleGame.Test();
                        break;

                    case "2":
                        WriteMessage("The goal is to guess a five letter word with only 6 attempt.\nEach time you correctly guess a letter in its position, the letter will be appear green.\nIf you correctly guess a letter that is in the word but in the wrong position, the letter will appear yellow.");
                        Pause();
                        break;

                    case "3":
                        WriteMessage("You have chosen to leave, goodbye!\n");
                        Pause();
                        break;

                    default:
                        WriteMessage("Please enter a valid response\n", ConsoleColor.Yellow);
                        Pause();
                        break;
                }

            }
        }
    }
}
