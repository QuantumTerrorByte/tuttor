namespace ConsoleApp11
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Age)}: {Age}";
        }

        public static Human operator ++(Human h1)
        {
            h1.Age++;
            return h1;
        }

        public static Human operator --(Human h1) => new Human
            {FirstName = h1.FirstName, LastName = h1.LastName, Age = h1.Age + 1};

        public static Human operator +(Human h1, Human h2)
            => new Human {FirstName = h1.FirstName, LastName = h2.LastName, Age = h1.Age + h2.Age};
    }
}