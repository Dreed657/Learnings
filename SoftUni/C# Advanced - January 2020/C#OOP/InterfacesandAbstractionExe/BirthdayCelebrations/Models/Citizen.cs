namespace BirthdayCelebrations.Models
{
    using System;

    using BirthdayCelebrations.Contracts;

    public class Citizen : ICitizen, INameble, IIdible, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
            this.Food = 0;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public DateTime Birthdate { get; private set; }
        
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
