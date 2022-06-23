using System;

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
    }
}
