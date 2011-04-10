using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan;

namespace ClassLibrary1 {
    public class SomeTasks {

        [Task]
        public static int Bar()
        {
            Console.WriteLine("bar");
        }

        [Task]
        public static void X()
        {
            Console.WriteLine("x");
        }

        [Task("this is the first task", Before = "bar no:longer:foo", After = "x")]
        public static void FirstTask()
        {
            Console.WriteLine("first task");
        }

        [Task("no:longer:foo", "this is the FOO task")]
        public static void Foo(Variables vars)
        {
            Console.WriteLine("no longer foo");
        }

        [Task]
        public static void CamelCaseIsFun()
        {
            Task.Get("first:task").Run();
            Console.WriteLine("Camel Case is fun!");
            Task.Get("first:task").Run();
        }
    }
}
