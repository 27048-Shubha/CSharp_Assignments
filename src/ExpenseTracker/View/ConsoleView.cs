namespace ExpenseTracker.View
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models.DTOs;
    using ExpenseTracker.Validator;
    using Spectre.Console;
    using ChartColor = Spectre.Console.Color;

    /// <summary>
    /// Manages console operations of the application.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Display storage options of expense tracker.
        /// </summary>
        public void DisplayStorageOptions()
        {
            Console.WriteLine("Choose\n" +
                "1. In memory storage\n" +
                "2. Json storage");
        }

        /// <summary>
        /// Displays mainmenu options of expense tracker.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Expense Tracker\n" +
                "Enter\n" +
                "1. Add Transaction\n" +
                "2. Manage Transaction\n" +
                "3. Search Transaction\n" +
                "4. Sort\n" +
                "5. Summary\n" +
                "6. Exit");
        }

        /// <summary>
        /// Manages transaction menu.
        /// </summary>
        /// <returns>Value indicating user's choice.</returns>
        public Enums.Storage ChooseStorageChoice()
        {
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                if (Enum.TryParse<Storage>(Console.ReadLine(), true, out var storageType))
                {
                    return storageType;
                }

                this.DisplayInvalidInput($"You have {attempt}/3 attempts left!");
            }

            this.DisplayInvalidInput("Kindly enter valid choice as input!");

            return Enums.Storage.InMemory;
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
        /// Prompts the user to choose a sorting criterion for transactions.
        /// </summary>
        /// <returns>The chosen sorting criterion, or <see cref="SortBy.Invalid"/> when the input is invalid.</returns>
        public SortBy ChooseSortBy()
        {
            Console.WriteLine("Choose Sort By\n" +
                "1. Amount\n" +
                "2. Transaction Id\n" +
                "3. Date");
            if (Enum.TryParse<SortBy>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.SortBy.Invalid;
        }

        /// <summary>
        /// Prompts the user to choose the order in which to sort transactions (ascending or descending).
        /// </summary>
        /// <returns>The chosen order, or <see cref="Order.Ascending"/> when the input is invalid.</returns>
        public Order ChooseOrderBy()
        {
            Console.WriteLine("Choose Order By\n" +
                "1. Ascending (Default) \n" +
                "2. Descending");
            if (Enum.TryParse<Order>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.Order.Ascending;
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
        public TransactionDto EditTransaction(TransactionDto transaction)
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
                    source = Enums.IncomeSource.Others;
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
                    category = Enums.ExpenseCategory.Others;
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
            this.DisplayMessage("Enter date: ");
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
        public Enums.ExpenseCategory GetExpenseCategory()
        {
            Console.WriteLine("Enter Expense Category: ");
            this.ListExpenseCategory();
            if (Enum.TryParse<ExpenseCategory>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.ExpenseCategory.Others;
        }

        /// <summary>
        /// Displays the available income sources and retrieves the user's selection.
        /// </summary>
        /// <returns>The selected income parsedSource, or <see cref="IncomeSource.Others"/> when the input is invalid.</returns>
        public Enums.IncomeSource GetIncomeSource()
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
        /// Displays a summary of total income, total expense, and balance.
        /// </summary>
        /// <param name="totalIncome">Total income amount.</param>
        /// <param name="totalExpense">Total expense amount.</param>
        /// <param name="balance">The balance amount.</param>
        public void DisplaySummary(decimal totalIncome, decimal totalExpense, decimal balance)
        {
            Console.WriteLine("=== Summary ===");
            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Total Expense: {totalExpense}");
            Console.WriteLine($"Balance: {balance}");
        }

        /// <summary>
        /// Displays chart to the console.
        /// </summary>
        /// <param name="totalIncome">Total income generated.</param>
        /// <param name="totalExpense">Total expense generated.</param>
        public void DisplayChart(decimal totalIncome, decimal totalExpense)
        {
            var chart = new BreakdownChart().Width(60).AddItem("Income", (double)totalIncome, ChartColor.Green).AddItem("Expense", (double)totalExpense, ChartColor.Red);

            AnsiConsole.Write(chart);

            AnsiConsole.MarkupLine(
                    $"Balance:[/] {totalIncome - totalExpense:C}");

            Thread.Sleep(1000); // 1 min delay to show the chart to the users.
        }

        /// <summary>
        /// Displays a list of transactions with their identifier, date, amount, and category or source.
        /// </summary>
        /// <param name="transactions">The transactions to display.</param>
        public void DisplayTransactionList(
            IReadOnlyList<TransactionDto> transactions)
        {
            foreach (TransactionDto transaction in transactions)
            {
                this.DisplayTransaction(transaction);
            }
        }

        /// <summary>
        /// Displays a list of transactions with their identifier, date, amount, and category or source.
        /// </summary>
        /// <param name="transactions">The transactions to display.</param>
        public void DisplayTransactionList(
            IReadOnlyList<IncomeDto> transactions)
        {
            foreach (IncomeDto transaction in transactions)
            {
                this.DisplayTransaction(transaction);
            }
        }

        /// <summary>
        /// Displays a list of transactions with their identifier, date, amount, and category or source.
        /// </summary>
        /// <param name="transactions">The transactions to display.</param>
        public void DisplayTransactionList(
            IReadOnlyList<ExpenseDto> transactions)
        {
            foreach (ExpenseDto transaction in transactions)
            {
                this.DisplayTransaction(transaction);
            }
        }

        /// <summary>
        /// Displays a transaction with its identifier, date, amount, and category or parsedSource.
        /// </summary>
        /// <param name="transaction">The transactions to display.</param>
        /// <summary>
        public void DisplayTransaction(TransactionDto transaction)
        {
            Console.WriteLine(
                $"{transaction.TransactionId} - " +
                $"{transaction.Date} - " +
                $"{transaction.Amount} - " +
                $"{transaction.CategoryOrSource.ToString()}");
        }

        /// <summary>
        /// Displays a transaction with its identifier, date, amount, and category or parsedSource.
        /// </summary>
        /// <param name="transaction">The transactions to display.</param>
        /// <summary>
        public void DisplayTransaction(IncomeDto transaction)
        {
            Console.WriteLine(
                $"{transaction.TransactionId} - " +
                $"{transaction.Date} - " +
                $"{transaction.Amount} - " +
                $"{transaction.Source.ToString()}");
        }

        /// <summary>
        /// Displays a transaction with its identifier, date, amount, and category or parsedSource.
        /// </summary>
        /// <param name="transaction">The transactions to display.</param>
        /// <summary>
        public void DisplayTransaction(ExpenseDto transaction)
        {
            Console.WriteLine(
                $"{transaction.TransactionId} - " +
                $"{transaction.Date} - " +
                $"{transaction.Amount} - " +
                $"{transaction.Category.ToString()}");
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

        /// <summary>
        /// Collects updated values for an income transaction from the user.
        /// </summary>
        /// <param name="transaction">
        /// The current transaction values displayed as a DTO.
        /// </param>
        /// <returns>
        /// An <see cref="IncomeDto"/> containing the updated amount,
        /// date, and income source.
        /// </returns>
        public IncomeDto EditIncome(TransactionDto transaction)
        {
            return new IncomeDto
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
        /// An <see cref="ExpenseDto"/> containing the updated amount,
        /// date, and expense category.
        /// </returns>
        public ExpenseDto EditExpense(TransactionDto transaction)
        {
            return new ExpenseDto
            {
                Amount = this.GetAmount(true) ?? transaction.Amount,
                Date = this.GetDate(true) ?? transaction.Date,
                Category = this.GetExpenseCategory(),
            };
        }

        /// <summary>
        /// Prompts the user to choose a search criterion.
        /// </summary>
        /// <returns>The selected search criterion.</returns>
        public Enums.SearchBy ChooseSearchBy()
        {
            Console.WriteLine("Choose Search By\n" +
                "1. Transaction Id\n" +
                "2. Income Source\n" +
                "3. Expense Category");
            if (Enum.TryParse<SearchBy>(Console.ReadLine(), true, out var category))
            {
                return category;
            }

            return Enums.SearchBy.Invalid;
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