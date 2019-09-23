using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace StringsCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HandleExit();

            WriteHeader();

            RunAndWriteBusinessLogic();
        }

        private static void RunAndWriteBusinessLogic()
        {
            var calculator = new Calculator();
            var sw = new Stopwatch();
            var swOne = new Stopwatch();
            var swTwo = new Stopwatch();
            var swThree = new Stopwatch();
            var swFour = new Stopwatch();
            var swFive = new Stopwatch();
            var swSix = new Stopwatch();
            var swSeven = new Stopwatch();
            var swEight = new Stopwatch();
            var swThreeA = new Stopwatch();
            var swThreeB = new Stopwatch();
            var swThreeC = new Stopwatch();

            sw.Start();

            WriteExpressIonLabel();
            swOne.Start();
            ExecuteAC_One(calculator);
            swOne.Stop();

            WriteExpressIonLabel();
            swTwo.Start();
            ExecuteAC_Two(calculator);
            swTwo.Stop();

            WriteExpressIonLabel();
            swThree.Start();
            ExecuteAC_Three(calculator);
            swThree.Stop();

            WriteExpressIonLabel();
            swFour.Start();
            ExecuteAC_Four(calculator);
            swFour.Stop();

            WriteExpressIonLabel();
            swFive.Start();
            ExecuteAC_Five(calculator);
            swFive.Stop();

            WriteExpressIonLabel();
            swSix.Start();
            ExecuteAC_Six(calculator);
            swSix.Stop();

            WriteExpressIonLabel();
            swSeven.Start();
            ExecuteAC_Seven(calculator);
            swSeven.Stop();

            WriteExpressIonLabel();
            swEight.Start();
            ExecuteAC_Eight(calculator);
            swEight.Stop();

            WriteExpressIonLabel();
            swThreeA.Start();
            ExecuteStretchGoal3A(calculator);
            swThreeA.Stop();

            WriteExpressIonLabel();
            swThreeB.Start();
            ExecuteStretchGoal3B(calculator);
            swThreeB.Stop();

            WriteExpressIonLabel();
            swThreeC.Start();
            ExecuteStretchGoal3C(calculator);
            swThreeC.Stop();

            Console.WriteLine("AC #1 Elapsed Time: {0} ms", swOne.Elapsed.Ticks);
            Console.WriteLine("AC #2 Elapsed Time: {0} ms", swTwo.Elapsed.Ticks);
            Console.WriteLine("AC #3 Elapsed Time: {0} ms", swThree.Elapsed.Ticks);
            Console.WriteLine("AC #4 Elapsed Time: {0} ms", swFour.Elapsed.Ticks);
            Console.WriteLine("AC #5 Elapsed Time: {0} ms", swFive.Elapsed.Ticks);
            Console.WriteLine("AC #6 Elapsed Time: {0} ms", swSix.Elapsed.Ticks);
            Console.WriteLine("AC #7 Elapsed Time: {0} ms", swSeven.Elapsed.Ticks);
            Console.WriteLine("AC #8 Elapsed Time: {0} ms", swEight.Elapsed.Ticks);
            WriteBlankLine();
            Console.WriteLine("Stretch Goal 3 A. Elapsed Time: {0} ms", swThreeA.Elapsed.Ticks);
            Console.WriteLine("Stretch Goal 3 B. Elapsed Time: {0} ms", swThreeB.Elapsed.Ticks);
            Console.WriteLine("Stretch Goal 3 C. Elapsed Time: {0} ms", swThreeC.Elapsed.Ticks);
            WriteBlankLine();
            Console.WriteLine("Total Elapsed Time: {0} ms", sw.Elapsed.Ticks);
            WriteBlankLine();
            Console.WriteLine("All Acceptance Criteria Met!");

            Console.Read();
        }

        // Stretch Goal #2 - Allow the application to process entered entries until Ctrl+C is used
        private static void HandleExit()
        {
            var exitEvent = new ManualResetEvent(false);
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                exitEvent.Set();
            };
        }

        private static void WriteHeader()
        {
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine("Welcome to Sandy's String Calculator");
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine();
        }

        private static void WriteExpressIonLabel()
        {
            Console.WriteLine("Expression: ");
        }

        private static void WriteBlankLine()
        {
            Console.WriteLine(" ");
        }

        private static void ExecuteAC_One(Calculator calculator)
        {
            var acOneInputOne = "1";
            var acOneInputTwo = "1,500";
            var acOneInputThree = "1,ccc,500";
            var acOneTitle = "AC #1";
            var acOneDescription =
                "Support a maximum of 2 numbers using a comma delimiter examples: 20 will return 20;\\n 1,5000 will return 5001 invalid/missing numbers should be converted to 0 \n e.g. \"\" will return 0; 5,tytyt will return 5";
            var acOneInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}", acOneInputOne, calculator.Add(acOneInputOne)),
                string.Format("Input: {0} | Output: {1}", acOneInputTwo, calculator.Add(acOneInputTwo)),
                string.Format("Input: {0} | Output: {1}", acOneInputThree, calculator.Add(acOneInputThree))
            };

            WriteToConsole(acOneTitle, acOneDescription, acOneInputs);
        }

        private static void ExecuteAC_Two(Calculator calculator)
        {
            var acTwoInputOne = "1,2,3,4,5,6,7,8,9,10,11,12";
            var acTwoTitle = "AC #2";
            var acTwoDescription =
                string.Format("Support an unlimited number of numbers e.g. {0} will return 78", acTwoInputOne);

            var acTwoInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}", acTwoInputOne, calculator.Add(acTwoInputOne))
            };

            WriteToConsole(acTwoTitle, acTwoDescription, acTwoInputs);
        }

        private static void ExecuteAC_Three(Calculator calculator)
        {
            var acThreeInputOne = "1\n2,3";
            var acThreeTitle = "AC #3";
            var acThreeDescription =
                "Support a newline character as an alternative delimiter e.g. 1\\n2,3 will return 6";
            var acThreeInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}", acThreeInputOne, calculator.Add(acThreeInputOne))
            };

            WriteToConsole(acThreeTitle, acThreeDescription, acThreeInputs);
        }

        private static void ExecuteAC_Four(Calculator calculator)
        {
            var acFourInputOne = "23,-465";
            var acFourTitle = "AC #4";
            var acFourDescription =
                "Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided";
            try
            {
                var acFourInputs = new List<string>
                {
                    string.Format("Input: {0} | Output: {1}", acFourInputOne, calculator.Add(acFourInputOne))
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

        private static void ExecuteAC_Five(Calculator calculator)
        {
            var acFiveInputOne = "2,1001,6";
            var acFiveTitle = "AC #5";
            var acFiveDescription =
                "Ignore any number greater than 1000 e.g. 2,1001,6 will return 8";
            var acFiveInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}", acFiveInputOne, calculator.Add(acFiveInputOne))
            };

            WriteToConsole(acFiveTitle, acFiveDescription, acFiveInputs);
        }

        private static void ExecuteAC_Six(Calculator calculator)
        {
            var acSixInputOne = "//;\n2;5";
            var acSixTitle = "AC #6";
            var acSixDescription =
                "Support 1 custom single character length delimiter use the format: //{delimiter}\\n{numbers} e.g. //;\\n2;5 will return 7 all previous formats should also be supported";
            var acSixInputs = new List<string>
            {
                string.Format("Input: {0}| Output: {1}", acSixInputOne, calculator.Add(acSixInputOne))
            };

            WriteToConsole(acSixTitle, acSixDescription, acSixInputs);
        }

        private static void ExecuteAC_Seven(Calculator calculator)
        {
            var acSevenInputOne = "//[***][\n]11***22***33";
            var acSevenTitle = "AC #7";
            var acSevenDescription =
                "Support 1 custom delimiter of any lengthuse the format: //[{delimiter}]\n{numbers} e.g. //[***][\n]11***22***33 will return 66 all previous formats should also be supported";
            var acSevenInputs = new List<string>
            {
                string.Format("Input: {0} | Output: =: {1}", acSevenInputOne, calculator.Add(acSevenInputOne))
            };

            WriteToConsole(acSevenTitle, acSevenDescription, acSevenInputs);
        }

        private static void ExecuteAC_Eight(Calculator calculator)
        {
            var acEightInputOne = "//[*][!!][r9r]\n11r9r22*33!!44";
            var acEightTitle = "AC #8";
            var acEightDescription =
                "Support multiple delimiters of any length use the format: //[{delimiter1}][{delimiter2}]...\n{numbers} e.g. //[*][!!][r9r]\n11r9r22*33!!44 will return 110 all previous formats should also be supported";
            var acEightInputs = new List<string>
            {
                string.Format("Input: {0} | Output: =: {1}", acEightInputOne, calculator.Add(acEightInputOne))
            };

            WriteToConsole(acEightTitle, acEightDescription, acEightInputs);
        }

        private static void ExecuteStretchGoal3A(Calculator calculator)
        {
            var ac3CInputOne = "5\t5\t5";
            var ac3CTitle = "StretchGoal 3C";
            var ac3CDescription = "Alternate delimiter in step #3";
            var ac3CInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}", ac3CInputOne, calculator.Add(ac3CInputOne, 9000))
            };

            WriteToConsole(ac3CTitle, ac3CDescription, ac3CInputs);
        }

        private static void ExecuteStretchGoal3B(Calculator calculator)
        {
            var acSTR3BInputOne = "23,-465";
            var acSTR3BTitle = "StretchGoal 3B";
            var acSTR3BDescription =
                "Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided";
            try
            {
                var acSTR3BInputs = new List<string>
                {
                    string.Format("Input: {0} | Output: {1}", acSTR3BInputOne, calculator.Add(acSTR3BInputOne))
                };
                WriteToConsole(acSTR3BTitle, acSTR3BDescription, acSTR3BInputs);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(Constants.ConsoleLine);
                Console.WriteLine("{0}", acSTR3BTitle);
                Console.WriteLine(Constants.ConsoleLine);
                Console.WriteLine("{0}", acSTR3BDescription);
                Console.WriteLine(Constants.ConsoleLine);
                Console.WriteLine("Exception Occurred: Input: {0} | Output: {1}", acSTR3BInputOne, ex.Message);
                Console.WriteLine(Constants.ConsoleLine);
            }
        }

        private static void ExecuteStretchGoal3C(Calculator calculator)
        {
            var ac3CInputOne = "1000,1000";
            var ac3CTitle = "StretchGoal 3C";
            var ac3CDescription = "upper bound in step #5";
            var ac3CInputs = new List<string>
            {
                string.Format("Input: {0} | Output: {1}", ac3CInputOne, calculator.Add(ac3CInputOne, 9000))
            };

            WriteToConsole(ac3CTitle, ac3CDescription, ac3CInputs);
        }

        private static void WriteToConsole(string title, string description, List<string> inputs)
        {
            WriteBlankLine();
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine(title);
            Console.WriteLine(Constants.ConsoleLine);
            Console.WriteLine(description);
            Console.WriteLine(Constants.ConsoleLine);
            inputs.ForEach(input => { Console.WriteLine(input); });
            Console.WriteLine(Constants.ConsoleLine);
            WriteBlankLine();
        }
    }
}