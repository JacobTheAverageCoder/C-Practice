using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{

    class Program
    {

        static void Main(string[] args)
        {

            // create a list for all created bank accounts
            List<AccessBankAccount> Blist = new List<AccessBankAccount>();

            Console.WriteLine();
            Console.WriteLine("--== Bank Account Program ==--");
            Console.WriteLine();

            Console.WriteLine("Welcome to Account Creation!");
            Console.Write("Please enter your Name: ");
            string CurName = Console.ReadLine();
            Console.Write("Please enter your Account Ballance: ");
            int CurBalance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You will be asigned a random account number");

            // Create account
            AccessBankAccount account = new AccessBankAccount(CurName, CurBalance);

            // add account to list
            Blist.Add(account);

            // $ is interpolated string expression, so dont have to count arguments after quotes
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
 
            AccessBankAccount DummyAcc1 = new AccessBankAccount("Jacob", 300);
            AccessBankAccount DummyAcc2 = new AccessBankAccount("Joe", 200);

            Blist.Add(DummyAcc1);
            Blist.Add(DummyAcc2);

            // Print list normally 
            foreach (AccessBankAccount acc in Blist)
            {
                Console.WriteLine(acc);
            }

            //Console.WriteLine($"Current Account: {Blist.Find(x => x.Owner.Contains("Jacob"))} ");

            bool InnerloopBreak = true;
            bool OutterloopBreak = true;

            while(OutterloopBreak)
            {
                InnerloopBreak = true;

                Console.WriteLine();
                Console.WriteLine("--== Bank Account Program ==--");
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine();

                foreach (AccessBankAccount acc in Blist)
                {
                    Console.WriteLine(acc);
                }

                Console.Write("Please enter account name: ");
                string SearchedName = Console.ReadLine();
                AccessBankAccount CurrentAccount = Blist.Find(x => x.Owner.Contains(SearchedName));

                while (InnerloopBreak)
                {
                    Console.WriteLine($"Current Account: {CurrentAccount.Owner} ");
                    Console.WriteLine("1. Create a new Account");
                    Console.WriteLine("2. Check Balance");
                    Console.WriteLine("3. withdrawal");
                    Console.WriteLine("4. Deposit");
                    Console.WriteLine("5. Get Account History");
                    Console.WriteLine("6. Exit to Main Menu");
                    Console.WriteLine("7. Exit Program");
                    int result = Convert.ToInt32(Console.ReadLine());

                    switch (result)
                    {
                        case 1:
                            Blist.Add(CreateAccount());
                            break;
                        case 2:
                            Console.WriteLine(CurrentAccount.Balance);
                            break;
                        case 3:
                            Withdrawal(CurrentAccount);
                            break;
                        case 4:
                            Deposit(CurrentAccount);
                            break;
                        case 5:
                            Console.WriteLine(CurrentAccount.GetAccountHistory());
                            break;
                        case 6:
                            Console.WriteLine();
                            InnerloopBreak = false;
                            break;
                        case 7:
                            Console.WriteLine("Exiting Program");
                            Console.WriteLine("Goodbye :)");
                            InnerloopBreak = false;
                            OutterloopBreak = false;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;

                    }// end switch (result)

                }// end while (InnerloopBreak)

            }// while (OutterloopBreak)

            void Withdrawal(AccessBankAccount acc)
            {
                Console.Write("Please enter amount of withdrawal: ");
                int WithdrawalAmount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Reason for withdrawal: ");
                string depositReason = Console.ReadLine();
                acc.MakeWithdrawal(WithdrawalAmount, DateTime.Now, depositReason);
                Console.WriteLine(acc.Balance);
            }

            void Deposit(AccessBankAccount acc)
            {
                Console.Write("Please enter amount of deposit: ");
                int depositAmount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Reason for Deposit: ");
                string depositReason = Console.ReadLine();
                acc.MakeDeposit(depositAmount, DateTime.Now, depositReason);
                Console.WriteLine(acc.Balance);
            }

        }// end main(string[] args)


        public static AccessBankAccount CreateAccount()
        {
            Console.WriteLine("Welcome to Account Creation!");
            Console.Write("Please enter your Name: ");
            string CurName = Console.ReadLine();
            Console.Write("Please enter your Account Ballance: ");
            int CurBalance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You will be asigned a random account number");

            // Create account
            AccessBankAccount account = new AccessBankAccount(CurName, CurBalance);

            // $ is interpolated string expression, so dont have to count arguments after quotes
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            return account;
        }

    }

}
