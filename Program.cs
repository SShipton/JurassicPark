using System;
using System.Collections.Generic;

namespace JurassicPark
{
    class Program
    {
        static void Main(string[] args)
        {
            var dinoController = new DinoController();

            dinoController.Seed();

            var frontEnd = new FrontEnd(dinoController);

            frontEnd.Greeting();
            frontEnd.Menu();

            dinoController.PrintLog();
        }
    }
}
