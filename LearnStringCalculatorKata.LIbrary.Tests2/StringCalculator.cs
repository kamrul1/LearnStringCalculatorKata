using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStringCalculatorKata.LIbrary.Tests2
{
    public class StringCalculator
    {
        private string[] DEFAULT_DELIMITERS = new string[] { ",", "\n" };

        public int Add(string numbers)
        {
            if (NotValid(numbers))
            {
                return 0;
            }



            var UseDelimiter = GetDelimitersFromHeadingOrDefault(numbers);

            var numberArray = numbers.Split(UseDelimiter, StringSplitOptions.None);

            var sum = CalculateSumOfNumbers(numberArray);

            return sum;
        }

        public void NegativesThrowException(List<int> negatives)
        {
            if (negatives.Count() > 0)
            {
                var negativeNumberString = string.Join(",", negatives);
                throw new Exception($"negatives not allowed {negativeNumberString}");
            }
        }

        public int CalculateSumOfNumbers(string[] numberArray)
        {
            int sum = 0;
            List<int> negatives = new();

            foreach (var number in numberArray)
            {
                var value = Int32.Parse(number);
                if (value < 0)
                {
                    negatives.Add(value);
                }

                sum = +value;
            }

            NegativesThrowException(negatives);

            return sum;
        }

        public bool NotValid(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return false;
            }

            if (numbers.Contains(",\n"))
            {
                return false;
            }

            return true;
        }

        public string[] GetDelimitersFromHeadingOrDefault(string inputNumbers)
        {
            if (inputNumbers.StartsWith("//"))
            {
                inputNumbers = inputNumbers.TrimStart('/');
                return new string[] { inputNumbers.Split('\n').FirstOrDefault() };
            }

            return DEFAULT_DELIMITERS;


        }
    }
}
