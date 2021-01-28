namespace Telephony
{
    using System.Linq;

    using Telephony.Exceptions;

    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if(!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
