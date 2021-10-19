using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStringCalculatorKata.LIbrary.Tests2
{
    public class StringCalculator
    {
        private string[] DELIMITERS = new string[] { ",", "\n" };

        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            

            var numberArray = numbers.Split(DELIMITERS, StringSplitOptions.None);
            var sum = 0;
            foreach (var number in numberArray)
            {
                sum += Int32.Parse(number);
            }

            return sum;
        }
    }
}
