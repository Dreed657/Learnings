namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public CommandInterpreter()
        {

        }

        public string Read(string args)
        {
            var tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var commandName = tokens[0] + COMMAND_POSTFIX;
            var commandArgs = tokens.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            var classType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (classType == null) throw new ArgumentException("Invalid agrs on input!");

            var classInstance = (ICommand)Activator.CreateInstance(classType);

            return classInstance.Execute(commandArgs);
        }
    }
}
