using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDBankkonto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBankkonto.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        [DataRow(1000, true)]
        [DataRow(50, true)]
        [DataRow(-100, false)]
        [DataRow(0, false)]
        public void IsTransactionPositiveTest(int deposit, bool expected)
        {
            var BankAccount = new BankAccount();

            var result = BankAccount.IsTransactionPositive(deposit);

            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        [DataRow(1000, 500, true)]
        [DataRow(200, 100, true)]
        [DataRow(10000, 4000, true)]
        [DataRow(200, 800, false)]
        [DataRow(0, 10000, true)]
        [DataRow(-2000, 10000, true)]
        public void DenyTransactionTest(double withdraw, double balance, bool expected)
        {
            var BankAccount = new BankAccount();
            BankAccount.Balance = balance;

            var result = BankAccount.DenyTransaction(withdraw);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(true, true)]
        [DataRow(false, false)]
        public void AccountHasCreditTest(bool HasCredit, bool expected)
        {
            var BankAccount = new BankAccount();
            var result = BankAccount.AccountHasCredit(HasCredit);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(1000, 800, 100, true)]
        [DataRow(500, 1000, 200, false)]
        public void DenyWithdrawWithCreditTest(double withdraw, double balance, double credit, bool expected)
        {
            var BankAccount = new BankAccount();
            BankAccount.Balance = balance;
            BankAccount.Credit = credit;

            var result = BankAccount.DenyWithdrawWithCredit(withdraw);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(false, false)]
        [DataRow(true, true)]
        public void AccountHasSwishTest(bool HasSwish, bool expected)
        {
            var BankAccount = new BankAccount();
            BankAccount.HasSwish = HasSwish;
            var result = BankAccount.AccountHasSwish(HasSwish);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(100, 200, true)]
        public void MakeSwishPaymentTest(double paymentAmount, double allowedAmount, bool expected)
        {
            var BankAccount = new BankAccount();
            BankAccount.MakeSwishPayment();
        }
    }
}