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

            AddCustomDelimiter(numbers);
            
            var parsedNumbers = ParseNumbersInString(RemoveCustomDelimiterPrefix(numbers));
            ValidateNumbersNotNegative(parsedNumbers);

            return parsedNumbers.Sum();
        }

        private static void ValidateNumbersNotNegative(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0).ToList();

            if (!negativeNumbers.Any())
            {
                return;
            }
            
            throw new Exception($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }

        private void AddCustomDelimiter(string numbers)
        {
            if (!numbers.StartsWith("//"))
            {
                return;
            }
            
            _delimiters.Add(numbers[2]);
        }

        private IEnumerable<int> ParseNumbersInString(string numbers)
        {
            return numbers.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                          .Select(n => int.Parse(n));
        }

        private string RemoveCustomDelimiterPrefix(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                return numbers.Split('\n')[1];
            }

            return numbers;
        }
    }
}