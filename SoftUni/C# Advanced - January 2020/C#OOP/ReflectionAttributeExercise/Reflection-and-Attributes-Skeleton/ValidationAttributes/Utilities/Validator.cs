namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null) return false;

            var objType = obj.GetType();
            var properties = objType.GetProperties();

            foreach (var property in properties)
            {
                var attributs = property
                    .GetCustomAttributes()
                    .Where(c => c is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributs)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
