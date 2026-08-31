namespace Assignment2.Controllers
{
    using Assignment2.Models;
    using Assignment2.Repository;
    using Assignment2.Services;
    using Assignment2.Views;

    /// <summary>
    /// Controls menu _service and communicates with _console and _service.
    /// </summary>
    public class BankSystemController
    {
        private BankSystemView _console;
        private BankSystemService _service;
        private bool _isSavings = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankSystemController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle _console operations. </param>
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

            while (true)
            {
                this._console.DisplayMenu();
                choice = this._console.GetUserChoice();

                switch (choice)
                {
                    case 'S':
                    case 's':
                        account = this._service.CreateSavingsAccount();
                        this._isSavings = true;
                        this.CallService(account);
                        break;

                    case 'C':
                    case 'c':
                        account = this._service.CreateCheckingAccount();
                        this._isSavings = false;
                        this.CallService(account);
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
        }

        /// <summary>
        /// Handles Deposit & Withdrawal Functionalities.
        /// </summary>
        /// <param name="account">BankAccount object holding either Savings or Checking Account.</param>
        public void CallService(BankAccount account)
        {
            char choice;
            decimal amount;
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
                            if (this._isSavings)
                            {
                                this._console.DisplayMinBalanceWarning();
                            }
                        }

                        decimal amountDecimal = this._service.CheckBalance(account);
                        this._console.DisplayBalance(amountDecimal);

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