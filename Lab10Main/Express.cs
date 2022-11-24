using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Main
{
    public class Express: Train
    {
        List<string> stationsToSkip;

        public Express(): base()
        {
            stationsToSkip = new List<string>();
        }

        public Express(in string name, in int maxSpeed, in int cars, in List<string> stationsToSkip): base(name, maxSpeed, cars)
        {
            this.stationsToSkip = stationsToSkip;
        }

        new public void RandomInit()
        {            
            int maxStations = 5;
            for (int i = 0; i < Program.rand.Next(maxStations); ++i)
            {
                stationsToSkip.Add("station" + i);
            }
        }

        public override string ConvertToString()
        {
            var sb = new StringBuilder();
            sb.Append(name.ToString() + ": power - " + power.ToString() + ", cars - " + cars.ToString() + ", list of stations to skip: [ ");
            if (stationsToSkip.Count > 0)
            {
                foreach (string s in stationsToSkip)
                {
                    sb.Append(s + ", ");
                }
                sb.Append("]");
            }
            else
            {
                sb.Append("- ]");
            }
            return sb.ToString();
        }

        public string ConvertToStringNonVirtual()
        {
            var sb = new StringBuilder();
            sb.Append(name.ToString() + ": power - " + power.ToString() + ", cars - " + cars.ToString() + ", list of stations to skip: [ ");
            if (stationsToSkip.Count > 0)
            {
                foreach (string s in stationsToSkip)
                {
                    sb.Append(s + ", ");
                }
                sb.Append("]");
            }
            else
            {
                sb.Append("- ]");
            }
            return sb.ToString();
        }
    }
}