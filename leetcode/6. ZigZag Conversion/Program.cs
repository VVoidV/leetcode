using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ZigZag_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.Convert("AB", 1));
        }
    }

    public class Solution
    {

        public string Convert(string s, int numRows)
        {
            string[] output;
            bool isDown;
            int curRow;
            if (numRows<=1)
            {
                return s;
            }
            output = new string[numRows];
            isDown = true;
            curRow = 0;
            for (int i = 0; i < s.Length; i++)
            {
                output[curRow] += s[i];
                curRow = isDown ? ++curRow : --curRow;
                if (curRow == 0 || curRow == numRows - 1)
                    isDown = !isDown;
            }
            return string.Concat(output);
        }
    }
}
