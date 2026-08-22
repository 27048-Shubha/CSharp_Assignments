using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Validators
{
    /// <summary>
    /// Manages validation operations of the bank system.
    /// </summary>
    public class WithdrawalValidator
    {
        private static readonly decimal MinimumBalance = 100m;

        /// <summary>
        /// Checks whether withdrawal allowed.
        /// </summary>
        /// <param name="balance">Balance amount from the respective account. </param>
        /// <returns>Returns true when current balance is less than the minimum balance else false.</returns>
        public static bool IsBelowMinimumBalance(decimal balance)
        {
            return balance < MinimumBalance;
        }
    }
}
