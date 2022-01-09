using System;

namespace StringCalculatorKataConsole
{
    public class StringCalculatorKata
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }
            return int.Parse(numbers);
        }
    }
}