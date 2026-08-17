using System;

namespace ExpenseTracker.Controller
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Models.DTOs;
    using ExpenseTracker.Services;
    using ExpenseTracker.View;

    /// <summary>
    /// Coordinates transaction-related operations between the console view and services.
    /// </summary>
    internal class TransactionController
    {
        private IncomeService _incomeService;
        private ExpenseService _expenseService;
        private ITransactionService _service;
        private ConsoleView _console;
        private TransactionType _currentType;
        private int? _choice;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        /// <param name="console">The console view used to receive input and display output.</param>
        /// <param name="incomeService">The service responsible for income operations.</param>
        /// <param name="expenseService">The service responsible for expense operations.</param>
        public TransactionController(ConsoleView console, IncomeService incomeService, ExpenseService expenseService)
        {
            this._console = console;
            this._incomeService = incomeService;
            this._expenseService = expenseService;
        }

        /// <summary>
        /// Starts the main application loop and processes menu selections until the user exits.
        /// </summary>
        public void Initialize()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Thread.Sleep(1000); // 1 min delay to show the error message to the users.
                Console.Clear();
                this._console.DisplayMainMenu();
                this._choice = this._console.GetChoice();

                if (this._choice is null)
                {
                    continue;
                }

                if (this._choice is (int)Enums.MainMenu.Add || this._choice is (int)Enums.MainMenu.Exit)
                {
                    this._console.DisplayMessage("Transaction list is currently empty. Please add a transaction first.");
                    continue;
                }

                switch ((Enums.MainMenu)this._choice)
                {
                    case Enums.MainMenu.Add:
                        this.AddTransaction();
                        break;

                    case Enums.MainMenu.Search:
                        this.SearchTransaction();
                        break;

                    case Enums.MainMenu.Sort:
                        this.SortTransaction();
                        break;

                    case Enums.MainMenu.Manage:
                        this.ManageTransaction();
                        break;

                    case Enums.MainMenu.Summary:
                        this.Summarize();
                        break;

                    case Enums.MainMenu.Exit:
                        this._console.DisplayExit();
                        isRunning = false;
                        break;

                    default:
                        this._console.DisplayInvalidInput("Invalid input menu!");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the transaction-management menu and executes the selected operation.
        /// </summary>
        public void ChooseOperation()
        {
            ManageTransaction operation;
            bool isManageMode = true;
            while (isManageMode)
            {
                operation = this._console.ManageTransactionMenu();
                switch ((Enums.ManageTransaction)operation)
                {
                    case Enums.ManageTransaction.View:
                        if (this.IsEmpty())
                        {
                            this._console.DisplayEmpty();
                        }
                        else
                        {
                            this.View();
                        }

                        break;

                    case Enums.ManageTransaction.Update:
                        if (this.IsEmpty())
                        {
                            this._console.DisplayEmpty();
                        }
                        else
                        {
                            this.Edit();
                        }

                        break;

                    case Enums.ManageTransaction.Delete:
                        if (this.IsEmpty())
                        {
                            this._console.DisplayEmpty();
                        }
                        else
                        {
                            this.Delete();
                        }

                        break;

                    case Enums.ManageTransaction.Back:
                        this._console.DisplayMessage("Back to Main Menu");
                        isManageMode = false;
                        return;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Creates and adds a new income or expense transaction.
        /// </summary>
        public void AddTransaction()
        {
            decimal? amount = this._console.GetAmount(false);
            if (amount == null)
            {
                return;
            }

            DateOnly? date = this._console.GetDate(false);
            if (date == null)
            {
                return;
            }

            this._currentType = this._console.ChooseCategory();

            try
            {
                if (this._currentType == Enums.TransactionType.Income)
                {
                    AddIncomeDto dto = new AddIncomeDto()
                    {
                        Amount = amount.Value,
                        Date = date.Value,
                        Source = this._console.GetIncomeSource(),
                    };

                    this._incomeService.Add(dto);
                    this._service = this._incomeService;
                }
                else
                {
                    AddExpenseDto dto = new AddExpenseDto()
                    {
                        Amount = amount.Value,
                        Date = date.Value,
                        Category = this._console.GetExpenseCategory(),
                    };

                    this._expenseService.Add(dto);
                    this._service = this._expenseService;
                }

                this._console.DisplaySuccess("Addition", "transaction");
            }
            catch (ArgumentException exception)
            {
                this._console.DisplayMessage(exception.Message);
            }
        }

        /// <summary>
        /// Searches for transactions based on user-selected criteria and displays the results.
        /// </summary>
        public void SearchTransaction()
        {
            this._service = this._incomeService;
            Enums.SearchBy option = this._console.ChooseSearchBy();

            switch (option)
            {
                case Enums.SearchBy.TransactionId:
                    string? transactionId = this._console.GetTransactionId();
                    TransactionDto? transactionDto = this._incomeService.Get(transactionId);
                    if (transactionDto is null)
                    {
                        this._console.DisplayMessage("Transaction doesn't exist!");
                    }
                    else
                    {
                        this._console.DisplayTransaction(transactionDto);
                    }

                    break;

                case Enums.SearchBy.IncomeSource:
                    Enums.IncomeSource source = this._console.GetIncomeSource();
                    IReadOnlyList<IncomeDto> income = this._incomeService.GetTransactionByIncomeSource(source);
                    if (income.Count == 0)
                    {
                        this._console.DisplayMessage("No transactions found for the specified source.");
                    }
                    else
                    {
                        this._console.DisplayTransactionList(income);
                    }

                    break;

                case Enums.SearchBy.ExpenseCategory:
                    Enums.ExpenseCategory category = this._console.GetExpenseCategory();
                    IReadOnlyList<ExpenseDto> expenses = this._expenseService.GetTransactionByExpenseCategory(category);
                    if (expenses.Count == 0)
                    {
                        this._console.DisplayMessage("No transactions found for the specified category.");
                    }
                    else
                    {
                        this._console.DisplayTransactionList(expenses);
                    }

                    break;

                default:
                    this._console.DisplayMessage("Invalid search option.");
                    break;
            }
        }

        /// <summary>
        /// Sorts transactions based on user-selected criteria and displays the sorted list.
        /// </summary>
        public void SortTransaction()
        {
            this._service = this._incomeService;

            Enums.SortBy option = this._console.ChooseSortBy();
            Enums.Order order = this._console.ChooseOrderBy();

            switch (option)
            {
                case Enums.SortBy.Amount:
                    IReadOnlyList<TransactionDto> sortedByAmount = this._service.SortByAmount(order);
                    this._console.DisplayTransactionList(sortedByAmount);
                    break;

                case Enums.SortBy.Date:
                    IReadOnlyList<TransactionDto> sortedByDate = this._service.SortByDate(order);
                    this._console.DisplayTransactionList(sortedByDate);
                    break;

                case Enums.SortBy.TransactionId:
                    IReadOnlyList<TransactionDto> sortedById = this._service.SortByTransactionId(order);
                    this._console.DisplayTransactionList(sortedById);
                    break;
            }
        }

        /// <summary>
        /// Selects a transaction type and displays the corresponding transaction-management options.
        /// </summary>
        public void ManageTransaction()
        {
            this._currentType = this._console.ChooseCategory();

            if (this._currentType == Enums.TransactionType.Income)
            {
                this._service = this._incomeService;
            }
            else
            {
                this._service = this._expenseService;
            }

            if (this.IsEmpty())
            {
                this._console.DisplayEmpty();
                return;
            }

            this.View();
            this.ChooseOperation();
        }

        /// <summary>
        /// Displays all transactions for the currently selected transaction type.
        /// </summary>
        public void View()
        {
            if (this._service == null)
            {
                return;
            }

            IReadOnlyList<TransactionDto> transactions = this._service.GetAll();
            this._console.DisplayTransactionList(transactions);
        }

        /// <summary>
        /// Edits transaction
        /// </summary>
        public void Edit()
        {
            this.View();

            if (this._service is null)
            {
                return;
            }

            string? transactionId = this._console.GetTransactionId();

            if (string.IsNullOrWhiteSpace(transactionId))
            {
                this._console.DisplayMessage("Invalid transaction id!");
                return;
            }

            TransactionDto? transaction = this._service.Get(transactionId);

            if (transaction is null)
            {
                this._console.DisplayMessage("Transaction doesn't exist!");
                return;
            }

            this._console.DisplayTransaction(transaction);

            if (this._currentType == TransactionType.Income)
            {
                IncomeDto dto = this._console.EditIncome(transaction);

                this._incomeService.Edit(transactionId, dto);
            }
            else
            {
                ExpenseDto dto = this._console.EditExpense(transaction);

                this._expenseService.Edit(transactionId, dto);
            }

            this._console.DisplaySuccess("Update", transactionId);
        }

        /// <summary>
        /// Retrieves and deletes a transaction based on its identifier.
        /// </summary>
        public void Delete()
        {
            this.View();
            string? transactionId = this._console.GetTransactionId() ?? string.Empty;
            if (transactionId == null || transactionId == string.Empty)
            {
                this._console.DisplayMessage("Invalid transaction id!");
            }

            TransactionDto? transaction = this._service.Get(transactionId);

            if (transaction == null)
            {
                this._console.DisplayMessage("Transaction doesn't exists!");
            }
            else
            {
                this._service.Delete(transactionId);
                this._console.DisplaySuccess("Deletion", $"{transactionId}");
            }
        }

        /// <summary>
        /// Calculates and displays a summary of total income, total expenses, and the resulting balance.
        /// </summary>
        public void Summarize()
        {
            decimal totalIncome = this._incomeService.GetTotalIncome();
            decimal totalExpense = this._expenseService.GetTotalExpense();
            decimal balance = totalIncome - totalExpense;

            this._console.DisplaySummary(totalIncome, totalExpense, balance);
        }

        /// <summary>
        /// Determines whether there are no transactions for the currently selected type.
        /// </summary>
        /// <returns>True, transactions are empty else false</returns>
        public bool IsEmpty()
        {
            IReadOnlyList<TransactionDto> transactions = this._service.GetAll();
            return transactions.Count == 0;
        }
    }
}