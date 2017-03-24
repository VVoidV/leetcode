using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Add_Two_Numbers
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ListNode cur = this;
            do
            {
                sb.Append(cur.val.ToString());
                cur = cur.next;
            } while (cur != null);
            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public static class Solve
    {
        //制杖方法.
        private static long getNum(ListNode list)
        {
            long result ;
            int _base = 10;
            long currentBase = _base;
            ListNode tList = list;
            result = tList.val;
            tList = tList.next;
            while (tList != null) 
            {
                result += tList.val * currentBase;
                currentBase *= _base;
                tList = tList.next;
            }
            return result;
        }
        public  static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ans = new ListNode(0);
            long a1 = getNum(l1);
            long a2 = getNum(l2);
            long sum = a1 + a2;
            string sSum = sum.ToString();
            ListNode cur = ans;
            foreach (char digit in sSum.Reverse())
            {
                cur.next = new ListNode(digit - '0');
                cur = cur.next;
            }
            return ans.next;
        }
    }

    public static class Solve2
    {
        
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ans = new ListNode(0);
            ListNode cur=ans;
            int newDig;
            int carry=0;
            int sum;
            for (; l1 != null && l2 != null; l1 = l1.next, l2 = l2.next) 
            {
                sum = l1.val + l2.val + carry;
                if (sum > 9)
                {
                    newDig = sum - 10;
                    carry = 1;
                }
                else
                {
                    newDig = sum;
                    carry = 0;
                }
                cur.next = new ListNode(newDig);
                cur = cur.next;
            }

            if (l1 == null && l2 != null)
            {
                while (l2!=null&&carry != 0)
                {
                    sum = l2.val + 1;
                    if (sum > 9)
                    {
                        newDig = sum - 10;
                        carry = 1;
                    }
                    else
                    {
                        newDig = sum;
                        carry = 0;
                    }
                    cur.next = new ListNode(newDig);
                    cur = cur.next;
                    l2 = l2.next;
                }
                if (l2!=null)
                {
                    cur.next = l2;
                }
            }

            else if (l1 != null && l2 == null)
            {
                while (l1 != null && carry != 0)
                {
                    sum = l1.val + 1;
                    if (sum > 9)
                    {
                        newDig = sum - 10;
                        carry = 1;
                    }
                    else
                    {
                        newDig = sum;
                        carry = 0;
                    }
                    cur.next = new ListNode(newDig);
                    cur = cur.next;
                    l1 = l1.next;
                }
                if (l1 != null)
                {
                    cur.next = l1;
                }
            }
            if (carry==1)
            {
                cur.next = new ListNode(1);
            }
            return ans.next;
        }
    }
    class Program
    {
        private static ListNode genList(long num)
        {
            ListNode list = new ListNode(0);
            ListNode cur = list;
            foreach (char digit in num.ToString().Reverse())
            {
                cur.next = new ListNode(digit - '0');
                cur = cur.next;
            }
            return list.next;
        }
        static void Main(string[] args)
        {
            Solve2.AddTwoNumbers(genList(9), genList(1));
        }
    }
}
