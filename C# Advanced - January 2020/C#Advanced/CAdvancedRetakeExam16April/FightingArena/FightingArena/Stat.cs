namespace FightingArena
{
    public class Stat
    {
        private int _strength;
        private int _flexibility;
        private int _agility;
        private int _skills;
        private int _intelligence;

        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public int Flexibility
        {
            get { return _flexibility; }
            set { _flexibility = value; }
        }

        public int Agility
        {
            get { return _agility; }
            set { _agility = value; }
        }

        public int Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }

        public Stat(int str, int flex, int agi, int skills, int intelect)
        {
            this.Strength = str;
            this.Flexibility = flex;
            this.Agility = agi;
            this.Skills = skills;
            this.Intelligence = intelect;
        }

        public int Power()
        {
            return this.Strength + this.Flexibility + this.Agility + this.Skills + this.Intelligence;
        }
    }
}
