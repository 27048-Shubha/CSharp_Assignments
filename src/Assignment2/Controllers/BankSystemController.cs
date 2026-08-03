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
        private BankSystemView console;
        private BankSystemService service;
        private bool isSavings = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankSystemController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle console operations. </param>
        /// <param name="service"> The object to handle services. </param>
        public BankSystemController(BankSystemView console, BankSystemService service)
        {
            this.console = console;
            this.service = service;
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
                this.console.DisplayMenu();
                choice = this.console.GetUserChoice();

                switch (choice)
                {
                    case 'S':
                    case 's':
                        account = this.service.CreateSavingsAccount();
                        this.CallService(account);
                        this.isSavings = true;
                        break;

                    case 'C':
                    case 'c':
                        account = this.service.CreateCheckingAccount();
                        this.CallService(account);
                        break;

                    case 'Q':
                    case 'q':
                        this.console.DisplayExitMessage();
                        break;

                    default:
                        // Display invalid option message
                        this.console.DisplayDefault();
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
            this.console.DisplayMinBalanceInfo();

            do
            {
                this.console.DisplayAccountMenu();

                choice = this.console.GetUserChoice();

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        amount = this.console.GetDepositAmount();
                        if (this.service.DepositAmount(account, amount))
                        {
                            this.console.DepositSuccessMessage(amount);
                        }
                        else
                        {
                            this.console.DisplayDefault();
                        }

                        break;

                    case 'W':
                    case 'w':
                        amount = this.console.GetWithdrawAmount();
                        if (this.service.WithdrawAmount(account, amount))
                        {
                            this.console.WithdrawSuccessMessage(amount);
                        }
                        else
                        {
                            this.console.WithdrawFailureMessage();
                            this.console.DisplayMinBalanceWarning();
                        }

                        decimal amountDecimal = this.service.CheckBalance(account);
                        this.console.DisplayBalance(amountDecimal);

                        if (this.isSavings)
                        {
                            this.console.DisplayMinBalanceWarning();
                        }

                        break;

                    case 'B':
                    case 'b':
                        amountDecimal = this.service.CheckBalance(account);
                        this.console.DisplayBalance(amountDecimal);
                        break;

                    case 'Q':
                    case 'q':
                        this.console.DisplayExitMessage();
                        return;

                    default:
                        // Display invalid option message
                        this.console.DisplayDefault();
                        break;
                }
            }
            while (choice != 'Q' && choice != 'q');
        }
    }
}