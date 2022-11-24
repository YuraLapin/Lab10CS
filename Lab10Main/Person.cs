using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Main
{
    public class Person: IRandomInit, IComparable, ICloneable
    {
        public string name;
        public int age;
        public int height;

        public Person()
        {
            name = "";
            age = 0;
            height = 0;
        }

        public Person(in string name)
        {
            this.name = name;
            age = 0;
            height = 0;
        }

        public Person(in string name, in int age, in int height)
        {
            this.name = name;
            this.age = age;
            this.height = height;
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

            int maxAge = 200;
            age = Program.rand.Next(maxAge);

            int maxHeight = 300;
            height = Program.rand.Next(maxHeight);
        }

        public string ConvertToString()
        {
            return name + ": age - " + age + ", height - " + height;
        }

        public void Print()
        {
            Console.WriteLine(ConvertToString());
        }

        public static explicit operator Transport(Person obj)
        {
            return new Transport(obj.name, 0);
        }

        public static explicit operator Person(Transport obj)
        {
            return new Person(obj.name, 0, 0);
        }

        public int CompareTo(object obj)
        {
            return string.Compare(this.name, ((Person)obj).name);
        }

        public object Clone()
        {
            return new Person(name, age, height);
        }

        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}