using ExpenseTracker.Repository;
using ExpenseTracker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.Controller
{
    internal class CashFlowController
    {
        //constructor

        private ITransactionRepository _service;
        private ConsoleView _console;
        public void Initialize()
        {
            _console.DisplayMainMenu();
            int choice = _console.GetChoice();
            switch((Enums.MainMenu)choice)
            {
                case Enums.MainMenu.Income:
                    this._service = new IncomeRepository();
                    break;

                case Enums.MainMenu.Expense:
                    this._service = new ExpenseRepository();
                    break;

                case Enums.MainMenu.Exit:
                    this._console.DisplayExit();
                    break;

                default:
                    this._console.DisplayInvalidInput();
                    break;
            }

            this._console.DisplayOperationsMenu();
            choice = this._console.GetChoice();

            switch ((Enums.OperationsMenu)choice)
            {
                case Enums.OperationsMenu.Add:
                    this.Add();
                    break;

                case Enums.OperationsMenu.View:
                    this.View();
                    break;

                case Enums.OperationsMenu.Edit:
                    this.Edit();
                    break;

                case Enums.OperationsMenu.Delete:
                    this.Delete();
                    break;

                default:
                    break;
            }
        }

        public void Add()
        {
            decimal amount = _console.GetAmount();
            DateOnly date = _console.GetDate();
            Transaction category = _console.GetCategory();

            _service.Add(amount, date, category);
        }
        public void View()
        {
            IReadOnlyList<Transaction> transaction = _service.View();
            _console.DisplayTransaction(transaction);
        }

        public void Edit()
        {
            this.View();
            string transactionId = _console.GetTransactionId();
            Transaction transaction = _service.Get(transactionId);
            if (transaction == null)
            {
                _console.DisplayInvalid("Transaction doesn't exists!");
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
                _console.DisplayInvalid("Transaction doesn't exists!");
            }
            else
            {
                _service.DeleteTransaction(transaction);
                _console.DisplaySuccess("Deletion", $"{transactionId}");
            }
        }
    }
}
