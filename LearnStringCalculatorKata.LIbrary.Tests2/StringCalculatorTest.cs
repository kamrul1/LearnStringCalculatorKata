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

        [Theory]
        [InlineData("1\n2,3", 6)]
        public void ShouldReturnSumTreatNewLineAsDelimiter(string inputNumbers, int expectedResult)
        {
            var sut = new StringCalculator();

            var result = sut.Add(inputNumbers);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldGetCustomDelimiterFromHeadingOrDefault()
        {
            var sut = new StringCalculator();

            var inputNumbers = "//;\n1;2";

            var result = sut.GetDelimiterFromHeadingOrDefault(inputNumbers);

            Assert.Equal(";", result);
        }

        [Fact]
        public void ShouldThrowExceptionForNegativeNumbers()
        {
            var sut = new StringCalculator();

            var inputNumbers = "1,-2,4,-3";

            Action action = () => sut.Add(inputNumbers);

            var ex = Assert.Throws<Exception>(action);
            Assert.Equal("negatives not allowed -2,-3", ex.Message);

        }


    }
}
