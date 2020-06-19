using System;

namespace question3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Size Of Diamond: ");
            int size = int.Parse(Console.ReadLine());

            int count = size - 1;
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= count; j++)
                {
                    Console.Write(" ");
                }
                count--;
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            count = 1;
            for (int i = 1; i <= size - 1; i++)
            {
                for (int j = 1; j <= count; j++)
                {
                    Console.Write(" ");
                }
                count++;
                for (int j = 1; j <= 2 * (size - i) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
