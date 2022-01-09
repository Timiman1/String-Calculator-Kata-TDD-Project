using System;
using System.Linq;

namespace StringCalculatorKataConsole
{
    public class StringCalculatorKata
    {
        private readonly string[] _defaultDelimeters = new[] { ",", "\n" };

        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            return numbers.Split(_defaultDelimeters, StringSplitOptions.RemoveEmptyEntries).Sum(n => int.Parse(n));
        }
    }
}