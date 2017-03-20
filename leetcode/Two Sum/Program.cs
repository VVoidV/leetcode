//Given an array of integers, return indices of the two numbers such that they add up to a specific target.

//You may assume that each input would have exactly one solution, and you may not use the same element twice.

//Example:
//Given nums = [2, 7, 11, 15], target = 9,

//Because nums[0] + nums[1] = 2 + 7 = 9,
//return [0, 1].
using System.Collections.Generic;
using System.Linq;


namespace Two_Sum
{
    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] ans = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++) 
                {
                    if (nums[i] + nums[j] == target)
                    {
                        ans[0] = i;
                        ans[1] = j;
                        return ans;
                    }

                }
            }
            return null;
        }

        public static int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int num2Find;
            int[] ans = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                num2Find = target - nums[i];
                if (dic.Keys.Contains(num2Find))
                {
                    ans[0] = i;
                    ans[1] = dic[num2Find];
                    return ans;
                }
                else
                {
                    if (!dic.Keys.Contains(nums[i]))
                    {
                        dic.Add(nums[i], i);
                    }
                    
                }
            }
            return null;
        }
        public static void Main()
        {
            int[] testCase = { 2, 7, 11, 15 };
            int[] ans= TwoSum2(testCase, 9);
            
        }
    }
}
