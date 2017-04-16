using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.String_to_Integer__atoi_
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            string sInt = "1";
            int res;
            int.TryParse(sInt, out res);
            if (s.MyAtoi(sInt) == res)
            {
                Console.WriteLine("OK");
            }

        }
    }

    public class Solution
    {
        /// <summary>
        /// 将字符串str转换为Int32返回，str为空时返回0，ArgumentOutOfRangeException
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>str转换成整数后的Int32</returns>
        public int MyAtoi(string str)
        {
            if (str==null||str==string.Empty)
                return 0;
            bool isNegative = false;
            int cursor = 0;
            Int64 result = 0;
            for (;cursor<str.Length;cursor++)
            {
                if (str[cursor] != ' ')
                    break;
            }


            if (str[cursor] == '-')
            {
                isNegative = true;
                cursor++;
            }
            else if (str[cursor] == '+')
            {
                cursor++;
            }
            for (; cursor < str.Length; cursor++)
            {
                if (str[cursor] < '0' || str[cursor] > '9')
                {
                    break;
                }
                result = result * 10 + (str[cursor] - '0');
                if (!isNegative&&result>int.MaxValue)
                {
                    return int.MaxValue;
                }
                else if(isNegative&&-result<int.MinValue)
                {
                    return int.MinValue;
                }
            }
            if (isNegative)
            {
                result = -result;

            }
            return (int)result;
        }
    }
}
