using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool result = PasswordValidator(password);

            if (result) Console.WriteLine("Password is valid");
        }

        public static bool PasswordValidator(string password)
        {
            bool result = true;

            if (!PasswordLength(password)) result = false;
            if (!PasswordLetters(password)) result = false; 
            if (PasswordDigits(password) < 2) result = false;
           
            return result;
        }

        public static bool PasswordLength(string password)
        {
            int length = password.Length;
            if (!(length >= 6 && length <= 10)) {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
            else return true;
        }

        public static bool PasswordLetters(string password)
        {
            bool result = true;

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i])) result = false;
            }

            if (!result) Console.WriteLine("Password must consist only of letters and digits");
           
            return result;
        }

        public static int PasswordDigits(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
                if (char.IsDigit(password[i])) count++;

            if (count < 2) Console.WriteLine("Password must have at least 2 digits");

            return count;
        }
    }
}
