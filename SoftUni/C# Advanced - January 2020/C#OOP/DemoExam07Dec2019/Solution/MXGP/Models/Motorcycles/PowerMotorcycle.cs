namespace MXGP.Models.Motorcycles
{
    using System;

    using MXGP.Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private const double INIT_CUBICMITERS = 450;
        private const int MIN_HP = 70;
        private const int MAX_HP = 100;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, INIT_CUBICMITERS, MIN_HP, MAX_HP)
        {
        }
    }
}
