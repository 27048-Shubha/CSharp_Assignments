namespace ExpenseTracker.View
{
    using ExpenseTracker.Models;
    using ExpenseTracker.Models.DTOs;
    using ExpenseTracker.Models.Enums;
    using ExpenseTracker.Models.Response;
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
            Console.WriteLine("========================================");
            Console.WriteLine(" EXPENSE TRACKER ");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine(" 1. Add Transaction");
            Console.WriteLine(" 2. Manage Transactions");
            Console.WriteLine(" 3. Exit");
            Console.WriteLine();
            Console.WriteLine("========================================");
        }

        /// <summary>
        /// Manages transaction menu.
        /// </summary>
        /// <returns>Value indicating user's choice.</returns>
        public ManageTransaction ManageTransactionMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         MANAGE TRANSACTIONS            ");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("  1. View");
            Console.WriteLine("  2. Update");
            Console.WriteLine("  3. Delete");
            Console.WriteLine("  4. Back");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.Write("Enter your choice: ");

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                if (Enum.TryParse<ManageTransaction>(Console.ReadLine(), true, out var category))
                {
                    return category;
                }

                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Kindly enter valid choice as input!");

            return ManageTransaction.Invalid;
        }

        /// <summary>
        /// Displays transaction types and retrieves the user's selected transaction type.
        /// </summary>
        /// <returns>The selected transaction type, or <see cref="TransactionType.Invalid"/> when the input is invalid.</returns>
        public TransactionType ChooseCategory()
        {
            Console.WriteLine();
            Console.WriteLine("TRANSACTION TYPE");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Income");
            Console.WriteLine("2. Expense");
            Console.WriteLine("----------------------------------------");
            Console.Write("Enter your choice: ");

            if (Enum.TryParse<TransactionType>(Console.ReadLine(), true, out var category) && Enum.IsDefined(typeof(TransactionType), category))
            {
                return category;
            }

            return TransactionType.Invalid;
        }

        /// <summary>
        /// Displays the current transaction values and allows the user to modify selected values.
        /// </summary>
        /// <param name="transaction">The transaction containing the current values to display and update.</param>
        /// <returns>The transaction containing the updated values.</returns>
        public TransactionResponse EditTransaction(TransactionResponse transaction)
        {
            Console.WriteLine("Please Enter to keep the current value.");
            transaction.Amount = this.GetAmount(true) ?? transaction.Amount;
            transaction.Date = this.GetDate(true) ?? transaction.Date;
            if (transaction.Type == TransactionType.Income)
            {
                IncomeSource source = GetCurrentIncomeSource(transaction.CategoryOrSource);
                Console.Write($"Source ({source}): ");
                string? input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input) && Enum.TryParse(input, true, out IncomeSource parsedSource))
                {
                    source = parsedSource;
                }
                else
                {
                    source = IncomeSource.Others;
                }
            }
            else if (transaction.Type == TransactionType.Expense)
            {
                ExpenseCategory category = GetCurrentExpenseCategory(transaction.CategoryOrSource);
                Console.WriteLine($"Category ({category}): ");
                string? input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input) && Enum.TryParse(input, out ExpenseCategory parsedCategory))
                {
                    category = parsedCategory;
                }
                else
                {
                    category = ExpenseCategory.Others;
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
            string? input;
            int? choice;
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine() ?? string.Empty;
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
        public string? GetTransactionId()
        {
            this.DisplayMessage("Enter Transaction id: ");
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
            string? input;
            decimal amount;
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine().Trim() ?? string.Empty;
                if (isEditMode && string.IsNullOrEmpty(input))
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
            this.DisplayMessage("Enter date (dd/MM/yyyy): ");
            string? input;
            DateOnly date;

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                input = Console.ReadLine() ?? string.Empty;
                if (isEditMode && string.IsNullOrEmpty(input))
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
            Console.WriteLine();
            Console.WriteLine("AVAILABLE EXPENSE CATEGORIES");
            Console.WriteLine("----------------------------------------");

            this.ListExpenseCategory();

            Console.WriteLine("----------------------------------------");
            Console.Write("Category: ");

            if (Enum.TryParse<ExpenseCategory>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return ExpenseCategory.Others;
        }

        /// <summary>
        /// Displays the available income sources and retrieves the user's selection.
        /// </summary>
        /// <returns>The selected income parsedSource, or <see cref="IncomeSource.Others"/> when the input is invalid.</returns>
        public IncomeSource GetIncomeSource()
        {
            Console.WriteLine();
            Console.WriteLine("AVAILABLE INCOME SOURCES");
            Console.WriteLine("----------------------------------------");

            this.ListIncomeSource();

            Console.WriteLine("----------------------------------------");
            Console.Write("Source: ");

            if (Enum.TryParse<IncomeSource>(Console.ReadLine(), true, out var source))
            {
                return source;
            }

            return IncomeSource.Others;
        }

        /// <summary>
        /// Displays all available income sources.
        /// </summary>
        public void ListIncomeSource()
        {
            var incomeSources = Enum.GetValues<IncomeSource>();
            for (int i = 0; i < incomeSources.Length; i++)
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
        public void DisplayTransactionList( IReadOnlyList<TransactionResponse> transactions)
        {
            Console.WriteLine();

            Console.WriteLine(
                "----------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"ID",-12} {"TYPE",-10} {"DATE",-15} {"AMOUNT",-15} {"CATEGORY / SOURCE",-20}");
            Console.WriteLine(
                "----------------------------------------------------------------------------");

            foreach (var transaction in transactions)
            {
                this.DisplayTransaction(transaction);
            }

            Console.WriteLine(
                "----------------------------------------------------------------------------");
        }

        /// <summary>
        /// Displays a transaction with its identifier, date, amount, and category or parsedSource.
        /// </summary>
        /// <param name="transaction">The transactions to display.</param>
        /// <summary>
        public void DisplayTransaction(TransactionResponse transaction)
        {
            Console.WriteLine(
                $"{transaction.TransactionId,-12}" +
                $"{transaction.Type,-10}" +
                $"{transaction.Date,-15}" +
                $"{transaction.Amount,-15}" +
                $"{transaction.CategoryOrSource,-20}");
        }

        /// <summary>
        /// Displays a goodbye message when the application exits.
        /// </summary>
        public void DisplayExit()
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("      THANK YOU FOR USING EXPENSE TRACKER");
            Console.WriteLine("========================================");
        }

        /// <summary>
        /// Displays a success message for a completed transaction operation.
        /// </summary>
        /// <param name="operation">The operation that was completed.</param>
        /// <param name="transactionId">The identifier of the affected transaction.</param>
        public void DisplaySuccess(string operation, string transactionId)
        {
            Console.WriteLine($"{operation} of {transactionId} is successful!");
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

        /// <summary>
        /// Collects updated values for an income transaction from the user.
        /// </summary>
        /// <param name="transaction">
        /// The current transaction values displayed as a DTO.
        /// </param>
        /// <returns>
        /// An <see cref="UpdateIncomeRequest"/> containing the updated amount,
        /// date, and income source.
        /// </returns>
        public UpdateIncomeRequest EditIncome(TransactionResponse transaction)
        {
            return new UpdateIncomeRequest
            {
                Amount = this.GetAmount(true) ?? transaction.Amount,
                Date = this.GetDate(true) ?? transaction.Date,
                Source = this.GetIncomeSource(),
            };
        }

        /// <summary>
        /// Collects updated values for an expense transaction from the user.
        /// </summary>
        /// <param name="transaction">
        /// The current transaction values displayed as a DTO.
        /// </param>
        /// <returns>
        /// An <see cref="UpdateExpenseRequest"/> containing the updated amount,
        /// date, and expense category.
        /// </returns>
        public UpdateExpenseRequest EditExpense(TransactionResponse transaction)
        {
            return new UpdateExpenseRequest
            {
                Amount = this.GetAmount(true) ?? transaction.Amount,
                Date = this.GetDate(true) ?? transaction.Date,
                Category = this.GetExpenseCategory(),
            };
        }

        /// <summary>
        /// Pauses console and waits for user to press any key to continue
        /// </summary>
        public void PauseAndContinue()
        {
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Converts a string into an <see cref="ExpenseCategory"/> value.
        /// </summary>
        /// <param name="value">
        /// The string representation of the expense category.
        /// </param>
        /// <returns>
        /// The parsed expense category if successful; otherwise,
        /// <see cref="ExpenseCategory.Others"/>.
        /// </returns>
        private static ExpenseCategory GetCurrentExpenseCategory(
            string value)
        {
            return Enum.TryParse(
                value,
                ignoreCase: true,
                out ExpenseCategory category)
                ? category
                : ExpenseCategory.Others;
        }

        /// <summary>
        /// Converts a string into an <see cref="IncomeSource"/> value.
        /// </summary>
        /// <param name="value">
        /// The string representation of the income source.
        /// </param>
        /// <returns>
        /// The parsed income source if successful; otherwise,
        /// <see cref="IncomeSource.Others"/>.
        /// </returns>
        private static IncomeSource GetCurrentIncomeSource(
    string value)
        {
            return Enum.TryParse(
                value,
                ignoreCase: true,
                out IncomeSource source)
                ? source
                : IncomeSource.Others;
        }
    }
}
