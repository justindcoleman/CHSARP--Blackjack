using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Week_2_Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool moreCalc = true;

            while (moreCalc)
            {
                string menuChoice = "";
                string mathOneChoice;
                string mathTwoChoice;
                double mathAnswer = 0;
                double mathOne;
                double mathTwo;
                int menuChoiceParsed = 0;
                bool didTryParseWork = false;
                MenuMaker();
                ParseMenuChoice(menuChoice, menuChoiceParsed, ref didTryParseWork);

                if (didTryParseWork == true && (menuChoiceParsed > 0 && menuChoiceParsed < 7))

                #region switches
                {
                    switch (menuChoiceParsed)
                    {
                        case 1:
                            Utilities.Addition(mathOne, mathTwo);
                            break;
                        case 2:
                            Utilities.Subtraction();
                            break;
                        case 3:
                            Utilities.Multipliction();
                            break;
                        case 4:
                            Utilities.Division();
                            break;
                        case 5:
                            Utilities.Square();
                            break;
                        case 6:
                            Utilities.SquareRoot();
                            break;
                        default:
                            break;
                    }
                }
                #endregion
                else
                {
                    Console.WriteLine("Please enter 1-6 only");
                    Console.WriteLine();
                }

                Console.WriteLine(mathAnswer);
            }


        }
        static void MenuMaker()
        {
            Console.WriteLine("Pick an option:\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Square\n6. Square Root");
            Console.WriteLine();
        }

        static bool ParseMenuChoice(string menuChoice, int menuChoiceParsed,ref bool didTryParseWork)
        {
            menuChoice = Console.ReadLine();
            didTryParseWork = int.TryParse(menuChoice, out menuChoiceParsed);
            return didTryParseWork;
        }

        public double userMathVariables(string mathOneChoice, string mathTwoChoice, ref double mathOne, ref double mathTwo)
        {
            Console.WriteLine("Please enter the first number you'd like to math");
            mathOneChoice = Console.ReadLine();
            Console.WriteLine("Please enter the second number you'd like to math");
            mathTwoChoice = Console.ReadLine();
            bool didTryParseWorkMathOne = double.TryParse(mathOneChoice, out mathOne);
            bool didTryParseWorkMathTwo = double.TryParse(mathTwoChoice, out mathTwo);
            if (didTryParseWorkMathOne == true && didTryParseWorkMathTwo == true)
            {
                Console.WriteLine("Maths begin now!");
            }
            else if (didTryParseWorkMathOne == false || didTryParseWorkMathTwo == false)
            {
                Console.WriteLine("You have to enter a number.");
            }
            else
            {
                Console.WriteLine("How did you get this error in userMathVariables???");
            }
            return 0;
        }

        bool ContinueCalc()
        {
            return true;
        }
    }
}
