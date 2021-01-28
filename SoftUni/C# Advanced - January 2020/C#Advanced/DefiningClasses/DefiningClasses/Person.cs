using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string _name;

		private int _age;

		public string Name
		{
			get { return this._name; }
			set {  this._name = value; }
		}

		public int Age
		{
			get { return this._age; }
			set { this._age = value; }
		} 

		public Person()
		{
			this.Name = "No name";
			this.Age = 1;
		}

		public Person(int age)
			: this()
		{
			this.Age = age;
		}

		public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;
		}

		public override string ToString()
		{
			return $"{this.Name} - {this.Age}";
		}
	}
}
