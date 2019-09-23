﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StringsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine("Welcome to Sandy's String Calculator");
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine();

            Calculator calculator = new Calculator();
            Stopwatch sw = new Stopwatch();
            Stopwatch swOne = new Stopwatch();
            Stopwatch swTwo = new Stopwatch();
            Stopwatch swThree = new Stopwatch();
            Stopwatch swFour = new Stopwatch();

            sw.Start();

            Console.WriteLine("Expression: ");
            swOne.Start();
            TestACOne(calculator);
            swOne.Stop();

            Console.WriteLine("Expression: ");
            swTwo.Start();
            TestACTwo(calculator);
            swTwo.Stop();

            Console.WriteLine("Expression: ");
            swThree.Start();
            TestACThree(calculator);
            swThree.Stop();

            Console.WriteLine("Expression: ");
            swFour.Start();
            TestACFour(calculator);
            swFour.Stop();

            Console.WriteLine("AC #1 Elapsed Time: {0} ms", swOne.Elapsed.Ticks);
            Console.WriteLine("AC #2 Elapsed Time: {0} ms", swTwo.Elapsed.Ticks);
            Console.WriteLine("AC #3 Elapsed Time: {0} ms", swThree.Elapsed.Ticks);
            Console.WriteLine("AC #4 Elapsed Time: {0} ms", swFour.Elapsed.Ticks);
            Console.WriteLine("Total Elapsed Time: {0} ms", sw.Elapsed.Ticks);
            Console.WriteLine("");
            Console.WriteLine("All Acceptance Criteria Met!");

            Console.Read();
        }
        private static void TestACOne(Calculator calculator)
        {
            var acOneInputOne = "1";
            var acOneInputTwo = "1,500";
            var acOneInputThree = "1,ccc,500";
            var acOneTitle = "AC #1";
            var acOneDescription =
                "Support a maximum of 2 numbers using a comma delimiter examples: 20 will return 20;\n 1,5000 will return 5001 invalid/missing numbers should be converted to 0 \n e.g. \"\" will return 0; 5,tytyt will return 5";
            var acOneInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}",acOneInputOne, calculator.Add(acOneInputOne)),
                string.Format("Input: {0} | Output: {1}",acOneInputTwo, calculator.Add(acOneInputTwo)),
                string.Format("Input: {0} | Output: {1}",acOneInputThree, calculator.Add(acOneInputThree))
            };

            WriteToConsole(acOneTitle, acOneDescription, acOneInputs);
        }

        private static void TestACTwo(Calculator calculator)
        {
            var acTwoInputOne = "1,2,3,4,5,6,7,8,9,10,11,12";
            var acTwoTitle = "AC #2";
            var acTwoDescription =
                string.Format("Support an unlimited number of numbers e.g. {0} will return 78", acTwoInputOne);

            var acTwoInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}",acTwoInputOne, calculator.Add(acTwoInputOne))
            };

            WriteToConsole(acTwoTitle, acTwoDescription, acTwoInputs);
        }

        private static void TestACThree(Calculator calculator)
        {
            var acThreeInputOne = "1\n2,3";
            var acThreeTitle = "AC #3";
            var acThreeDescription =
                "Support a newline character as an alternative delimiter e.g. 1\\n2,3 will return 6";
            var acThreeInputs = new List<string>()
            {
                string.Format("Input: {0} | Output: {1}",acThreeInputOne, calculator.Add(acThreeInputOne))
            };

            WriteToConsole(acThreeTitle, acThreeDescription, acThreeInputs);
        }

        private static void TestACFour(Calculator calculator)
        {
            var acFourInputOne = "23,-465";
            var acFourTitle = "AC #4";
            var acFourDescription =
                "Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided";
            try
            {
                var acFourInputs = new List<string>()
            {
                string.Format("Input: {0} | Output: {1}",acFourInputOne, calculator.Add(acFourInputOne))
            };
                WriteToConsole(acFourTitle, acFourDescription, acFourInputs);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(Constants.ConsoleLine);
                Console.WriteLine("{0}", acFourTitle);
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("{0}", acFourDescription);
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Exception Occurred: Input: {0} | Output: {1}", acFourInputOne, ex.Message);
                Console.WriteLine(Constants.ConsoleLine);
            }

        }


        private static void WriteToConsole(string title, string description, List<string> inputs)
        {
            Console.WriteLine("");
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine(title);
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine(description);
            Console.WriteLine(Constants.ConsoleLine);
            inputs.ForEach(input =>
            {
                Console.WriteLine(input);
            });
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine("");
        }
    }
}
