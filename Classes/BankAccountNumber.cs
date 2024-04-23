using BankApp.Interfaces;
namespace BankApp.Classes
{
    public class BankAccountNumber : Bank, IBankAccountNumber
    {
        public int AccountNumber { get; set; }
        private decimal Balance;
        public BankAccountNumber(int accountnumber, decimal balance)
        {
            AccountNumber = accountnumber;
            Balance = balance;
        }

        public bool MakeDeposit(decimal summa)
        {
            try
            {
                
                Balance += summa;
                return true; 
            }
            catch
            {
                return false;
            }
        }
        public bool TakeMoney(decimal summa)
        {
             try
            {
                if(Balance>=summa)
                {
                    Balance -= summa;
                    return true;
                }
                return false;  
            }
            catch
            {
                return false;
            }
        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}