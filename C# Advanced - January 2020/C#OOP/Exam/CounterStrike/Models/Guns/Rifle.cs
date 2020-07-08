namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int FIRE_AMOUNT = 10;

        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            bool canFire = this.BulletsCount >= FIRE_AMOUNT;

            if (canFire)
            {
                this.BulletsCount -= FIRE_AMOUNT;
                return FIRE_AMOUNT;
            }
            else
            {
                return 0;
            }
        }
    }
}
