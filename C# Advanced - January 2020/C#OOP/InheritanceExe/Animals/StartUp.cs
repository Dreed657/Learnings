namespace Animals
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }
    }
}
