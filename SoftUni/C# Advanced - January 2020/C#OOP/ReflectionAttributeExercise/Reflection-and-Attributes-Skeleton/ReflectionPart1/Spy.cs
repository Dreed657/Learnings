namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string type, params string[] requestedFields)
        {
            var classType = Assembly.GetCallingAssembly().GetType(type);
            
            FieldInfo[] classFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            var sb = new StringBuilder();

            var classInstance = Activator.CreateInstance(classType);

            sb.AppendLine($"Class under investigation: {type}");

            foreach (FieldInfo item in classFields.Where(x => requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string type)
        {
            var classType = Assembly.GetCallingAssembly().GetType(type);

            var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            var getters = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var setters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            
            var sb = new StringBuilder();

            foreach (var item in fields) sb.AppendLine($"{item.Name} must be private!");
            foreach (var item in getters.Where(g => g.Name.StartsWith("get"))) sb.AppendLine($"{item.Name} must be public!");
            foreach (var item in setters.Where(g => g.Name.StartsWith("set"))) sb.AppendLine($"{item.Name} must be private!");

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string type)
        {
            var classType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            
            var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {type}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var item in methods)
            {
                sb.AppendLine($"{item.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
