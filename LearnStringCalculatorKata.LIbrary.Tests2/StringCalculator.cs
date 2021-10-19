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
            if(string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            if (numbers.Contains(",\n"))
            {
                return 0;
            }

            var UseDelimiter = GetDelimiterFromHeadingOrDefault(numbers);

            var numberArray = numbers.Split(DEFAULT_DELIMITERS, StringSplitOptions.None);
            var sum = 0;
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

            if (negatives.Count() > 0)
            {
                var negativeNumberString = string.Join(",", negatives);
                throw new Exception($"negatives not allowed {negativeNumberString}");
            }

            return sum;
        }

        internal object GetDelimiterFromHeadingOrDefault(string inputNumbers)
        {
            if (inputNumbers.StartsWith("//"))
            {
                inputNumbers = inputNumbers.TrimStart('/');
                return inputNumbers.Split('\n').FirstOrDefault();
            }

            return DEFAULT_DELIMITERS;


        }
    }
}
