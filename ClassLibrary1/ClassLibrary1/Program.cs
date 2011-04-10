using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("MAIN - begin");
            TaskMan.Task.Run(args);
            Console.WriteLine("MAIN - end");
            Console.ReadLine();
        }
    }
}
