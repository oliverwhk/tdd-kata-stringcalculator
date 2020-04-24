using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly List<char> _delimiters = new List<char> { ',' , '\n'};

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            if (numbers.StartsWith("//"))
            {
                var newDelimiter = numbers[2];
                _delimiters.Add(newDelimiter);
                numbers = numbers.Split('\n')[1];
            }

            var numberInStrings = numbers.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            return numberInStrings.Select(n => int.Parse(n)).Sum();
        }
    }
}