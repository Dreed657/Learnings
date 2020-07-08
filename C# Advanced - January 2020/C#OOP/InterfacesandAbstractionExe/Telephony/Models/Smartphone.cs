namespace Telephony
{
    using System.Linq;

    using Telephony.Exceptions;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
    }
}
