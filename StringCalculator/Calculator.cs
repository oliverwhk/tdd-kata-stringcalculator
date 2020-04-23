using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numberInStrings = numbers.Split(new [] { ',' , '\n'}, StringSplitOptions.RemoveEmptyEntries);
            return numberInStrings.Select(n => int.Parse(n)).Sum();
        }
    }
}