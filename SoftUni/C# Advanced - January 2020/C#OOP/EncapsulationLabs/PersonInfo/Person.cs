namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string fName, string lName, int age, decimal salary)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get { return this.firstName; } 
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                this.firstName = value;
            } 
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value == 0 || value < 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary 
        {
            get { return this.salary; }
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            var deliter = 0;

            if (this.Age < 30) deliter = 200;
            else deliter = 100;

            this.Salary += this.Salary * (percentage / deliter);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
    }
}
