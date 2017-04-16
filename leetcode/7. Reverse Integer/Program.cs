using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Reverse_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            Console.WriteLine(s.Reverse2(int.MaxValue));
        }
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            char[] chArr = x.ToString().TrimStart('-').ToCharArray();
            Array.Reverse(chArr);
            string s = new string(chArr);
            s.TrimStart('0');
            try
            {
                if (x < 0)
                {
                    return -(int.Parse(s));
                }
                return int.Parse(s);
            }
            catch (OverflowException)
            {
                return 0;
            }
        }

        public int Reverse2(int x)
        {
            Int64 res = 0;
            while (x != 0)
            {
                res = res * 10 + x % 10;
                x /= 10;
            }
            if (res>0)
                return res > int.MaxValue ? 0 : (int)res;
            else
                return res < int.MinValue ? 0 : (int)res;
        }
    }
}
