using System;

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

            if (numbers.Contains(','))
            {
                var numberInStrings = numbers.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var number1 = int.Parse(numberInStrings[0]);
                var number2 = int.Parse(numberInStrings[1]);
                return number1 + number2;
            }

            return int.Parse(numbers);
        }
    }
}