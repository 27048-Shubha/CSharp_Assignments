using Assignment2.Models.Task3;
using Assignment2.Services;
using Assignment2.Views;
using System;

namespace Assignment2.Controllers
{
    public class BankSystemController
    {
        private BankSystemView _console = new BankSystemView();
        private BankSystemService _service = new BankSystemService();

        private bool _isSavings = false;
        public void Initialize()
        {
            BankAccount account = null;
            char choice;
            int amount;

            while (true)
            {
                _console.DisplayMenu();
                choice = _console.GetMenuInput();

                switch (choice)
                {
                    case 'S':
                    case 's':
                        account = _service.CreateSavingsAccount();
                        this.CallService(account);
                        _isSavings = true;
                        break;

                    case 'C':
                    case 'c':
                        account = _service.CreateCheckingAccount();
                        this.CallService(account);
                        break;

                    case 'Q':
                    case 'q':
                        return;

                    default:
                        // Display invalid option message
                        break;
                }
            }
        }

        public void CallService(BankAccount account)
        {
            char choice;
            decimal amount;

            while (true)
            {
                _console.DisplayAccountMenu();
                choice = _console.GetMenuInput();

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        amount = _console.GetDepositAmount();
                        account.Deposit(amount);
                        break;

                    case 'W':
                    case 'w':
                        amount = _console.GetWithdrawAmount();
                        if (account.Withdraw(amount))
                        {
                            _console.WithdrawSuccessMessage(amount);
                        }
                        else
                        {
                            _console.WithdrawFailureMessage();
                        }
                        amount = _service.CheckBalance(account);
                        _console.DisplayBalance(amount);

                        if(_isSavings)
                        {
                            _console.DisplayMinBalanceWarning();
                        }

                        break;

                    case 'B':
                    case 'b':
                        amount = _service.CheckBalance(account);
                        _console.DisplayBalance(amount);
                        break;

                    case 'Q':
                    case 'q':
                        return;

                    default:
                        // Display invalid option message
                        break;
                }
            }
        }
    }
}