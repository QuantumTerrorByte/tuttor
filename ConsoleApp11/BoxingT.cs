using System;

namespace ConsoleApp11
{
    public struct NHolder
    {
        public int A, B;

        public void Test()
        {
            System.Int32 a = 50;
            Console.WriteLine("first {0} second {1} third {2}", a, a, a);

            // triple boxing in netCore?
            Object o = a;
            Console.WriteLine("first {0} second {1} third {2}", o, o, o);
            // optimized one time boxed
        }
    }
}