namespace ExpenseTracker.View
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Validator;

    /// <summary>
    /// Manages console operations of the application.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Displays mainmenu options of expense tracker.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Expense Tracker\n" +
                "Enter\n" +
                "1. Add Transaction\n" +
                "2. Manage Transaction\n" +
                "3. Summary\n" +
                "4. Exit"
                );
        }

        /// <summary>
        /// Manages transaction menu.
        /// </summary>
        /// <returns>Value indicating user's choice.</returns>
        public ManageTransaction ManageTransactionMenu()
        {
            Console.WriteLine("Enter\n" +
                "1. View\n" +
                "2. Update\n" +
                "3. Delete\n" +
                "4. Back\n"
            );

            for (int attempt = 1; attempt < 3; attempt++)
            {
                if (Enum.TryParse<ManageTransaction>(Console.ReadLine(), true, out var category))
                {
                    return category;
                }

                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Kindly enter valid choice as input!");

            return Enums.ManageTransaction.Invalid;
        }

        /// <summary>
        /// Displays and gets transaction menu.
        /// </summary>
        /// <returns>Transaction type choosen by the user</returns>
        public Enums.TransactionType ChooseCategory()
        {
            Console.WriteLine("Choose Category\n" +
                "1. Income\n" +
                "2. Expense"
            );
            if (Enum.TryParse<TransactionType>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.TransactionType.Invalid;
        }

        public Transaction EditTransaction(Transaction transaction)
        {
            Console.WriteLine("Please Enter to keep the current value.");
            transaction.Amount = this.GetAmount(true) ?? transaction.Amount;
            transaction.Date = this.GetDate(true) ?? transaction.Date;
            if (transaction is Income income)
            {
                Console.Write($"Source ({income.Source}): ");
                string? input = Console.ReadLine()?.Trim();

                if(!string.IsNullOrEmpty(input) && Enum.TryParse(input, true, out IncomeSource source))
                {
                    income.Source = source;
                }
            }
            else if(transaction is Expense expense)
            {
                Console.WriteLine($"Category ({expense.Category}): ");
                string? input = Console.ReadLine()?.Trim();

                if(!string.IsNullOrEmpty(input) && Enum.TryParse(input, out ExpenseCategory category))
                {
                    expense.Category = category;
                }
            }

            return transaction;
        }

        public int? GetChoice()
        {
            Console.WriteLine("Enter your choice: ");
            string input;
            int? choice;
            for (int attempt = 1; attempt < 3; attempt++)
            {
                input = Console.ReadLine();
                if (InputValidator.IsValidInt(input, out choice))
                {
                    return choice;
                }

                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Kindly enter valid choice as input!");
            return null;
        }

        public string GetTransactionId()
        {
            this.DisplayMessage("Enter Transaction id: ");
            string input = Console.ReadLine() ?? string.Empty;
            return input;
        }

        public decimal? GetAmount(bool isEditMode)
        {
            this.DisplayMessage("Enter amount: ");
            string input;
            decimal amount;
            for(int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine();
                if(isEditMode && string.IsNullOrEmpty(input))
                {
                    break;
                }
                if (InputValidator.IsValidDecimal(input, out amount))
                {
                    return amount;
                }
                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Amount should be a positive value!");
            return null;
        }

        public DateOnly? GetDate(bool isEditMode)
        {
            this.DisplayMessage("Enter date: ");
            string input;
            DateOnly date;

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine();
                if (isEditMode && string.IsNullOrEmpty(input))
                {
                    break;
                }
                if (InputValidator.IsValidDate(input, out date))
                {
                    return date;
                }
                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Date should be in the format: DD/MM/YYYY !");
            return null;
        }

        public ExpenseCategory GetExpenseCategory()
        {
            Console.WriteLine("Enter Expense Category: ");
            this.ListExpenseCategory();
            if(Enum.TryParse<ExpenseCategory>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.ExpenseCategory.Others;
        }

        public IncomeSource GetIncomeSource()
        {
            Console.WriteLine("Enter Income Source: ");
            this.ListIncomeSource();
            if (Enum.TryParse<IncomeSource>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.IncomeSource.Others;
        }

        public void ListIncomeSource()
        {
            var incomeSources = Enum.GetValues<IncomeSource>();
            for(int i=0; i<incomeSources.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {incomeSources[i]}");
            }
        }

        public void ListExpenseCategory()
        {
            var expenseCategories = Enum.GetValues<ExpenseCategory>();
            for (int i = 0; i < expenseCategories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {expenseCategories[i]}");
            }
        }

        public void DisplayTransactionList(IReadOnlyList<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Console.Write($"{transaction.TransactionId} - {transaction.Date} - {transaction.Amount} - ");
                if (transaction is Expense expense)
                {
                    Console.WriteLine($"{expense.Category}");
                }
                else if (transaction is Income income)
                {
                    Console.WriteLine($"{income.Source}");
                }
            }
        }

        public void DisplayTransaction(Transaction transaction)
        {
            Console.Write($"{transaction.TransactionId} - {transaction.Date} - {transaction.Amount} - ");
            if (transaction is Expense expense)
            {
                Console.WriteLine($"{expense.Category}");
            }
            else if (transaction is Income income)
            {
                Console.WriteLine($"{income.Source}");
            }
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

        public void DisplayEmpty()
        {
            Console.WriteLine("No Transactions made!");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
