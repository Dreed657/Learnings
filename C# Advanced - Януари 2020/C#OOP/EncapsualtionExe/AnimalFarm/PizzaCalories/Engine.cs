using System;

namespace PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            var PizzaInit = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var DoughInit = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var Dough = new Dough(DoughInit[1], DoughInit[2], double.Parse(DoughInit[3]));
                var Pizza = new Pizza(PizzaInit[1], Dough);

                while (true)
                {
                    var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0].ToUpper() == "END") break;

                    var topping = new Topping(tokens[1], double.Parse(tokens[2]));
                    Pizza.AddTopping(topping);
                }

                Console.WriteLine(Pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
