namespace Assignment2.Controllers
{
    using System;
    using Assignment2.Models.Task3;
    using Assignment2.Services;
    using Assignment2.Views;

    /// <summary>
    /// Controls menu service and communicates with console and service.
    /// </summary>
    public class BankSystemController
    {
        private BankSystemView _console;
        private BankSystemService _service;
        private bool _isSavings = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankSystemController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle console operations. </param>
        /// <param name="service"> The object to handle services. </param>
        public BankSystemController(BankSystemView console, BankSystemService service)
        {
            this._console = console;
            this._service = service;
        }

        /// <summary>
        /// Start point of execution of Employee Hierarchy system.
        /// </summary>
        public void Initialize()
        {
            BankAccount account;
            char choice;

            do
            {
                this._console.DisplayMenu();
                choice = this._console.GetUserChoice();

                switch (choice)
                {
                    case 'S':
                    case 's':
                        account = this._service.CreateSavingsAccount();
                        this.CallService(account);
                        this._isSavings = true;
                        break;

                    case 'C':
                    case 'c':
                        account = this._service.CreateCheckingAccount();
                        this.CallService(account);
                        this._isSavings = false;
                        break;

                    case 'B':
                    case 'b':
                        this._console.DisplayExitMessage();
                        return;

                    default:
                        // Display invalid option message
                        this._console.DisplayDefault();
                        break;
                }
            }
            while (choice != 'Q' && choice != 'q');
        }

        /// <summary>
        /// Handles Deposit & Withdrawal Functionalities.
        /// </summary>
        /// <param name="account">BankAccount object holding either Savings or Checking Account.</param>
        public void CallService(BankAccount account)
        {
            char choice;
            string? amount;
            this._console.DisplayMinBalanceInfo();

            while (true)
            {
                this._console.DisplayAccountMenu();

                choice = this._console.GetUserChoice();

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        amount = this._console.GetDepositAmount();
                        if (this._service.DepositAmount(account, amount))
                        {
                            this._console.DepositSuccessMessage(amount);
                        }
                        else
                        {
                            this._console.DisplayDefault();
                        }

                        break;

                    case 'W':
                    case 'w':
                        amount = this._console.GetWithdrawAmount();
                        if (this._service.WithdrawAmount(account, amount))
                        {
                            this._console.WithdrawSuccessMessage(amount);
                        }
                        else
                        {
                            this._console.WithdrawFailureMessage();
                            this._console.DisplayMinBalanceWarning();
                        }

                        decimal amountDecimal = this._service.CheckBalance(account);
                        this._console.DisplayBalance(amountDecimal);

                        if (this._isSavings)
                        {
                            this._console.DisplayMinBalanceWarning();
                        }

                        break;

                    case 'B':
                    case 'b':
                        amountDecimal = this._service.CheckBalance(account);
                        this._console.DisplayBalance(amountDecimal);
                        break;

                    case 'Q':
                    case 'q':
                        this._console.DisplayExitMessage();
                        return;

                    default:
                        // Display invalid option message
                        this._console.DisplayDefault();
                        break;
                }
            }
        }
    }
}