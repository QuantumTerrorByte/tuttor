using System;
using System.Reflection.Metadata;
using System.Threading;

namespace ConsoleApp11.Mulltitraiding
{
    public class NumbHolder
    {
        public static int Counter { get; set; }
        private static int _counter;
        public static Object SynObj { get; set; } = new object();
        public string Name { get; set; }

        
        public void Increment()
        {
            while (true)
            {
                while (true)
                {
                    Monitor.Enter(SynObj);
                    try
                    {
                        for (int i = 0; i < 10; i++)
                            Console.WriteLine(Name + ": " + Counter++);
                    }
                    finally
                    {
                        // Monitor.Exit(this);
                        Monitor.Wait(SynObj);
                    }
                }
            }
        }
    }
}