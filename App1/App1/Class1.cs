using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Class1
    {
        public static int Search(List<int> c, int s)
        {
            int min = 0;
            int max = c.Count - 1;
            int value = -1;

            List<int> copy = new List<int>(c);

            c.Sort();            
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (s == c[mid])
                {
                    value = copy.IndexOf(s);
                    break;
                }
                else if (s < c[mid])
                {
                    max = mid - 1;
                }
                else 
                {
                    min = mid + 1;
                }
            }
            
            return value;
        }
    }
}
