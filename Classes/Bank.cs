
using BankApp.Interfaces;
namespace BankApp.Classes
{
    public class Bank : IBank
    {
        List<Client> clients = new List<Client>();
        List<BankAccountNumber> bankAccountNumbers = new List<BankAccountNumber>();
        public bool CreateClientAccount(string name, int number)
        {
            try
            {
                if(clients.Find(x=>x.ClientAccountNumber == number) == null)
                {
                    Client client = new Client(name,number);
                    clients.Add(client);

                    BankAccountNumber bankAccountNumber = new BankAccountNumber(number,0); 
                    bankAccountNumbers.Add(bankAccountNumber);

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }
        public bool DeleteClientAccount(int accountnumber)
        {
             try
            {
                
                Client RClient = clients.Find(x=>x.ClientAccountNumber == accountnumber);
                BankAccountNumber RBanknumber = bankAccountNumbers.Find(x=>x.AccountNumber == accountnumber);
               
                if(clients.Remove(RClient)&&bankAccountNumbers.Remove(RBanknumber))
                {
                    return true;
                }
                return false;
                
            }
            catch
            {
                return false;
            }
        }
        public bool Transfer(int accountnumber_1, int accountnumber_2, decimal summa)
        {
            try
            {
                BankAccountNumber Banknumber_1 = bankAccountNumbers.Find(x=>x.AccountNumber == accountnumber_1);
                BankAccountNumber Banknumber_2 = bankAccountNumbers.Find(x=>x.AccountNumber == accountnumber_2);
                Banknumber_1.TakeMoney(summa);
                Banknumber_2.MakeDeposit(summa);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Client> GetClients()
        {
           return clients;
        }
        public decimal GetBalance(int number)
        {
            try
            {
                BankAccountNumber Banknumber = bankAccountNumbers.Find(x=>x.AccountNumber == number);
                return Banknumber.GetBalance();
            }
            catch
            {
                return -1;
            }
        }
        public bool MakeDeposit(int number, decimal summa)
        {
            try
            {
                BankAccountNumber Banknumber = bankAccountNumbers.Find(x=>x.AccountNumber == number);
                return Banknumber.MakeDeposit(summa);
            }
            catch
            {
                return false;
            }
        }
        public bool TakeMoney(int number, decimal summa)
        {
            try
            {
                BankAccountNumber Banknumber = bankAccountNumbers.Find(x=>x.AccountNumber == number);
                return Banknumber.TakeMoney(summa);
            }
            catch
            {
                return false;
            }
        }
    }
}