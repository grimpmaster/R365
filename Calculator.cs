using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringsCalculator
{
    public class Calculator
    {
        private readonly List<string> _defaultDelimiters = new List<string> { ",", "\n", "\t" };

        public int Add(string numbers, int limit = Constants.MaxNumberLimit, bool allowNegatives = false)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            if (numbers.StartsWith(Constants.CustomDelimiterIdentifier))
            {
                numbers = GetNumbersExcludingCustomDelimiter(numbers);
            }
            return GetSumOfNumbers(numbers, limit, allowNegatives);
        }

        private int GetSumOfNumbers(string numbers, int limit, bool allowNegatives)
        {
            var convertedNumbers =
                numbers.Split(_defaultDelimiters.ToArray(), StringSplitOptions.None);

            var numbersOnlyList = new List<int>();
            StringBuilder sb = new StringBuilder();
            foreach (string convertedNumber in convertedNumbers)
            {
                int n;
                var isNumeric = int.TryParse(convertedNumber, out n);
                if (isNumeric)
                {
                    sb.Append(string.Format("{0} + ", n));
                    numbersOnlyList.Add(n);
                }
            }

            PrintExpression(sb, numbersOnlyList);


            if (!allowNegatives)
            {
                ValidateNumbersArePositive(numbersOnlyList);
            }

            var sumOfNumbers = numbersOnlyList.Where(x => x <= 1000).Sum();
            return sumOfNumbers;
        }

        // Stretch Goal #1 - Display the formula used to calculate the result e.g. 2,4,rrrr,1001,6 will return 2+4+0+0+6 = 12
        private static void PrintExpression(StringBuilder sb, List<int> numbersOnlyList)
        {
            var expression = sb.ToString().Remove(sb.ToString().LastIndexOf('+'));
            sb = new StringBuilder();
            sb.Append(String.Format(" {0}= {1}", expression, numbersOnlyList.Sum()));
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("{0}", sb);
            Console.WriteLine("-------------------------------------------");
            // End Stretch Goal #1
        }

        private static void ValidatePositiveNumbers(IReadOnlyCollection<int> convertedNumbers)
        {
            if (!convertedNumbers.Any(x => x < 0)) return;
            throw new FormatException("negatives not allowed");
        }

        private string GetNumbersExcludingCustomDelimiter(string numbers)
        {
            var startIndexOfString = AssignCustomDelimiterAndReturnStartIndexOfNumbers(numbers);

            numbers = numbers.Substring(startIndexOfString);
            return numbers;
        }

        private int AssignCustomDelimiterAndReturnStartIndexOfNumbers(string numbers)
        {
            var customDelimiters = GetCustomDelimiter(numbers);
            _defaultDelimiters.AddRange(customDelimiters);

            var hasMultipleDelimiters = customDelimiters.Count > 1;
            var multipleDelimiterLength = hasMultipleDelimiters ? customDelimiters.Count * 2 : 0;

            return Constants.NumbersWithCustomDelimiterStartIndex + customDelimiters.Sum(x => x.Length) +
                   multipleDelimiterLength;
        }

        private static IList<string> GetCustomDelimiter(string numbers)
        {
            var allDelimiters = numbers.Substring(Constants.CustomDelimiterStartIndex,
                numbers.IndexOf('\n') - Constants.CustomDelimiterStartIndex);

            var splitDelimiters = allDelimiters.Split('[').Select(x => x.TrimEnd(']')).ToList();

            if (splitDelimiters.Contains(string.Empty))
            {
                splitDelimiters.Remove(string.Empty);
            }

            return splitDelimiters;
        }

        private static void ValidateNumbersArePositive(IReadOnlyCollection<int> convertedNumbers)
        {
            if (!convertedNumbers.Any(x => x < 0)) return;
            throw new FormatException("negatives not allowed");
        }
    }
}
