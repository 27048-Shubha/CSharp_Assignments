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
                "4. Exit");
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
                "4. Back\n");

            for (int attempt = 1; attempt <= 3; attempt++)
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
        /// Displays transaction types and retrieves the user's selected transaction type.
        /// </summary>
        /// <returns>The selected transaction type, or <see cref="TransactionType.Invalid"/> when the input is invalid.</returns>
        public Enums.TransactionType ChooseCategory()
        {
            Console.WriteLine("Choose Category\n" +
                "1. Income\n" +
                "2. Expense");
            if (Enum.TryParse<TransactionType>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.TransactionType.Invalid;
        }

        /// <summary>
        /// Displays the current transaction values and allows the user to modify selected values.
        /// </summary>
        /// <param name="transaction">The transaction containing the current values to display and update.</param>
        /// <returns>The transaction containing the updated values.</returns>
        public Transaction EditTransaction(Transaction transaction)
        {
            Console.WriteLine("Please Enter to keep the current value.");
            transaction.Amount = this.GetAmount(true) ?? transaction.Amount;
            transaction.Date = this.GetDate(true) ?? transaction.Date;
            if (transaction is Income income)
            {
                Console.Write($"Source ({income.Source}): ");
                string? input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input) && Enum.TryParse(input, true, out IncomeSource source))
                {
                    income.Source = source;
                }
                else
                {
                    income.Source = Enums.IncomeSource.Others;
                }
            }
            else if (transaction is Expense expense)
            {
                Console.WriteLine($"Category ({expense.Category}): ");
                string? input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input) && Enum.TryParse(input, out ExpenseCategory category))
                {
                    expense.Category = category;
                }
                else
                {
                    expense.Category = Enums.ExpenseCategory.Others;
                }
            }

            return transaction;
        }

        /// <summary>
        /// Retrieves the user's main-menu selection with retry support.
        /// </summary>
        /// <returns>The user's selection if valid, else null</returns>
        public int? GetChoice()
        {
            Console.WriteLine("Enter your choice: ");
            string input;
            int? choice;
            for (int attempt = 1; attempt <= 3; attempt++)
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

        /// <summary>
        /// Retrieves a transaction identifier entered by the user.
        /// </summary>
        /// <returns>The entered transaction identifier, or <see langword="null"/> after three invalid attempts.</returns>
        public string GetTransactionId()
        {
            this.DisplayMessage("Enter Transaction id: ");
            int? choice;
            string input;
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }

                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Kindly enter valid choice as input!");
            return null;
        }

        /// <summary>
        /// Retrieves a valid transaction amount from the user.
        /// </summary>
        /// <param name="isEditMode">Indicates whether the method is being called while editing an existing transaction.</param>
        /// <returns>The entered amount if valid, else null.</returns>
        public decimal? GetAmount(bool isEditMode)
        {
            this.DisplayMessage("Enter amount: ");
            string input;
            decimal amount;
            for(int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine().Trim();
                if(isEditMode && string.IsNullOrEmpty(input))
                {
                    return null;
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

        /// <summary>
        /// Retrieves a valid transaction date from the user.
        /// </summary>
        /// <param name="isEditMode">Indicates whether the method is being called while editing an existing transaction.</param>
        /// <returns>The entered date, else null<returns>
        public DateOnly? GetDate(bool isEditMode)
        {
            this.DisplayMessage("Enter date: ");
            string input;
            DateOnly date;

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine();
                if (!isEditMode && string.IsNullOrEmpty(input))
                {
                    return null;
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

        /// <summary>
        /// Displays the available expense categories and retrieves the user's selection.
        /// </summary>
        /// <returns>The selected expense category</returns>
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

        /// <summary>
        /// Displays the available income sources and retrieves the user's selection.
        /// </summary>
        /// <returns>The selected income source, or <see cref="IncomeSource.Others"/> when the input is invalid.</returns>
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

        /// <summary>
        /// Displays all available income sources.
        /// </summary>
        public void ListIncomeSource()
        {
            var incomeSources = Enum.GetValues<IncomeSource>();
            for(int i=0; i<incomeSources.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {incomeSources[i]}");
            }
        }

        /// <summary>
        /// Displays all available expense categories.
        /// </summary>
        public void ListExpenseCategory()
        {
            var expenseCategories = Enum.GetValues<ExpenseCategory>();
            for (int i = 0; i < expenseCategories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {expenseCategories[i]}");
            }
        }

        /// <summary>
        /// Displays a list of transactions with their identifier, date, amount, and category or source.
        /// </summary>
        /// <param name="transactions">The transactions to display.</param>
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

        /// <summary>
        /// Displays a list of transactions with their identifier, date, amount, and category or source.
        /// </summary>
        /// <param name="transaction">The transactions to display.</param>
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

        /// <summary>
        /// Displays a goodbye message when the application exits.
        /// </summary>
        public void DisplayExit()
        {
            Console.WriteLine("Thank you for using Expense Tracker!");
        }

        /// <summary>
        /// Displays a success message for a completed transaction operation.
        /// </summary>
        /// <param name="operation">The operation that was completed.</param>
        /// <param name="transactionId">The identifier of the affected transaction.</param>
        public void DisplaySuccess(string operation, string transactionId)
        {
            Console.WriteLine($"{operation} of {transactionId} is Successful!");
        }

        /// <summary>
        /// Displays an invalid-input message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void DisplayInvalidInput(string message)
        {
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays a message indicating that no transactions are available.
        /// </summary>
        public void DisplayEmpty()
        {
            Console.WriteLine("No Transactions made!");
        }

        /// <summary>
        /// Displays a general message to the user.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
