using System;

namespace FirstBankOfSuncoast
{

    class Database
    {


        public int TotalAmount { get; set; }

        public string Saving { get; set; }
        public string Checking { get; set; }

    }

    class Program
    {
        // code to take user's string prompt input
        static string PromptForString(string prompt)
        {


            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        // code to take user's int prompt input
        // got this code form the example to make sure inputting something random won't crash program.
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {

            //First we’re creating a greeting/ welcome for “SDG Bank Monies Manager” 

            Console.WriteLine();
            Console.WriteLine(new String('*', 24));
            Console.WriteLine("SDG Bank Monies Manager!");
            Console.WriteLine(new String('*', 24));
            Console.WriteLine();


        }
    }
}
