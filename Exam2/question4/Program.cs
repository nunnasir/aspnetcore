using System;
using System.Collections.Generic;
using System.Linq;

namespace question4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter First Number: ");
            var number1 = Console.ReadLine().ToCharArray().Select(c => c.ToString()).Reverse().ToList();

            Console.Write("Enter First Number: ");
            var number2 = Console.ReadLine().ToCharArray().Select(c => c.ToString()).Reverse().ToList();

            int diff = (number1.Count() > number2.Count()) ? number1.Count() - number2.Count() : number2.Count() - number1.Count();

            int count = 0;
            while (count < diff)
            {
                if (number1.Count() > number2.Count())
                    number2.Add("0");
                else
                    number1.Add("0");

                count++;
            }

            var result = AddSum(number1, number2);

            Console.WriteLine(result);
        }

        private static string AddSum(List<string> number1, List<string> number2)
        {
            int addition = 0;
            int reminder = 0;
            int carry = 0;

            var result = new List<int>();

            for (int i = 0; i < number1.Count; i++)
            {
                addition = int.Parse(number1[i]) + int.Parse(number2[i]) + carry;
                carry = addition / 10;

                if (addition / 10 == 0)
                {
                    result.Add(addition);
                }
                else
                {
                    reminder = addition % 10;
                    result.Add(reminder);
                }
            }
            if (carry != 0)
                result.Add(carry);

            result.Reverse();
            string newResult = string.Join("", result).TrimStart(new Char[] { '0' });
            return newResult;
        }
    }
}
