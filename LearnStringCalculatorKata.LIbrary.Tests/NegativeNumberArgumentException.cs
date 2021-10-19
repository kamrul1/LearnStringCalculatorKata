using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStringCalculatorKata.LIbrary.Tests1
{
    public class NegativeNumberArgumentException : ArgumentException
    {
        public NegativeNumberArgumentException(string message, string parameters) : base(message, parameters)
        {

        }
    }
}
