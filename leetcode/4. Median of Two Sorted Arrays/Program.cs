
//here are two sorted arrays nums1 and nums2 of size m and n respectively.

//Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).

//Example 1:
//nums1 = [1, 3]
//nums2 = [2]

//The median is 2.0
//Example 2:
//nums1 = [1, 2]
//nums2 = [3, 4]

//The median is (2 + 3)/2 = 2.5

using System;

namespace _4.Median_of_Two_Sorted_Arrays
{
    public class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i, j, iMin, iMax, m, n;
            double leftMax, rightMin;
            int[] A, B;

            if (nums1.Length > nums2.Length)
            {
                A = nums2;
                B = nums1;
                n = nums1.Length;
                m = nums2.Length;
            }
            else
            {
                A = nums1;
                B = nums2;
                m = nums1.Length;
                n = nums2.Length;
            }

            iMin = 0;
            iMax = m;

            while (iMin <= iMax)
            {
                i = (iMin + iMax) / 2;
                j = (m + n + 1) / 2 - i;
                if (i > 0 && j < n && A[i - 1] > B[j])
                {//A[i-1]太大，i要减小
                    iMax = i - 1;
                }
                else if (j > 0 && i < m && B[j - 1] > A[i])
                {//B[j-1]太大，j要左移，i要增大
                    iMin = i + 1;
                }
                else
                {
                    if (i == 0)
                    {
                        leftMax = B[j - 1];
                    }
                    else if (j == 0)
                    {
                        leftMax = A[i - 1];
                    }
                    else
                    {
                        leftMax = Math.Max(A[i - 1], B[j - 1]);
                    }

                    if ((m + n) % 2 != 0)
                    {
                        return leftMax;
                    }

                    if (i == m)
                    {
                        rightMin = B[j];
                    }
                    else if (j == n)
                    {
                        rightMin = A[i];
                    }
                    else
                    {
                        rightMin = Math.Min(A[i], B[j]);
                    }
                    return (leftMax + rightMin) / 2.0;
                }

            }
            throw new ArgumentException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 3 };
            int[] B = { 2 };
            Solution.FindMedianSortedArrays(A, B);
        }
    }
}
