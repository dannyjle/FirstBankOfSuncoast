using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBankOfSuncoast
{

    class Transaction
    {

        // Then we’re going to create a Transaction Class for pulling information from the list we are going to create that includes: 
        // A Method for TotalAmount
        // A Method for SavingAccount  
        // A Method for Checking Account
        // A Method for WhenChanged


        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public int ComputeAmount()
        {
            var startAmount = 0 + Amount;
            return startAmount;
        }


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

            var allTransaction = new List<Transaction>();


            // var allCheckingTransactions = Transaction.Where
            //var allCheckingDeposit = allCheckingTransactions.Where


            // Then we are going to create a boolean statement to run a “While” loop for our program.
            var whileRunning = true;

            while (whileRunning)


            {
                //Then we will proceed to make a simple menu screen where the under can select to [B]alance, make a [D]eposit, make [W]ithdraw, Access [T]ransaction, or [Q]uit. (make readline.ToUpper();)
                Console.WriteLine();
                Console.Write("What do you want to do? [D]eposit, [W]ithdrawl, [B]alance, [T]ransaction History, or [Q]uit ? ");
                var answer = Console.ReadLine().ToUpper();
                Console.WriteLine();



                //IF DEPOSIT 
                if (answer == "D")
                {
                    var transaction = new Transaction();


                    Console.WriteLine();
                    Console.Write("What do you want to do? Deposit in your [S]avings Account or [C]heckings Account? ");
                    var choice = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (choice == "S")
                    {
                        transaction.Amount = PromptForInteger("How much money did you want to deposit into you Savings accout? ");
                        transaction.TransactionType = "Deposit";
                        transaction.AccountType = "Saving";
                        transaction.DateAdded = DateTime.Now;

                        Console.WriteLine();
                        Console.WriteLine($"The deposit amount of -${transaction.Amount}- will be added to your Account!");
                        Console.WriteLine();


                        allTransaction.Add(transaction);


                    }

                    else if (choice == "C")
                    {
                        transaction.Amount = PromptForInteger("How much money did you want to deposit into your Checkings Account? ");
                        transaction.TransactionType = "Deposit";
                        transaction.AccountType = "Checking";
                        transaction.DateAdded = DateTime.Now;


                        Console.WriteLine();
                        Console.WriteLine($"The deposit amount of -${transaction.Amount}- will be added to your Account!");
                        Console.WriteLine();

                        allTransaction.Add(transaction);
                    }
                }

                //IF WITHDRAW 
                else if (answer == "W")
                {
                    var transaction = new Transaction();

                    Console.WriteLine();
                    Console.Write("What do you want to do? Withdraw from your [S]avings Account or [C]heckings Account? ");
                    var choice = Console.ReadLine().ToUpper();
                    Console.WriteLine();



                    if (choice == "S")
                    {

                        transaction.Amount = PromptForInteger("How much money did you want withdraw from your Savings Accout? ");
                        transaction.TransactionType = "Withdraw";
                        transaction.AccountType = "Saving";
                        transaction.DateAdded = DateTime.Now;

                        Console.WriteLine();
                        Console.WriteLine($"The amount of -${transaction.Amount}- has been taken be added to your Account!");
                        Console.WriteLine();


                        var savingWithdraw = allTransaction.Where(withdraw => withdraw.AccountType == "Saving").Where(withdraw => withdraw.TransactionType == "Deposit").Sum(withdraw => transaction.Amount - withdraw.Amount);
                        allTransaction.Add(transaction);

                        var foundDeposits = allTransaction.Where(fd => fd.TransactionType == "Deposit").Sum(fd => fd.Amount);
                        var foundWithdraw = allTransaction.Where(fw => fw.TransactionType == "Withdraw").Sum(fw => fw.Amount);
                        var savingBalance = $"{foundDeposits - foundWithdraw}";

                        Console.WriteLine($"You have {savingBalance} in your Savings Account");


                    }


                    else if (choice == "C")
                    {
                        transaction.Amount = PromptForInteger("How much money did you want withdraw from your Savings accout? ");
                        transaction.TransactionType = "Withdraw";
                        transaction.AccountType = "Saving";
                        transaction.DateAdded = DateTime.Now;

                        Console.WriteLine();
                        Console.WriteLine($"The amount of -${transaction.Amount}- has been taken be added to your Account!");
                        Console.WriteLine();


                        var checkingWithdraw = allTransaction.Where(withdraw => withdraw.AccountType == "Checking").Where(withdraw => withdraw.TransactionType == "Deposit").Sum(withdraw => transaction.Amount - withdraw.Amount);
                        allTransaction.Add(transaction);

                        var foundDeposits = allTransaction.Where(fd => fd.TransactionType == "Deposit").Sum(fd => fd.Amount);
                        var foundWithdraw = allTransaction.Where(fw => fw.TransactionType == "Withdraw").Sum(fw => fw.Amount);
                        var checkingBalance = $"{foundDeposits - foundWithdraw}";

                        Console.WriteLine($"You have {checkingBalance} in your Checkings Account");

                    }
                }





                // IF Balance 
                else if (answer == "B")
                {

                    Console.WriteLine();
                    Console.Write("Which do you want to view, the [S]avings Account or [C]heckings Account? ");
                    var accountChoice = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (accountChoice == "S")
                    {
                        var foundDeposits = allTransaction.Where(fd => fd.TransactionType == "Deposit").Sum(fd => fd.Amount);
                        var foundWithdraw = allTransaction.Where(fw => fw.TransactionType == "Withdraw").Sum(fw => fw.Amount);
                        var savingBalance = $"{foundDeposits - foundWithdraw}";

                        Console.WriteLine($"You have {savingBalance} in your Savings Account");

                    }

                    else if (accountChoice == "C")
                    {

                        var foundDeposits = allTransaction.Where(fd => fd.TransactionType == "Deposit").Sum(fd => fd.Amount);
                        var foundWithdraw = allTransaction.Where(fw => fw.TransactionType == "Withdraw").Sum(fw => fw.Amount);
                        var checkingBalance = $"{foundDeposits - foundWithdraw}";

                        Console.WriteLine($"You have {checkingBalance} in your Checkings Account");

                    }

                }

                //IF Transaction 
                // else if (answer == "T")
                // { 

                // }




                //IF Quit 
                else if (answer == "Q")
                {
                    whileRunning = false;
                    Console.WriteLine("THANKS FOR BANKING WITH SDG.... GOODBYE :)");
                }
            }
        }
    }
}