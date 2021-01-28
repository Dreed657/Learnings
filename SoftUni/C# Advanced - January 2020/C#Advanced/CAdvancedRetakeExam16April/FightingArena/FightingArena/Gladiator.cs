using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public int GetTotalPower()
        {
            return Stat.Power() + Weapon.Power();
        }

        public int GetWeaponPower()
        {
            return Weapon.Power();
        }

        public int GetStatPower()
        {
            return Stat.Power();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            sb.AppendLine($"Weapon Power: {this.GetWeaponPower()}");
            sb.AppendLine($"Stat Power: {this.GetStatPower()}");

            return sb.ToString();
        }
    }
}
