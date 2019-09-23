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
    }
}
