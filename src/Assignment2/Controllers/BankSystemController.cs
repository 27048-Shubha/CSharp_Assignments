using Assignment2.Models.Task3;
using Assignment2.Services;
using Assignment2.Views;
using System;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Manages Banking System's Operation Between Views and Service.
    /// </summary>
    public class BankSystemController
    {
        private BankSystemView _console = new BankSystemView();
        private BankSystemService _service = new BankSystemService();

        private bool _isSavings = false;

        /// <summary>
        /// Handles Inputs for Account Creation.
        /// </summary>
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
                        _console.InvalidInput();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles Deposit & Withdrawal Functionalities.
        /// </summary>
        /// <param name="account">BankAccount object holding either Savings or Checking Account.</param>
        public void CallService(BankAccount account)
        {
            char choice;
            string? amount;

            while (true)
            {
                _console.DisplayAccountMenu();
                
                choice = _console.GetMenuInput();

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        amount = _console.GetDepositAmount();
                        if (_service.DepositAmount(account, amount))
                        {
                            _console.DepositSuccessMessage(amount);
                        }
                        else
                        {
                            _console.InvalidInput();
                        }
                        //account.Deposit(amount);
                        break;

                    case 'W':
                    case 'w':
                        amount = _console.GetWithdrawAmount();
                        //if (account.Withdraw(amount))
                        if(_service.WithdrawAmount(account, amount))
                        {
                            _console.WithdrawSuccessMessage(amount);
                        }
                        else
                        {
                            _console.WithdrawFailureMessage();
                        }

                        decimal amountDecimal = _service.CheckBalance(account);
                        _console.DisplayBalance(amountDecimal);

                        if(_isSavings)
                        {
                            _console.DisplayMinBalanceWarning();
                        }

                        break;

                    case 'B':
                    case 'b':
                        amountDecimal = _service.CheckBalance(account);
                        _console.DisplayBalance(amountDecimal);
                        break;

                    case 'Q':
                    case 'q':
                        _console.DisplayExitMessage();
                        return;

                    default:
                        // Display invalid option message
                        _console.InvalidInput();
                        break;
                }
            }
        }
    }
}