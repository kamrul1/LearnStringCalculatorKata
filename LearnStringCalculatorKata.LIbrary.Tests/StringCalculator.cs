using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnStringCalculatorKata.LIbrary.Tests1
{
    public class StringCalculator
    {
        private const int EXCLUDE_NUMBER_OVER1000 = 1000;
        private static char[] DEFAULT_DELIMITER = new char[] { ',', '\n' };
        public static int Add(string stringNumbers)
        {

            if (IsNotNumbers(stringNumbers))
            {
                return 0;
            }

            string[] stringNumberArray = SplitByDelimiter(stringNumbers);

            NegativeNumbersThrowException(stringNumberArray);

            return SumNumbersInArray(stringNumberArray);
        }

        public static void NegativeNumbersThrowException(string[] stringNumberArray)
        {
            var negativeNumbers = stringNumberArray.Where(x => x.StartsWith('-'));

            if (negativeNumbers.Count() > 0)
            {
                throw new NegativeNumberArgumentException("negatives not allowed", $"{string.Join(",", negativeNumbers)}");
            }
        }

        public static int SumNumbersInArray(string[] stringNumberArray)
        {
            int sum = 0;

            foreach (var stringNumber in stringNumberArray)
            {
                sum = AddNumberToSum(sum, stringNumber);
            }
            return sum;
        }

        public static string[] SplitByDelimiter(string stringNumbers)
        {
            string[] customDelimiters = ExtractMulipleCustomDelimiterWhenOnFirstLine(stringNumbers);

            string[] stringNumberArray = SpitByDelimiter(stringNumbers, customDelimiters);
            return stringNumberArray;
        }

        public static string ExtractCustomDelimiterWhenOnFirstLine(string stringNumbers)
        {
            string customDelimiter = " ";
            var endDelimiterIndex = 0;

            if (stringNumbers.StartsWith("//["))
            {
                endDelimiterIndex = stringNumbers.IndexOf("]\n");
                customDelimiter = stringNumbers.Substring(3, endDelimiterIndex - 3);
                return customDelimiter;
            }

            if (stringNumbers.StartsWith("//"))
            {
                endDelimiterIndex = stringNumbers.IndexOf('\n');

                if (endDelimiterIndex > 0)
                {
                    customDelimiter = stringNumbers.Substring(2, endDelimiterIndex - 2);
                    return customDelimiter;
                }
            }

            return customDelimiter;
        }

        public static string[] ExtractMulipleCustomDelimiterWhenOnFirstLine(string stringNumbers)
        {
            List<string> customDelimiters = new();

            stringNumbers = stringNumbers.TrimStart('/');
            var delimitersBlock = stringNumbers.Split('\n').FirstOrDefault();

            foreach (var delimiterWithStartBlock in delimitersBlock.Split(']'))
            {
                customDelimiters.Add(delimiterWithStartBlock.TrimStart('['));
            }

            return customDelimiters.ToArray();
        }

        public static string[] SpitByDelimiter(string stringNumbers, string[] customDelimitors)
        {
            if (customDelimitors.Length == 0)
            {
                return stringNumbers.Split(DEFAULT_DELIMITER);
            }

            return stringNumbers.Split(customDelimitors, StringSplitOptions.RemoveEmptyEntries);


        }

        public static int AddNumberToSum(int sum, string item)
        {
            int result = 0;
            bool success = int.TryParse(item, out result);

            if (result > EXCLUDE_NUMBER_OVER1000)
            {
                return sum;
            }

            if (success)
            {
                sum += result;
            }

            return sum;
        }

        public static bool IsNotNumbers(string stringNumbers) =>
                string.IsNullOrWhiteSpace(stringNumbers)
                || stringNumbers.Contains(",\n")
                ? true : false;
    }
}
