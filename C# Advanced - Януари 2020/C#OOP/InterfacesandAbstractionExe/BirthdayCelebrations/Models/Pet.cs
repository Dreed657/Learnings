namespace BirthdayCelebrations.Models
{
    using System;

    using BirthdayCelebrations.Contracts;
    
    public class Pet : IPet, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Name { get; set; }

        public DateTime Birthdate { get; private set; }
    }
}
