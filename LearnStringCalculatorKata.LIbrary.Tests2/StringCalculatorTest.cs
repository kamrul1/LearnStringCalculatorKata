using System;
using Xunit;

namespace LearnStringCalculatorKata.LIbrary.Tests2
{
    public class StringCalculatorTest
    {
        [Fact]
        public void ShouldReturnZeroForAddEmptyString()
        {
            var sut = new StringCalculator();

            var result = sut.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void ShouldReturnSumOfInputNumbers(string inputNumbers, int expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.Add(inputNumbers);

            Assert.Equal(expectedResult, result);
        }
    }
}
