namespace ExpenseTracker.View
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Validator;
    using System.Transactions;

    internal class ConsoleView
    {
        public void DisplayMainMenu()
        {
            
        }

        public int? GetChoice()
        {
            Console.WriteLine("Enter your choice: ");
            string input;
            int choice;
            int chances = 0;

            do
            {
                input = Console.ReadLine();
                chances++;
                if (InputValidator.IsValidInt(input, out choice))
                {
                    return choice;
                }
            }
            while (chances < 3);

            this.DisplayInvalidInput("Kindly enter valid choice as input!");
            return null;
        }

        public string? GetTransactionId()
        {
            Console.WriteLine("Enter your choice: ");
            string input = Console.ReadLine();
            return input;
        }

        public decimal? GetAmount()
        {
            Console.WriteLine("Enter your choice: ");
            string input;
            decimal amount;
            int chances = 0;

            do
            {
                input = Console.ReadLine();
                chances++;
                if (InputValidator.IsValidDecimal(input, out amount))
                {
                    return amount;
                }
            }
            while (chances < 3);

            this.DisplayInvalidInput("Amount should be a positive value!");
            return null;
        }

        public DateOnly? GetDate()
        {
            Console.WriteLine("Enter your choice: ");
            string input;
            DateOnly date;
            int chances = 0;

            do
            {
                input = Console.ReadLine();
                chances++;
                if (InputValidator.IsValidDate(input, out date))
                {
                    return date;
                }
            }
            while (chances < 3);

            this.DisplayInvalidInput("Date should be in the format: DD/MM/YYYY !");
            return null;
        }

        public TransactionType? GetCategory()
        {
            Console.WriteLine("Enter your choice: ");
            string input;
            int choice;
            int chances = 0;

            do
            {
                input = Console.ReadLine();
                chances++;
                if (Enum.TryParse<TransactionType> (input, true, out var category))
                {
                    return category;
                }
            }
            while (chances < 3);

            this.DisplayInvalidInput("Kindly enter valid category as input!");
            return null;
        }

        public void DisplayTransaction(IReadOnlyList<Transaction> transaction)
        {
            Console.Write($"{transaction.TransactionId} - {transaction.Date} - {transaction - Amount} - }");
            if (transaction is Expense expense)
            {
                Console.WriteLine($"{expense.Category}");
            }
            else if (transaction is Income income)
            {
                Console.WriteLine($"{income.Source}");
            }
            Console.WriteLine();
        }

        public void DisplayExit()
        {
            Console.WriteLine("Thank you for using Expense Tracker!");
        }

        public void DisplayWarning()
        {
            //Console.WriteLine("Thank you for using Expense Tracker!");
        }

        public void DisplayError()
        {
            //Console.WriteLine("Thank you for using Expense Tracker!");
        }

        public void DisplaySuccess(string operation, string transactionId)
        {
            Console.WriteLine($"{operation} of {transactionId} is Successful!");
        }

        public void DisplayInvalidInput(string message)
        {
            Console.WriteLine($"{message}");
        }

        public void DisplayOperationsMenu()
        {

        }

        public void DisplayEmpty(TransactionType transactionType)
        {
            Console.WriteLine("No Transactions made!");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine($"message");
        }
    }
}
