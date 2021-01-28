using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        // FAMALE ONLY
        private const string DEFAULT_GENDER = "Famale";

        public Kitten(string name, int age)
            : base(name, age, DEFAULT_GENDER)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
