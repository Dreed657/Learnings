﻿using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            
        }

        public override int Age 
        { 
            get
            {
                return this.Age;
            }
            protected set
            {
                if (value <= 15)
                {
                    base.Age = value;
                }
            }
        }
    }
}
