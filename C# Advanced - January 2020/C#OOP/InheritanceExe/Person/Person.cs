namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual int Age 
        {
            get { return this.age; }
            protected set
            {
                if (value > 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }
}
