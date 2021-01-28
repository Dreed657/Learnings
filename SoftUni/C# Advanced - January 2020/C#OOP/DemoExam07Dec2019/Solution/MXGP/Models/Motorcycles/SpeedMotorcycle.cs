namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double INIT_CUBICMITERS = 125;
        private const int MIN_HP = 50;
        private const int MAX_HP = 69;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, INIT_CUBICMITERS, MIN_HP, MAX_HP)
        {
        }
    }
}
