using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tyre> tires;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new List<Tyre>() { new Tyre(tire1Pressure, tire1Age), new Tyre(tire2Pressure, tire2Age), new Tyre(tire3Pressure, tire3age), new Tyre(tire4Pressure, tire4age) };
        }

        public int Add(params int[] args)
        {
            return args.ToList().Sum();
        }

        public string Model
        { 
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public Engine Engine
        { 
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }

        public Cargo Cargo
        {
            get
            {
                return this.cargo;
            }
            set
            {
                this.cargo = value;
            }
        }

        public List<Tyre> Tires
        {
            get
            {
                return this.tires;
            }
            set
            {
                this.tires = value;
            }
        }
    }
}
