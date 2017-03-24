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
        public  static ListNode addAddTwoNumbers(ListNode l1, ListNode l2)
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
            Solve.addAddTwoNumbers(genList(1), genList(9999999991));
        }
    }
}
