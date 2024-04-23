using System.ComponentModel.DataAnnotations;
using BankApp.Interfaces;
namespace BankApp.Classes
{
    public class Client : IClient
    {
        public string ?Name { get; set; }
        public int ClientAccountNumber {get; set;}

        public Client(string name, int number)
        {
            Name = name;
            ClientAccountNumber = number;
        }
    }
}