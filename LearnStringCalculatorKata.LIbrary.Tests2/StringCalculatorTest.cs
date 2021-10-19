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
    }
}
