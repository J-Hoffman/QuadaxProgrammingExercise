using System;
using System.Linq;

namespace QuadaxProgrammingExercise
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] RandomArray = SetupNewGame();
            Console.WriteLine("Instructions: Enter 4 numbers between 1-6 then press Enter. Example: 3827");

            PrintPasscode(RandomArray);
            for (int GuessCount = 10; GuessCount > 0; GuessCount--)
            {
                string input = Console.ReadLine();
                if (CheckValidity(input))
                {
                    int[] digits = input.Select(digit => int.Parse(digit.ToString())).ToArray();
                    string output = "";

                    for (int i = 0; i < 4; i++)
                    {
                        if (RandomArray.Contains(digits[i]))
                        {
                            if (RandomArray[i] == digits[i])
                            {
                                output += "+";
                            }
                            else
                            {
                                output += "-";
                            }
                        }

                    }
                    Console.WriteLine(output);
                    if (output == "++++")
                    {
                        Console.WriteLine("YOU WIN!!!!!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Remaining Guesses = " + (GuessCount - 1));
                    }
                }
                else
                {
                    Console.WriteLine("Combination is invalid");
                    GuessCount++;
                }
            }
            Console.WriteLine("You are out of guesses. Try again next time.");


        }
        static int[] SetupNewGame()
        {
            int[] digits = new int[4];
            for(int i = 0; i < digits.Length; i++)
            {
                digits[i] = new Random().Next(1, 6);
            }
            return digits;
        }
        static bool CheckValidity(string input)
        {
            int data = 0;
            int[] digits = input.Select(digit => int.Parse(digit.ToString())).ToArray();
            foreach(int digit in digits)
            {
                if (digit < 1 || digit > 6)
                {
                    return false;
                }
            }
            return (int.TryParse(input, out data) && data.ToString().Length == 4);
        }

        static void PrintPasscode(int[] array)
        {
            Console.Write("The Passcode is ");
            foreach (int randomInt in array)
            {
                Console.Write(randomInt);
            }
            Console.WriteLine();
        }
    }
}
