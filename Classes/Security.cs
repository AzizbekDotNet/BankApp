namespace BankApp.Classes
{
    public class Security : ISecurity
    {
        private string Password = "Az1zbek_2003";
        public  bool CheckPassword(string password)
        {
            if(Password == password)
            {
                return true;
            }
            return false;
        }
    }
}