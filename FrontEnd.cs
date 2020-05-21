using System;
using System.Collections.Generic;

namespace JurassicPark
{
    class FrontEnd
    {
        private DinoController OurDinoController;

        public FrontEnd(DinoController dinoControllerTouse)
        {
            OurDinoController = dinoControllerTouse;
        }

        public string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        public int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Please enter a number.");
                return 0;
            }
        }

        public void Greeting()
        {
            Console.WriteLine($"Welcome to Jurassic Park");
        }

        public void Menu()
        {
            var userHasChosenToQuit = false;

            while (userHasChosenToQuit == false)
            {
                Console.WriteLine("Please choose one of the options below:");
                Console.WriteLine("(V)iew all of the Dinosaurs");
                Console.WriteLine("(A)dd a new dinosaur");
                Console.WriteLine("(R)emove a dinosaur");
                Console.WriteLine("(T)ransfer a dinosaur");
                Console.WriteLine("(S)ummarize the herbivores and carnivores");
                Console.WriteLine("(Q)uit");

                var choice = PromptForString("I want to:  ");

                switch (choice)
                {
                    case "V":
                        var dinos = OurDinoController.AllDinos();

                        foreach (var dino in dinos)
                        {
                            var description = dino.Description();
                            Console.WriteLine(description);
                        }

                        break;

                    case "A":
                        var dinoNameForNewDino = PromptForString("Name: ");
                        var newAcquiredDate = PromptForString("Acquired:  ");
                        var newDietType = PromptForString("Diet type:  ");
                        var newWeight = PromptForString("Weight:  ");
                        var newEnclosureNumber = PromptForString("EnclosureNumber:  ");

                        OurDinoController.AddNewDino(dinoNameForNewDino, newAcquiredDate, newDietType, newWeight, newEnclosureNumber);

                        break;

                    case "R":
                        var nameOfDinoToFind = PromptForString("Which dino would you like to remove?:  ");

                        var foundDino = OurDinoController.FindDinoByName(nameOfDinoToFind);
                        if (foundDino == null)
                        {
                            Console.WriteLine($"We don't have a dino named {nameOfDinoToFind}");
                        }
                        else
                        {
                            var foundDinoDescription = foundDino.Description();
                            Console.WriteLine(foundDinoDescription);

                            var shouldWeRemove = PromptForString("Are you sure that you want to remove this dino from the database? (Y/N):  ");
                            if (shouldWeRemove == "Y")
                            {
                                OurDinoController.Remove(foundDino);
                            }
                        }

                        break;

                    case "T":
                        var nameOfDinoToTransfer = PromptForString("Which dino would you like to transfer?:  ");

                        var dinoToTransfer = OurDinoController.FindDinoByName(nameOfDinoToTransfer);
                        if (dinoToTransfer == null)
                        {
                            Console.WriteLine($"We don't have a dino named {nameOfDinoToTransfer}");
                        }
                        else
                        {
                            var foundDinoDescription = dinoToTransfer.Description();
                            Console.WriteLine(foundDinoDescription);

                            var newDinoEnclosureNumber = PromptForString("New Enclosure Number: ");

                            OurDinoController.Transfer(dinoToTransfer, newDinoEnclosureNumber);
                        }

                        break;

                    case "Q":
                        userHasChosenToQuit = true;
                        break;
                }
            }
        }

    }
}
