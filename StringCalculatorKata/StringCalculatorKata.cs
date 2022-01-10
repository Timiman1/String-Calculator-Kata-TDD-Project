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

        private const string MultipleCustomDelimetersPattern = @"\[([^][\w-]+)\]";

        private const string DelimeterDefinitionPattern = @"^//.*?\\n(.+)";

        public int Add(string numbers)
        {
            return HiddenAddImpl(numbers);
        }

        private int HiddenAddImpl(string numbers)
        {
            EscapeNewLines(ref numbers);

            int[] parsedNumbers = GetSeparatedParsedNumbers(numbers);

            ValidateNonNegatives(parsedNumbers);

            return parsedNumbers.Sum();
        }

        private void EscapeNewLines(ref string numbers)
        {
            numbers = numbers.Replace("\n", @"\n");
        }

        private int[] GetSeparatedParsedNumbers(string numbers)
        {
            string[] dels = GetAllDelimeters(GetCustomDelimeters(numbers));
            string toSplit = GetNonSeparatedNumbers(numbers);
            string[] separatedNumbers = toSplit.Split(dels, StringSplitOptions.RemoveEmptyEntries);

            return IgnoreNumbersLargerThan1000(separatedNumbers).Select(n => int.Parse(n)).ToArray();
        }

        private string[] GetCustomDelimeters(string numbers)
        {
            if (HasCustomDelimeters(numbers) == false)
            {
                return null;
            }

            MatchCollection matches = Regex.Matches(numbers, MultipleCustomDelimetersPattern);

            if (matches.Count == 0)
            {
                Match match = Regex.Match(numbers, SingleCustomDelimeterPattern);
                return new[] { match.Groups[1].Value };
            }
            else
            {
                return matches.Select(m => m.Groups[1].Value).ToArray();
            }
        }

        private bool HasCustomDelimeters(string numbers)
        {
            return (Regex.Match(numbers, DelimeterDefinitionPattern).Success == true);
        }

        private string GetNonSeparatedNumbers(string numbers)
        {
            Match match = Regex.Match(numbers, DelimeterDefinitionPattern);

            return Regex.Unescape(match.Success == true ? match.Groups[1].Value : numbers);
        }

        private string[] GetAllDelimeters(string[] userDefinedDels)
        {
            return userDefinedDels == null ?
                _defaultDelimeters
                :
                _defaultDelimeters.Concat(userDefinedDels).ToArray();
        }

        private void ValidateNonNegatives(int[] numbers)
        {
            IEnumerable<int> negatives = GetNegatives(numbers);

            if (negatives.Any() == true)
            {
                ThrowNegativesException(negatives);
            }
        }

        private void ThrowNegativesException(IEnumerable<int> negatives)
        {
            string errorMessage = "negatives not allowed: ";
            foreach (int neg in negatives)
            {
                errorMessage += $"{neg} ";
            }
            throw new ArgumentException(errorMessage.TrimEnd());
        }

        private IEnumerable<int> GetNegatives(int[] numbers)
        {
            return numbers.Where(n => n < 0);
        }

        private IEnumerable<string> IgnoreNumbersLargerThan1000(string[] numbers)
        {
            return numbers.Where(n => int.Parse(n) <= 1000);
        }
    }
}