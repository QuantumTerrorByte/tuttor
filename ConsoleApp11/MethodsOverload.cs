using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace ConsoleApp11
{
    public static class MethodsOverload
    {
        public static void Info(this Object obj, string arg)
            => Console.WriteLine(arg);

        public static IEnumerable<T> MyPeek<T>(this IEnumerable<T> en)
        {
            Console.WriteLine("from overload");
            return en;
        }
    }
}