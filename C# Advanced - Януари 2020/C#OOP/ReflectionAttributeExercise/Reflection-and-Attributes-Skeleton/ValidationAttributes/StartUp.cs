namespace ValidationAttributes
{
    using System;

    using ValidationAttributes.Utilities;
    using ValidationAttributes.Models;
    using ValidationAttributes.Attributes;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person(null, 15);

            var isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
