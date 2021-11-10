using System;

namespace TDDBankkonto
{
    public class BankAccount
    {
        public double Balance { get; set; } = 0;
        public bool HasCredit { get; set; } = false;
        public double Credit { get; set; } = 1500;
        public bool HasSwish { get; set; } = false;
        public double AllowedSwishAmount { get; set; } = 3000;
        public bool IsFlagged { get; set; } = false;
        public bool IsSavingsAccount { get; set; } = false;
        public bool IsInvestmentAccount { get; set; } = false;

        public bool IsTransactionPositive(int deposit)
        {
            if (deposit > 0)
            {
                return true;
            }

            return false;
        }

        public bool DenyTransaction(double withdraw)
        {
            if (withdraw > Balance || withdraw <= 0)
            {
                return true;
            }
            return false;
        }

        public bool AccountHasCredit(bool HasCredit)
        {
            if (HasCredit)
            {
                return true;
            }

            return false;
        }

        public bool DenyWithdrawWithCredit(double withdraw)
        {
            if (withdraw > (Balance + Credit) || withdraw <= 0)
            {
                return true;
            }
            return false;
        }

        public bool AccountHasSwish(bool HasSwish)
        {
            if (HasSwish)
            {
                return true;
            }

            return false;
        }

        public void MakeSwishPayment(double SendAmount)
        {
            if (SendAmount < AllowedSwishAmount)
            {
                AllowedSwishAmount -= SendAmount;
            }
        }
    }
}
