using System;

namespace ConsoleApp11
{
    public class Tests
    {
        static Tests()
        {
            Console.WriteLine("STATIC CTOR FROM TEST");
        }
        
        private Random _rand = new Random();

        public string? GetStringOrNull()
        {
            switch (_rand.Next(2))
            {
                case 1: return "Not Null String";
                default: return null;
            }
        }

        public static void Hello()
        {
            Console.WriteLine("HELLO");
        }
    }
}