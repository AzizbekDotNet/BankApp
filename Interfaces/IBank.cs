using BankApp.Classes;

namespace BankApp.Interfaces
{
    public interface IBank
    {
        bool CreateClientAccount(string name, int number);
        bool DeleteClientAccount(int accountnumber);
        bool Transfer(int accountnumber_1, int accountnumber_2, decimal summa);
        List<Client> GetClients();
        decimal GetBalance(int number);
        bool MakeDeposit(int number,decimal summa);
        bool TakeMoney(int number,decimal summa);
    }
}