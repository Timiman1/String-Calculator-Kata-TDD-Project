using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKataConsole
{
    public class StringCalculatorKata
    {
        private readonly string[] _defaultDelimeters = new[] { ",", "\n" };

        private const string SingleCustomDelimeterPattern = @"^//\[?([^][\w-]+)\]?\\n";

        private const string DelimeterDefinitionPattern = @"^//.*?\\n(.+)";

        public int Add(string numbers)
        {
            return HiddenAddImpl(numbers);
        }

        private int HiddenAddImpl(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Replace("\n", @"\n");
            }

            int[] parsedNumbers = GetSeparatedParsedNumbers(numbers);

            return parsedNumbers.Sum();
        }

        private int[] GetSeparatedParsedNumbers(string numbers)
        {
            string toParse;
            string[] custDels = null;
            if (HasCustomDelimeters(numbers, out toParse))
            {
                custDels = GetCustomDelimeters(numbers);
            }
            return SeparateNumbers(toParse, GetAllDelimeters(custDels));
        }

        private string[] GetCustomDelimeters(string numbers)
        {
            Match match = Regex.Match(numbers, SingleCustomDelimeterPattern);

            string[] result = new[] { match.Groups[1].Value };

            return result;
        }

        private bool HasCustomDelimeters(string numbers, out string toParse)
        {
            Match delMatch = new Regex(DelimeterDefinitionPattern).Match(numbers);

            if (delMatch.Success)
            {
                toParse = Regex.Unescape(delMatch.Groups[1].Value);
                return true;
            }
            toParse = numbers;
            return false;
        }

        private int[] SeparateNumbers(string numbers, string[] dels)
        {
            string[] separated = numbers.Split(dels, StringSplitOptions.RemoveEmptyEntries);

            return separated.Select(n => int.Parse(n)).ToArray();
        }

        private string[] GetAllDelimeters(string[] userDefinedDels)
        {
            if (userDefinedDels == null)
                return _defaultDelimeters;
            else
                return _defaultDelimeters.Concat(userDefinedDels).ToArray();
        }

        //public int Add(string numbers)
        //{
        //    if (numbers == "")
        //        return 0;

        //    return numbers.Split(_defaultDelimeters, StringSplitOptions.RemoveEmptyEntries).Sum(n => int.Parse(n));
        //}
    }
}