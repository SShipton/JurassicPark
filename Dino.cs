namespace JurassicPark
{
    class Dino
    {
        public string Name { get; set; }

        public string DietType { get; set; }

        public string AcquiredDate { get; set; }

        public int Weight { get; set; }

        public int EnclosureNumber { get; set; }

        public string Description()
        {
            var premadeDescription = ($"{Name} is a {DietType} Dinosaur, weighing in at {Weight} pounds and acquired on {AcquiredDate}. Currently residing in Enclosure {EnclosureNumber}");

            return premadeDescription;
        }

    }

}