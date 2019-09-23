using System;
using NUnit.Framework;

namespace StringsCalculator
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator stringCalc;

        [SetUp]
        public void SetUp()
        {
            stringCalc = new Calculator();
        }

        private int Calculate(string numbers)
        {
            var calculatedResult = stringCalc.Add(numbers);

            return calculatedResult;
        }

        //// AC #1: Support a maximum of 2 numbers using a comma delimiterexamples: 20 will return 20; 1,5000 will return 5001
        ////        invalid/missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5
        [Test]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("1,5000", ExpectedResult = 1)]
        public int AC1_SupportMinimumOf2Numbers(string numbers)
        {
            return Calculate(numbers);
        }

        //// AC #2: Support an unlimited number of numbers e.g. 1,2,3,4,5,6,7,8,9,10,11,12 will return 78
        [Test]
        [TestCase("1,2,3,4,5,6,7,8,9,10,11,12", ExpectedResult = 78)]
        public int AC2_SupportUnlimtedNumbers(string numbers)
        {
            return Calculate(numbers);
        }

        //// AC #3: Support a newline character as an alternative delimiter e.g. 1\n2,3 will return 6
        [Test]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        public int SupportNewlineCharAsAltDelim(string numbers)
        {
            return Calculate(numbers);
        }

        // AC #4: Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided
        [Test]
        [TestCase("23,-465", ExpectedResult = -1)]
        //this version does not support expectedException (booo) so making unit test work by replacing exception with -1
        public int DenyNegativeNumbers(string numbers)
        {
            try
            {
                return Calculate(numbers);
            }
            catch (FormatException ex)
            {
                return -1;
            }
        }

        // AC #5: Ignore any number greater than 1000 e.g. 2,1001,6 will return 8
        [Test]
        [TestCase("2,1001,6", ExpectedResult = 8)]
        public int IgnoreNumbersGreaterThanMaxNumbers(string numbers)
        {
            return Calculate(numbers);
        }

        // AC #6: Support 1 custom single character length delimiter use the format: //{delimiter}\n{numbers} e.g. //;\n2;5 will return 7
        // all previous formats should also be supported
        [Test]
        [TestCase("//;\n2;5", ExpectedResult = 7)]
        public int SupportOneCustomDelim(string numbers)
        {
            return Calculate(numbers);
        }

        // AC #7: 
        // Support 1 custom delimiter of any lengthuse the format: //[{delimiter}]\n{numbers} e.g. //[***]\n11***22***33 will return 66 all previous formats should also be supported
        [Test]
        [TestCase("//[***][\n]11***22***33", ExpectedResult = 66)]
        public int SupportOneCustomDelimAnyLength(string numbers)
        {
            return Calculate(numbers);
        }

        // AC #8:
        // Support multiple delimiters of any length use the format: //[{delimiter1}][{delimiter2}]...\n{numbers} e.g. //[*][!!][r9r]\n11r9r22*33!!44 will return 110
        // all previous formats should also be supported
        [Test]
        [TestCase("//[*][!!][r9r]\n11r9r22*33!!44", ExpectedResult = 110)]
        public int SupportMultipleDelims(string numbers)
        {
            return Calculate(numbers);
        }
    }
}
