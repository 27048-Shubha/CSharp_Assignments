using System;

namespace ExpenseTracker.Controller
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Repository;
    using ExpenseTracker.Services;
    using ExpenseTracker.View;

    internal class TransactionController
    {
        //constructor

        private ITransactionService<Transaction> _service;
        private ConsoleView _console;
        private TransactionType _currentType;

        private int _choice;

        public void Initialize()
        {
            do
            {
                _choice = _console.GetChoice();
                _console.DisplayMainMenu();

                switch ((Enums.MainMenu)_choice)
                {
                    case Enums.MainMenu.Income:
                        this._service = new IncomeService();
                        this._currentType = Enums.TransactionType.Income;
                        this.ChooseOperation();
                        break;

                    case Enums.MainMenu.Expense:
                        //this._service = new ExpenseService();
                        this._currentType = Enums.TransactionType.Expense;
                        break;

                    case Enums.MainMenu.Exit:
                        this._console.DisplayExit();
                        break;

                    default:
                        this._console.DisplayInvalidInput();
                        break;
                }
            }
            while ((Enums.MainMenu)_choice != Enums.MainMenu.Exit);
        }

        public void ChooseOperation()
        {
            this._console.DisplayOperationsMenu();
            int operation = this._console.GetChoice();
            do
            {
                switch ((Enums.OperationsMenu)operation)
                {
                    case Enums.OperationsMenu.Add:
                        if (this.IsEmpty())
                        {
                            _console.DisplayEmpty(_currentType);
                        }
                        else
                        {
                            this.Add();
                        }
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
            TransactionType? category = _console.GetCategory();

            if ((amount == null) || (date == null) || (category == null))
            {
                
            }
            else
            {
                _service.Add(amount, date, category);
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
                _console.EditTransaction(transaction);
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

            if (transactions.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}