using System;
using System.Threading;
using System.Drawing;

namespace Number_Memory_Test
{
    /// Number Recall Test
    /// Jacob M. Smith
    /// v1.0 11-19-2019

    class Program
    {

        // Random Nums
        static private Random random = new System.Random();

        // Create array of random positive intergers with a max of nine
        static public int[] ranNums(int amount)
        {
            // array of random numbers
            int[] nums = new int[amount];

            // add random numbers into array with a for loop
            for (int i = 0; i < amount; i++)
            {
                nums[i] = random.Next(9);
            }

            return nums;
        }

        // Checks user answers
        static public bool results(int[] actualNumbers, int[] userNumbers, int amount, bool testType)
        {
            bool correct = true;

            if (!testType)
            {
                Array.Reverse(actualNumbers);
            }

            // Determine if actualNumbers is equal to userNumbers
            for (int i = 0; i < amount; i++)
            {
                if (actualNumbers[i] != userNumbers[i])
                {
                    correct = false;
                }
            }

            return correct;
        }

        // Gathers the number responses from the user in an interger array form
        static public int[] userInput(int amount)
        {
            int[] answers = new int[amount];

            System.Console.WriteLine("Enter the list of " + amount + " numbers: ");

            string userValues = Console.ReadLine();

            // Move the answers from a string into the interger array
            for (int i = 0; i < amount; i++)
            {
                if (userValues.Length < amount)
                {
                    break;
                }

                char nextValue = userValues[i];
                string answerValue = nextValue.ToString();
                answers[i] = int.Parse(answerValue);

            }

            return answers;
        }

        // Display the array of numbers to be remembered
        // This will become obsolete and updated with GUI
        static public void displaySystem(int[] nums, int amount)
        {
            Console.Clear();

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("---------------------" + nums[i] + "---------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");

                // Thousand Millisecond time delay
                Thread.Sleep(1000);

                Console.Clear();

                Thread.Sleep(1000);
            }
        }

        // administers tests
        static public int adminTest(int amount, bool testType)
        {
            bool correct = true;
            int correctLoops = 0;

            while (correct)
            {
                int[] nums = ranNums(amount);
                displaySystem(nums, amount);
                int[] input = userInput(amount);
                correct = results(nums, input, amount, testType);

                if (!correct)
                {
                    break;
                }

                else
                {
                    correctLoops++;
                    amount++;
                }
            }

            return correctLoops;
        }

        static void Main(string[] args)
        {
            // number of intergers in beginning array
            int amount = 3;

            // which test is being administered 1:forward, 0:reverse
            int testTypeInterger;
            bool testType;

            // the number of times the list is correctly recalled
            //int successes;

            // Instructions
            Console.WriteLine("The following test is an adaptation of a portion of the WAIS memory scale.");
            Console.WriteLine("You will be presented with a list of single digit positive intergers.");
            Console.WriteLine("You will then be tested in one of the following two ways: ");
            Console.WriteLine("1. Recall the list of numbers in the same order they were presented to you.");
            Console.WriteLine("2. Recall the list of numbers in the reverse of the order they were presented to you.");
            Console.WriteLine("Everytime you successfully recall the list the amount of numbers in the list will  increase.");
            Console.WriteLine("You will continue the procedure until you are unable to recall the list correctly.");

            // initiate test
            Console.WriteLine("Are you prepared? (Y/N)");
            string preparedness = Console.ReadLine();

            // start test
            if (preparedness == "Y")
            {

                while (preparedness == "Y")
                {
                    Console.WriteLine("Would you like to recall the list in order(1) or in reverse(0)?");
                    string type = Console.ReadLine();
                    testTypeInterger = int.Parse(type);

                    if (testTypeInterger == 1)
                    {
                        testType = true;
                    }

                    else
                    {
                        testType = false;
                    }

                    // initiate
                    int successes = adminTest(amount, testType);
                    int listSize = successes + 2;

                    Console.WriteLine("Successful recalls: " + successes);
                    Console.WriteLine("List size recalled: " + listSize);
                    Console.WriteLine("Would you like to try again? (Y/N)");
                    preparedness = Console.ReadLine();

                    if (preparedness == "N")
                    {
                        break;
                    }
                }
            }


        }
    }
}
