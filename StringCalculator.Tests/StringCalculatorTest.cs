using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyString_Returns0()
        {
            // Arrange
            var input = "";

            // Act
            var calculator = new Calculator();
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(0);
        }
        
        [Fact]
        public void StringWithOneNumber_ReturnsTheNumber()
        {
            // Arrange
            var input = "2";

            // Act
            var calculator = new Calculator();
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(2);
        }
    }
}
