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
        private BankSystemView _console;
        private BankSystemService _service;

        public BankSystemController( BankSystemView _console, BankSystemService _service) 
        { 
            this._console = _console;
            this._service = _service;
        }

        private bool _isSavings = false;

        /// <summary>
        /// Handles Inputs for Account Creation.
        /// </summary>
        public void Initialize()
        {
            BankAccount account = null;
            char choice;
            int amount;

            do
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
                        _console.DisplayExitMessage();
                        break;

                    default:
                        // Display invalid option message
                        _console.InvalidInput();
                        break;
                }
            } while (choice != 'Q' && choice != 'q');
        }

        /// <summary>
        /// Handles Deposit & Withdrawal Functionalities.
        /// </summary>
        /// <param name="account">BankAccount object holding either Savings or Checking Account.</param>
        public void CallService(BankAccount account)
        {
            char choice;
            string? amount;
            _console.DisplayMinBalanceInfo();

            do
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
                            _console.InvalidDepositInput();
                        }
                        break;

                    case 'W':
                    case 'w':
                        amount = _console.GetWithdrawAmount();
                        if(_service.WithdrawAmount(account, amount))
                        {
                            _console.WithdrawSuccessMessage(amount);
                        }
                        else
                        {
                            _console.WithdrawFailureMessage();
                            _console.DisplayMinBalanceWarning();
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
            } while (choice != 'Q' && choice != 'q');
        }
    }
}