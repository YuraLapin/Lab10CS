using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Main
{
    public class SortByName: IComparer<object>
    {
        public int Compare(object obj1, object obj2)
        {
            return string.Compare(((Person)obj1).name, ((Person)obj2).name);
        }
    }
}
