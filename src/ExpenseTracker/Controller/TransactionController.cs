using System;

namespace ExpenseTracker.Controller
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Services;
    using ExpenseTracker.View;

    internal class TransactionController
    {
        private IncomeService _incomeService;
        private ExpenseService _expenseService;
        private ITransactionService _service;
        private ConsoleView _console;
        private TransactionType _currentType;
        private int? _choice;

        public TransactionController(ConsoleView console, IncomeService incomeService, ExpenseService expenseService)
        {
            this._console = console;
            this._incomeService = incomeService;
            this._expenseService = expenseService;
        }

        public void Initialize()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Thread.Sleep(1000); // 1 min delay to show the error message to the users.
                Console.Clear();
                _console.DisplayMainMenu();
                _choice = _console.GetChoice();

                if(_choice is null)
                {
                    continue;
                }

                switch ((Enums.MainMenu)_choice)
                {
                    case Enums.MainMenu.Add:
                        this.AddTransaction();
                        break;

                    case Enums.MainMenu.Manage:
                        this.ManageTransaction();
                        break;

                    case Enums.MainMenu.Summary:
                        //this.Summary();
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

        public void ChooseOperation()
        {
            ManageTransaction operation;
            bool isManageMode = true;
            while(isManageMode)
            {
                operation = this._console.ManageTransactionMenu();
                switch ((Enums.ManageTransaction)operation)
                {
                    case Enums.ManageTransaction.View:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty();
                        }
                        else
                        {
                            this.View();
                        }

                        break;

                    case Enums.ManageTransaction.Update:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty();
                        }
                        else
                        {
                            this.Edit();
                        }

                        break;

                    case Enums.ManageTransaction.Delete:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty();
                        }
                        else
                        {
                            this.Delete();
                        }

                        break;

                    case Enums.ManageTransaction.Back:
                        _console.DisplayMessage("Back to Main Menu");
                        isManageMode = false;
                        return;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Adds new transaction to the transaction list.
        /// </summary>
        public void AddTransaction()
        {
            decimal? amount = this._console.GetAmount(false);
            if (amount == null) { return; }

            DateOnly? date = this._console.GetDate(false);
            if (date == null) { return; }

            this._currentType = this._console.ChooseCategory();

            if (this._currentType == Enums.TransactionType.Income)
            {
                this._service = _incomeService;
                IncomeSource incomeSource = this._console.GetIncomeSource();
                Income income = new Income(IncomeService.GetTransactionId(), amount.Value, date.Value, incomeSource);
                _incomeService.Add(income);
            }
            else
            {
                this._service = _expenseService;
                ExpenseCategory expenseCategory = _console.GetExpenseCategory();
                Expense expense = new Expense(ExpenseService.GetTransactionId(), amount.Value, date.Value, expenseCategory);
                _expenseService.Add(expense);
            }
        }

        public void ManageTransaction()
        {
            this._currentType = this._console.ChooseCategory();

            if (this._currentType == Enums.TransactionType.Income)
            {
                this._service = _incomeService;
            }
            else
            {
                this._service = _expenseService;
            }

            if (this.IsEmpty())
            {
                this._console.DisplayEmpty();
                return;
            }

            this.View();
            this.ChooseOperation();
        }

        public void Add()
        {
            decimal? amount = _console.GetAmount(false);
            DateOnly? date = _console.GetDate(false);
            if ((amount == null) || (date == null))
            {
                return;
            }
            else
            {
                if(_currentType == Enums.TransactionType.Income)
                {
                    IncomeSource incomeSource = _console.GetIncomeSource();
                    Income income = new Income(IncomeService.GetTransactionId(), amount.Value, date.Value, incomeSource);
                    _incomeService.Add(income);
                }
                else
                {
                    ExpenseCategory expenseCategory = _console.GetExpenseCategory();
                    Expense expense = new Expense(ExpenseService.GetTransactionId(), amount.Value, date.Value, expenseCategory);
                    this._service = _incomeService;
                    _expenseService.Add(expense);
                }
            }
        }

        public void View()
        {
            IReadOnlyList<Transaction> transaction = _service.GetAll();
            _console.DisplayTransactionList(transaction);
        }

        public void Edit()
        {
            this.View();
            string transactionId = _console.GetTransactionId();
            Transaction transaction = _service.Get(transactionId);

            if (transaction is null)
            {
                _console.DisplayMessage("Transaction doesn't exists!");
                return;
            }

            _console.DisplayTransaction(transaction);
            Transaction updatedTransaction = _console.EditTransaction(transaction);

            _service.Edit(updatedTransaction);

            _console.DisplaySuccess("updation", transactionId);
        }

        public void Delete()
        {
            this.View();
            string transactionId = _console.GetTransactionId();
            Transaction transaction = _service.Get(transactionId);

            if (transaction == null)
            {
                _console.DisplayMessage("Transaction doesn't exists!");
            }
            else
            {
                _service.DeleteTransaction(transaction);
                _console.DisplaySuccess("Deletion", $"{transactionId}");
            }
        }

        public bool IsEmpty()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAll();
            return transactions.Count == 0;
        }
    }
}