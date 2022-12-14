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
            int res = 0;
            if (obj1 is Transport t1)
            {
                if (obj2 is Transport t2)
                {
                    res = string.Compare(t1.name, t2.name);
                }
                if (obj2 is Person p2)
                {
                    res = string.Compare(t1.name, p2.name);
                }
            }   
            if (obj1 is Person p1)
            {
                if (obj2 is Transport t2)
                {
                    res = string.Compare(p1.name, t2.name);
                }
                if (obj2 is Person p2)
                {
                    res = string.Compare(p1.name, p2.name);
                }
            }
            return res;
        }
    }
}
