using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //定义一个乱的数组
            int[] arr = new int[] { 4, 5, 1, 2 };
            //外循环
            for (int i = 0; i < arr.Length; i++)
            {
                //内循环
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    //从大到小排序 (改成< 就是从小到大)   
                    if (arr[i] > arr[j])
                    {
                        int temp;
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            Console.ReadLine();



            int[] ss = new int[] {3,4,5,6,3,4 };
            Console.WriteLine(String.Concat(ss.Distinct()));
            Console.ReadLine();


            string s = "88";
            //0100  0088  0006
            Console.WriteLine(s.PadLeft(8, '*'));
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
