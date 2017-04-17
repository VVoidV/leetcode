using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Palindrome_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            s.IsPalindrome(1001);
        }
    }
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || x != 0 && x % 10 == 0)
            {
                return false;
            }
            int reversedNum = 0;
            while (x > reversedNum)
            {
                reversedNum = reversedNum * 10 + x % 10;
                x = x / 10;
            }
            return (x == reversedNum) || (x == reversedNum / 10);

        }
    }
}
