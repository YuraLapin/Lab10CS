using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Main
{
    public class Train : Transport
    {
        public int cars;

        public Train() : base()
        {
            cars = 0;
        }

        public Train(in string name, in int maxSpeed, in int cars) : base(name, maxSpeed)
        {
            this.cars = cars;
        }

        new public void RandomInit()
        {           
            int maxCars = 9;
            cars = Program.rand.Next(maxCars);
        }

        public override string ToString()
        {
            return name.ToString() + ": power - " + power.ToString() + ", cars - " + cars.ToString();
        }

        public string ConvertToStringNonVirtual()
        {
            return name.ToString() + ": power - " + power.ToString() + ", cars - " + cars.ToString();
        }
    }
}