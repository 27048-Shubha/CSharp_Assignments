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
            do
            {
                _console.DisplayMainMenu();
                _choice = _console.GetChoice();

                switch ((Enums.MainMenu)_choice)
                {
                    case Enums.MainMenu.Income:
                        this._service = this._incomeService;
                        this._currentType = Enums.TransactionType.Income;
                        this.ChooseOperation();
                        break;

                    case Enums.MainMenu.Expense:
                        this._service = this._expenseService;
                        this._currentType = Enums.TransactionType.Expense;
                        this.ChooseOperation();
                        break;

                    case Enums.MainMenu.Exit:
                        this._console.DisplayExit();
                        break;

                    default:
                        this._console.DisplayInvalidInput("Invalid input menu!");
                        break;
                }
            }
            while ((Enums.MainMenu)_choice != Enums.MainMenu.Exit);
        }

        public void ChooseOperation()
        {
            this._console.DisplayOperationsMenu();
            int? operation;
            do
            {
                operation = this._console.GetChoice();
                switch ((Enums.OperationsMenu)operation)
                {
                    case Enums.OperationsMenu.Add:
                        this.Add();
                        break;

                    case Enums.OperationsMenu.View:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty(_currentType);
                        }
                        else
                        {
                            this.View();
                        }
                        break;

                    case Enums.OperationsMenu.Edit:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty(_currentType);
                        }
                        else
                        {
                            this.Edit();
                        }
                        break;

                    case Enums.OperationsMenu.Delete:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty(_currentType);
                        }
                        else
                        {
                            this.Delete();
                        }
                        break;

                    case Enums.OperationsMenu.Back:
                        _console.DisplayMessage("Back to Main Menu");
                        break;

                    default:
                        break;
                }
            }
            while ((Enums.OperationsMenu)operation != Enums.OperationsMenu.Back);
        }

        public void Add()
        {
            decimal? amount = _console.GetAmount();
            DateOnly? date = _console.GetDate();
            if ((amount == null) || (date == null))
            {
                // m
            }
            else
            {
                if(_currentType == Enums.TransactionType.Income)
                {
                    IncomeSource incomeSource = _console.GetIncomeSource().Value;
                    Income income = new Income(IncomeService.GetTransactionId(), amount.Value, date.Value, incomeSource);
                    _service.Add(income);
                }
                else
                {
                    ExpenseCategory expenseCategory = _console.GetExpenseCategory().Value;
                    Expense expense = new Expense(ExpenseService.GetTransactionId(), amount.Value, date.Value, expenseCategory);
                    _service.Add(expense);
                }
            }
        }

        public void View()
        {
            IReadOnlyList<Transaction> transaction = _service.GetAll();
            _console.DisplayTransaction(transaction);
        }

        public void Edit()
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
                transaction = _console.EditTransaction(transaction);
                _service.Edit(transaction);
            }
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
            IReadOnlyList<Transaction> transactions = _service.GetAll();
            return (transactions.Count == 0);
        }
    }
}