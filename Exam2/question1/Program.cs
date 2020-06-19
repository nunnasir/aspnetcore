using System;
using System.Collections.Generic;
using System.Linq;

namespace question1
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = new List<(string name, int age, string city)>();

            Console.Write("Number of input: ");
            int numberOfPerson = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            while (count < numberOfPerson)
            {
                Console.Write("Person Name, Age, City Info with Comma Separator: ");
                var personInfo = Console.ReadLine();

                var person = personInfo.Split(',');
                personList.Add((person[0], Convert.ToInt32(person[1]), person[2]));

                count++;
            }

            Console.WriteLine("");

            foreach (var item in personList.OrderBy(p => p.age).ThenBy(p => p.name).ThenBy(p => p.city))
            {
                Console.WriteLine($"Name: {item.name}, Age: {item.age}, City: {item.city}");
            }
        }
    }
}
