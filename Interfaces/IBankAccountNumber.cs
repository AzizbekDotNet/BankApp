namespace BankApp.Interfaces
{
    public interface IBankAccountNumber
    {
        bool MakeDeposit(decimal summa);
        bool TakeMoney(decimal summa);
        decimal GetBalance();
    }
}