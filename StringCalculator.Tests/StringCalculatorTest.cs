using System;
using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("1,2", 3)]
        [InlineData("13,24", 37)]
        [InlineData("1,2,4", 7)]
        [InlineData("1,2,4,5,8", 20)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3", 6)]
        [InlineData("//;\n1;2", 3)]
        public void Add(string numbers, int expectedSum)
        {
            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            result.Should().Be(expectedSum);
        }

        [Theory]
        [InlineData("1,-3", "Negatives not allowed: -3")]
        [InlineData("1,-3,-5", "Negatives not allowed: -3, -5")]
        public void AddWithNegativeNumbers(string numbers, string expectedExceptionMessage)
        {
            var calculator = new Calculator();
            Action action = () => calculator.Add(numbers);

            action.Should().Throw<Exception>().WithMessage(expectedExceptionMessage);
        }
    }
}
