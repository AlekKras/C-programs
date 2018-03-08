using System;

namespace hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2018, 3, 8, 11, 25, 0); //the exact date when I started learning C#
            Console.WriteLine("The day when I started learning C# was on " + date1.ToString("d"));
            Console.WriteLine("It was a sunny day outside but I was in the office learning C#");
            Console.WriteLine("Then I looked at the watch and it was " + date1.ToString("HH:mm"));
            Console.WriteLine("Oh, hello there!!!");
            Console.WriteLine("How shalleth I calleth thy?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}! I have been learning C# since the day {1}", name, date1.ToString("d"));
        }
    }
}
