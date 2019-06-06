using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{

    class AccessBankAccount
    {

        public string Number { get; set; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactionsList)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        // Private so can only be accessed inside "class BankAccount" and "static" meaning 
        // it is shared by all BankAccount objects.
        // non-Static is unique to each instance of the BankAccount object
        private static int accountNumberSeed = RandomNumber(1000000000, 2147483647);

        // Create a list for all transactions with "Transaction" type
        public List<Transaction> allTransactionsList = new List<Transaction>();

        // Generate random Bank Account Number...
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Constructor - Constructor is a member that has the same name as the 
        // class, and used to initialize objects of that class type. Constructors 
        // are called when you create an object using keyword new
        public AccessBankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactionsList.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactionsList.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in allTransactionsList)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }

        // Need for printing objects...
        public override string ToString()
        {
            return string.Format("{0}, {1}", Owner, Number);
        }

    }
}
