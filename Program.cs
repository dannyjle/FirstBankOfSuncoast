using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{

    class Transaction
    {

        // Then we’re going to create a Transaction Class for pulling information from the list we are going to create that includes: 
        // A Method for TotalAmount
        // A Method for SavingAccount  
        // A Method for Checking Account
        // A Method for WhenChanged


        public string Balance { get; set; }

        public int SavingAccount { get; set; }
        public int CheckingAccount { get; set; }
        public DateTime WhenChanged { get; set; } = DateTime.Now;

    }

    class Program
    {
        // Method to take user's string prompt input
        static string PromptForString(string prompt)
        {


            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        // Method to take user's int prompt input
        // Got this code form the example to make sure inputting something random won't crash program.
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



            //Next we are going to create a list for storing transactions so that we can store information of the account user within the methods.

            var newTransaction = new List<Transaction>();



            // Then we are going to create a boolean statement to run a “While” loop for our program.
            var whileRunning = true;

            while (whileRunning)


            {
                //Then we will proceed to make a simple menu screen where the under can select to [B]alance, make a [D]eposit, make [W]ithdraw, Access [T]ransaction, or [Q]uit. (make readline.ToUpper();)
                Console.WriteLine();
                Console.Write("What do you want to do? [D]eposit, [W]ithdrawl, [T]ransaction, [B]alance, or [Q]uit ? ");
                var answer = Console.ReadLine().ToUpper();
                Console.WriteLine();



                //IF DEPOSIT 
                if (answer == "D")
                {
                    var transaction = new Transaction();
                    Console.WriteLine();
                    Console.Write("What do you want to do? Deposit in your [S]aving Account or [C]hecking Account? ");
                    var choice = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (choice == "S")
                    {
                        transaction.SavingAccount = PromptForInteger("How much money did you want to deposit into you Saving accout? ");

                        Console.WriteLine();
                        Console.WriteLine($"The deposit amount of -${transaction.SavingAccount}- will be added to your Account!");
                        Console.WriteLine();

                        newTransaction.Add(transaction);
                    }
                    else
                    {
                        transaction.CheckingAccount = PromptForInteger("How much money did you want to deposit into your Checking account? ");

                        Console.WriteLine();
                        Console.WriteLine($"The deposit amount of -${transaction.CheckingAccount}- will be added to your Account!");
                        Console.WriteLine();

                        newTransaction.Add(transaction);
                    }
                }






            }

        }
    }
}
