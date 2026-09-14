using System;
using System.Linq;

namespace Assignment1Services
{
    public class Service1 : IService1
    {
        // Converts Celsius to Fahrenheit.
        public int c2f(int c)
        {
            return c * 9 / 5 + 32;
        }

        // Converts Fahrenheit to Celsius.
        public int f2c(int f)
        {
            return (f - 32) * 5 / 9;
        }

        // Sorts comma-separated numbers in ascending order.
        public string sort(string s)
        {
            double[] numbers = s
                .Split(',')
                .Select(x => double.Parse(x.Trim()))
                .ToArray();

            Array.Sort(numbers);

            return string.Join(", ", numbers);
        }
    }
}