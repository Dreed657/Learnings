namespace CommandPattern.Core.Models.Commands
{
    using CommandPattern.Core.Contracts;

    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var sum = 0;

            foreach (var item in args)
            {
                sum += int.Parse(item);
            }

            return sum.ToString();
        }
    }
}
