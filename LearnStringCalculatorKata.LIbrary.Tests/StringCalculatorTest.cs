using System;
using Xunit;

namespace LearnStringCalculatorKata.LIbrary.Tests1
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("1, 2", 3)]
        public void ShouldSumNumbersSeperatedByComma(string input, int expected)
        {
            //Arrange
            //Act
            int result = StringCalculator.Add(input);

            //Assert
            Assert.Equal(expected, result);

        }

        [Fact]
        public void ShouldReturnZeroSumEmptString()
        {
            //Arrange
            int expected = 0;
            //Act
            int result = StringCalculator.Add("");

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1\n2", 3)]
        public void ShouldSumNumbersSeperatedByNewLine(string input, int expected)
        {
            //Arrange
            //Act
            int result = StringCalculator.Add(input);

            //Assert
            Assert.Equal(expected, result);
        }




        [Fact]
        public void ShouldReturnNegativeNumberExceptionGivenNegativeNumbersString()
        {
            //Arrange
            var inputNegativeNumberString = "0,-1,3,-3";
            //Act
            var exception = Record.Exception(() => StringCalculator.Add(inputNegativeNumberString));
            //Assert
            Assert.IsType<NegativeNumberArgumentException>(exception);
            Assert.Contains("-1,-3", exception.Message);
        }

        [Fact]
        public void ShouldExcludeNumbersOver100InSum()
        {
            //Arrange
            var inputNoOver1000 = "2,1001,3";
            //Act
            var result = StringCalculator.Add(inputNoOver1000);
            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        [Trait("Category", "Delimiter")]
        public void ShouldSupportCustomDelimitersStringBeginings()
        {
            //Arrange
            var inputDelimiter = "//;\n1;2";
            //Act
            var result = StringCalculator.Add(inputDelimiter);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Delimiter")]
        public void ShouldExtractCustomDelimiterFromStringNumber()
        {
            //Arrange
            var inputDelimiter = "//[***]\n1***2***3";

            //Act
            var result = StringCalculator.ExtractCustomDelimiterWhenOnFirstLine(inputDelimiter);

            //Assert
            Assert.Equal("***", result);
        }

        [Fact]
        [Trait("Category", "Delimiter")]
        public void ShouldExtractMulipleCustomDelimiterWhenOnFirstLine()
        {
            //Arrange
            var input = "//[***][%22]\n1*2%3";
            //Act
            var results = StringCalculator.ExtractMulipleCustomDelimiterWhenOnFirstLine(input);

            //Assert
            Assert.Contains("***", results);
            Assert.Contains("%22", results);

        }
    }
}
