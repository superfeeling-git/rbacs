using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    /// <summary>
    /// 委托
    /// </summary>
    /// <param name="parm"></param>
    public delegate void BuyDelegateNoValue(Guid parm);
    public delegate string BuyDelegate(string parm);
    public delegate Person BuyDelegatePer(string parm);
    public delegate void BuyDelegatePerNoParm();
    public delegate Guid BuyDelegatePerNoParmGuid();

    public delegate Person BuyDelegatePerPs(string parm,DateTime dt);


    public class Program
    {
        static void Main(string[] args)
        {
            int a;
            Program program = new Program();
            program.test(out a);
            Console.WriteLine(a);
            Console.ReadLine();
        }

        public void test(out int parm)
        {
            parm = 2;
        }
    }


    public class Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }




    public class Person
    {

        //x => { return x.Length == 1; }

        public bool test(string x)
        {
            ///codeing.
            ///
            return x.Length == 1;
        }


        public string aaa()
        {
            return "";
        }


        public void abc(string m)
        {

        }
        /// <summary>
        /// 签名-----一样
        /// </summary>
        /// <param name="str"></param>
        public string Buy(string str)
        {
            return $"我要买-{str}";
        }
    }
}
