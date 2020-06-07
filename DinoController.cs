using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class DinoController
    {
        private List<Dino> Dinos = new List<Dino>();

        public object Log { get; private set; }

        public IEnumerable<Dino> AllDinos()
        {
            Log.Add("List of dinos");
            return Dinos.OrderBy(dino => dino.AcquiredDate);
        }

        public Dino FindDinoByName(string name)
        {
            Log.Add($"Someone looked for a dino named {name}");
            var foundDino = Dinos.FirstOrDefault(dino => dino.Name == dino);

            return foundDino;
        }

        public void Remove(Dino dinoToRemove)
        {
            Log.Add($"Someone removed a dino named {dinoToRemove.Name}");

            Dinos.Remove(dinoToRemove);
        }

        public void Transfer(Dino dinoToTransfer, string enclosureNumber)
        {
            Log.Add($"Someone transferred a dino named {dinoToTransfer} to {enclosureNumber}");

            dinoToTransfer.EnclosureNumber = enclosureNumber;
        }

        public void AddNewDino(string name, DateTime acquiredDate, string dietType, int weight, int enclosureNumber)
        {
            Log.Add($"Someone added a dino named {name}");

            var newDino = new Dino
            {
                Name = name,
                AcquiredDate = acquiredDate,
                DietType = dietType,
                Weight = weight,
                EnclosureNumber = enclosureNumber,
            };

            Dinos.Add(newDino);
        }
        public void DateTime(Dino acquiredDate, DateTime AcquiredDate)
        {
            DateTime acquiredDate = new DateTime();
            string acquiredDateAsString = acquiredDate.ToString();
        }

        public void PrintLog()
        {
            foreach (var log in Log)
            {
                Console.WriteLine(log);
            }
        }

        public void Seed()
        {
            var blue = new Dino
            {
                Name = "Blue",
                DietType = "Carnivore",
                AcquiredDate = "02.26.2012",
                Weight = 33,
                EnclosureNumber = 042,
            };

            var rexy = new Dino
            {
                Name = "Rexy",
                DietType = "Carnivore",
                AcquiredDate = "05.21.1988",
                Weight = 31000,
                EnclosureNumber = 101,
            };

            var meatball = new Dino
            {
                Name = "Meatball",
                DietType = "Herbivore",
                AcquiredDate = "09.16.2014",
                Weight = 600,
                EnclosureNumber = 004,
            };

            Dinos.Add(blue);
            Dinos.Add(rexy);
            Dinos.Add(meatball);
        }

        internal void AddNewDino(string dinoNameForNewDino, string newAcquiredDate, string newDietType, string newWeight, string newEnclosureNumber)
        {
            throw new NotImplementedException();
        }
    }
}
