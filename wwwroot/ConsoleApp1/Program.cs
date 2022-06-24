using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Join("张三","李四");
            Console.ReadLine();
        }

        public void Join(params string[] name)
        {
            Console.WriteLine(string.Join("+",name));
        }

        public void merge(int[] nums1,int m,int[] nums2,int n)
        {
            int dst = m;
            int src = n;
            while (dst > 0 && src > 0)
            {
                if(nums1[dst-1] <= nums2[src - 1])
                {
                    nums1[src + dst - 1] = nums2[src - 1];
                    --src;
                }
                else
                {
                    nums1[src + dst - 1] = nums1[dst - 1];
                    --dst;
                }
            }
            while (dst == 0 && src > 0)
            {
                nums1[src - 1] = nums2[src - 1];
                --src;
            }
        }
    }
}
