//Given a sequence of n integers a1, a2, ..., an, a 132 pattern is a subsequence ai, aj, ak such that i<j < k and ai < ak < aj. Design an algorithm that takes a list of n numbers as input and checks whether there is a 132 pattern in the list.

//Note: n will be less than 15,000.

//Example 1:
//Input: [1, 2, 3, 4]

//Output: False

//Explanation: There is no 132 pattern in the sequence.
//Example 2:
//Input: [3, 1, 4, 2]

//Output: True

//Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
//Example 3:
//Input: [-1, 3, 2, 0]

//Output: True

//Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and[-1, 2, 0].


using System;
using System.Collections.Generic;

namespace _456._132_Pattern
{
    public class Solution
    {
        public static bool Find132pattern(int[] nums)
        {
            Stack<int> s = new Stack<int>();
            int s3 = int.MinValue;
            for (int i = nums.Length-1 ; i >= 0; i--)
            {
                if (nums[i]<s3)
                {
                    return true;
                }
                else
                {
                    while (s.Count != 0 && nums[i] > s.Peek()) 
                    {
                        s3 = s.Pop();//s3 总保存在当前nums[i]为132中的3时的最小的2.因此当游标往前，下一个数小于当前的s3时，就找到了132
                    }
                }
                s.Push(nums[i]);
            }
            return false;
        }

        public static void Main()
        {
            int[] a = { -1, 3, 2, 0 };
            Find132pattern(a);
        }
    }
}
