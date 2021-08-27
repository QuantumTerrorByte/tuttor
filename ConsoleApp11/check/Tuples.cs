using System;

namespace ConsoleApp11.check
{
    public class Tuples
    {
        public class Holder
        {
            public int Item { get; set; }

            public Holder(int item)
            {
                Item = item;
            }

            public override string ToString()
            {
                return $"{nameof(Item)}: {Item}";
            }
        }
        public void Check()
        {
            var first = (10, 10);
            (long a, long b) longs = (5, 10);

            var firstHolder = new Holder(50);
            var secondHolder = new Holder(100);

            var x = (firstHolder, secondHolder);
            var y = (firstHolder, secondHolder);
            var objFirst = (new Holder(10), new Holder(20));
            var objSecond = (new Holder(10), new Holder(20));
            
            Console.WriteLine(x==y);
            Console.WriteLine(first == longs);
            Console.WriteLine(objFirst == objSecond);
            Console.WriteLine(objFirst.Item1);
        }
        
        public (string, string) TupleSwitch(string x, string y)
        {
            return (x, y)switch
            {
                ("one", "two") => ("1", "2"),
                ("two", "three") => ("2", "3"),
                ("three", "four") => ("3", "4"),
                _=>("not","nop")
            };
        }

        public void TepleReffTest((int, int) tup)
        {
            Console.WriteLine(tup.Item1);
            Console.WriteLine(tup.Item2);
        }
    }
}