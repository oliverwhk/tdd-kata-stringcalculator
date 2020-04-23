using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        public void Add(string numbers, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(numbers);

            result.Should().Be(expected);
        }
    }
}
