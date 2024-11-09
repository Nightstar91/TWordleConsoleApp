using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TWordleConsoleApp.Library;

namespace TWordleConsoleApp
{
    public class Menu
    {
        public string userInput;
        private bool nameValidation;

        public void StartScreen()
        {
            userInput = "";
            nameValidation = false;

            while(nameValidation != true)
            {
                // Prompt the user
                WriteMessage("Please enter a name ");

                // Storing what the user typed
                userInput = Console.ReadLine();

                if (userInput != "")
                {
                    // Prompt the user they enter a valid response
                    WriteMessage($"Hello there {userInput}, Welcome to Wordle!");
                    Pause();
                    nameValidation = true;

                }
                else
                {
                    WriteMessage("Please enter something into the prompt!");
                    Pause();
                }
            }

            
        }
    }
}
