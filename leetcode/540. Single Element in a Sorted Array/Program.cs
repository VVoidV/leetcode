using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _540.Single_Element_in_a_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            Console.WriteLine(s.SingleNonDuplicate(new int[] { 1,2,2,3,3,4,4,5,5,6,6 }));
        }
    }
    public class Solution
    {
        private int index;//划分点
        private int length;//目前处理的数组长度
        public int SingleNonDuplicate(int[] nums)
        {
            length = nums.Length;
            index = length / 2;
            while (length > 1)
            {
                if ((length + 1) / 2 % 2 == 0)
                {//划分点左右有奇数个数字，如果划分点不是单独数字，那么必然和两个相邻的数字有一个相同，
                 //比如右边相邻数字和划分点相同（1123344），那么去除这个相同数字，右边就有偶数个数字，
                 //若单独数字在右边，则去除这个单独数字，右边有奇数个数字两两相同，这显然不可能，所以单独数字在左边
                    if (nums[index] == nums[index - 1])
                    {//和左边相同，那么单独数字在右边
                        index = index + (length / 2 + 1) / 2;
                    }
                    else
                    {
                        index = index - (length / 2 + 1) / 2;
                    }
                }
                else
                {//index左右为偶数个数字，如果index所指的数字和左边相邻的数字相等，则单个数字必然在左边
                 //如果和右边的数字相同，则单独的数字在右边部分，如果都不相同，那么这个数字就是单独的。
                    if (nums[index] != nums[index - 1] && nums[index] != nums[index + 1])
                    {
                        break;
                    }
                    else if (nums[index] == nums[index - 1])
                    {
                        index = index - length / 4;
                    }
                    else
                    {
                        index = index + length / 4;
                    }
                }
                length = (length / 2 % 2) == 0 ? length / 2 + 1 : length / 2;//保持奇数长度
            }

            return nums[index];
        }
    }
}
