using System;
using System.Linq;

namespace StringCalculatorKataConsole
{
    public class StringCalculatorKata
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            return numbers.Split(',').Sum(n => int.Parse(n));
        }
    }
}