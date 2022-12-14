using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Main
{
    public class Transport: IRandomInit, IComparable
    {
        public string name;
        public int power;

        public Transport()
        {
            name = "";
            power = 0;
        }

        public Transport(in string name, in int maxSpeed)
        {
            this.name = name;
            this.power = maxSpeed;
        }

        public void RandomInit()
        {
            var sb = new StringBuilder();
            int nameSize = 5;
            string alphabet = "qwertyuiopasdfghjklzxcvbnm1234567890";
            for (int i = 0; i < nameSize; ++i)
            {
                sb.Append(alphabet[Program.rand.Next(alphabet.Length)]);
            }
            name = sb.ToString();

            int maxPower = 1000;
            power = Program.rand.Next(maxPower);
        }
        
        public override string ToString()
        {
            return name.ToString() + ": power - " + power.ToString();
        }

        public string ConvertToStringNonVirtual()
        {
            return name.ToString() + ": power - " + power.ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public static explicit operator Person(Transport obj)
        {
            return new Person(obj.name, 0, 0);
        }        

        public int CompareTo(object obj)
        {
            int res = 0;
            if (obj is Transport c) 
            {
                res = string.Compare(this.name, c.name);
            }
            if (obj is Person p)
            {
                res = string.Compare(this.name, p.name);
            }
            return res;    
        }
    }
}