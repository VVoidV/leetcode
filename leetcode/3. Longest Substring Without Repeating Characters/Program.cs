using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Longest_Substring_Without_Repeating_Characters
{
    public static class Solution
    {
        public static int LengthOfLongestSubstring(string s)
        {//naive very slow.....
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= (s.Length - i > 256 ? 256 : s.Length - i); j++)
                {
                    string search = s.Substring(i, j);
                    HashSet<char> map = new HashSet<char>();
                    int count = 0;
                    foreach (char ch in search)
                    {

                        if (map.Contains(ch))
                        {
                            break;
                        }
                        map.Add(ch);
                        count++;
                    }
                    if (count > maxLength)
                    {
                        maxLength = count;
                    }
                }
            }
            return maxLength;
        }
        public static int LengthOfLongestSubstring2(string s)
        {
            //maxLength 保存搜索到第i个字符之前最长的子串长度，dict保存每个字符在第s[i]之前的最后一次出现位置，start表示子串的起始位置
            int maxLength = 0;
            int start = -1;
            char[] chArr = s.ToCharArray();
            List<int> dict = new List<int>();
            dict.AddRange(Enumerable.Repeat(-1, 255));
            for (int i = 0; i != s.Length; i++)
            {
                if (dict[chArr[i]] > start)
                {//这时出现重复字符，子串要重新开始
                    start = dict[chArr[i]];
                }
                dict[chArr[i]] = i;
                maxLength = Math.Max(maxLength, i - start);
            }
            return maxLength;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution.LengthOfLongestSubstring2("abcadefab");
        }
    }
}
