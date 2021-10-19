using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStringCalculatorKata.LIbrary.Tests2
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var numberArray = numbers.Split(",");
            var sum = 0;
            foreach (var number in numberArray)
            {
                sum += Int32.Parse(number);
            }

            return sum;
        }
    }
}
