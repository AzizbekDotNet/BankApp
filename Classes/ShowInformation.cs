using BankApp.Classes;
using BankApp.Interfaces;
namespace BankApp.Classes
{
    public class Showinformation : IShowinformation
    {
        IBank bank = new Bank();
       public void ShowCheckPasssword()
       {
        try
        {
          Console.Clear();
          ISecurity security = new Security();
          Console.WriteLine("\t\tParolni kiriting");
          Console.Write("\t\t");
          string parol = Console.ReadLine();
          if(security.CheckPassword(parol))
          {
            ShowMainMenu();
          }
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Parol xato !!!");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("Press to anyway !!!");
          Console.ReadKey();
          ShowCheckPasssword();
        }
        catch
        {
            ShowCheckPasssword();
        }  
       }
       public void ShowMainMenu()
       {
          try
          {
            Console.Clear();
          Console.WriteLine("\t\tMenu");
          Console.WriteLine("1.Mijoz yaratish");
          Console.WriteLine("2.Mijoz o'chirish");
          Console.WriteLine("3.Mijozlar ro'yxati");
          Console.WriteLine("4.Operatsiyalar");
          Console.Write("Buyuruq kiriting (1,2,3,4): ");
          int n = int.Parse(Console.ReadLine());
          switch (n)
          {
            case 1: ShowCreate(); break;
            case 2: ShowDelete(); break;
            case 3: ShowClients(); break;
            case 4: Operation(); break;
            default: Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Buyuruq xato kiritildi !!!"); 
                     Console.ForegroundColor = ConsoleColor.White;
                     Console.WriteLine("Press to anyway !!!"); 
                     break;
          }
          Console.ReadKey();
          ShowMainMenu();
          }
          catch
          {
            ShowMainMenu();
          }
          
       }
       public void Operation()
       {
          try
          {
            Console.Clear();
          Console.WriteLine("\t\tOperatsiyalar");
          Console.WriteLine("1.Balans ko'rish");
          Console.WriteLine("2.Depozit qilish");
          Console.WriteLine("3.Pul yechish");
          Console.WriteLine("4.Pul o'tqazish");
          Console.WriteLine("0.Ortga");
          Console.Write("Buyuruq kiriting (1,2,3,4): ");
          int n = int.Parse(Console.ReadLine());
          switch (n)
          {
            case 1: ShowBalance(); break;
            case 2: ShowDeposit(); break;
            case 3: ShowTakeMoney(); break;
            case 4: ShowTransfer(); break;
            case 0: ShowMainMenu(); break;
            default: Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Buyuruq xato kiritildi !!!"); 
                     Console.ForegroundColor = ConsoleColor.White;
                     Console.WriteLine("Press to anyway !!!"); 
                     break;
          }
          Console.ReadKey();
          Operation();
          }
          catch
          {
            Operation();
          }
       }
       public void ShowBalance()
       {
        try
        {
          Console.Clear();
          Console.Write("Hisob raqam kiriting: ");
          int Number = int.Parse(Console.ReadLine());
          if(bank.GetBalance(Number) != -1)
          {
            Console.Write("Balans: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(bank.GetBalance(Number));
            Console.ForegroundColor = ConsoleColor.White;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bu hisob mavjud emas");
            Console.ForegroundColor = ConsoleColor.White;
          }
          Console.WriteLine("\nPress to anyway !!!");
          Console.ReadKey();
          Operation();
        }
        catch
        {
            ShowBalance();
        }
       }
       public void ShowClients()
       {
        try
        { 
          Console.Clear();
          var Clients = bank.GetClients();
          foreach(var client in Clients)
          {
            Console.WriteLine($"Ismi: {client.Name}\tHisob raqam: {client.ClientAccountNumber}");
          }
          Console.WriteLine("Press to anyway !!!");
          Console.ReadKey();
          ShowMainMenu();  
        }
        catch
        {
            ShowClients();
        } 
       }
       
       public void ShowCreate()
       {
        try
        {
            Console.Clear();
         Console.WriteLine("\t\tMijoz yaratish");
         Console.Write("Ism: ");
         string name = Console.ReadLine();
         Console.Write("Hisob raqam: ");
         int number = int.Parse(Console.ReadLine());
         if(bank.CreateClientAccount(name,number))
         {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Muaffaqiyatli !!!");
            Console.ForegroundColor = ConsoleColor.White;
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Yaratilmadi, ma'lumotlarni o'zgartiring !!!");
            Console.ForegroundColor = ConsoleColor.White;
         }
        Console.WriteLine("Press to anyway !!!");
        Console.ReadKey();
        ShowMainMenu();
        }
        catch
        {
            ShowCreate();
        }
       }
       public void ShowDelete()
       {
        try
        {
         Console.Clear();
         Console.Write("\t\tMijoz hisob raqamini kiriting: ");
         int number = int.Parse(Console.ReadLine());
         if(bank.DeleteClientAccount(number))
         {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Muaffaqiyatli !!!");
            Console.ForegroundColor = ConsoleColor.White;
         }
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O'chirilmadi, ma'lumotlar xato !!!");
            Console.ForegroundColor = ConsoleColor.White;
         }
        Console.WriteLine("Press to anyway !!!");
        Console.ReadKey();
        ShowMainMenu();
        }
        catch
        {
            ShowDelete();
        }
       }
       public void ShowTransfer()
       {
        try
        {
             Console.Clear();
        Console.Write("Pul chiqariladigan hisob raqam: ");
        int number_1 = int.Parse(Console.ReadLine());
        Console.Write("Pul kiritiladigan hisob raqam: ");
        int number_2 = int.Parse(Console.ReadLine());
        Console.Write("Summa: ");
        decimal summa = decimal.Parse(Console.ReadLine());
        if(bank.Transfer(number_1,number_2,summa))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Muaffaqiyatli !!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Xatolik mavjud yoki mablag' yetarli emas!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("Press to anyway !!!");
        Console.ReadKey();
        Operation();
        }
        catch
        {
            ShowTransfer();
        }
       }
       public void ShowDeposit()
       {
        try
        {
             Console.Clear();
        Console.WriteLine("\t\tHisob to'ldirish");
        Console.Write("Hisob raqam: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Summa: ");
        decimal summa = decimal.Parse(Console.ReadLine());
        if(bank.MakeDeposit(number,summa))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Muaffaqiyatli !!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Xatolik mavjud !!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("Press to anyway !!!");
        Console.ReadKey();
        Operation();
        }
        catch
        {
            ShowDeposit();
        }
       }
       public void ShowTakeMoney()
       {
        try
        {
            Console.Clear();
        Console.WriteLine("\t\tHisob to'ldirish");
        Console.Write("Hisob raqam: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Summa: ");
        decimal summa = decimal.Parse(Console.ReadLine());
        if(bank.TakeMoney(number,summa))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Muaffaqiyatli !!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mablag' yetarli emas !!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("Press to anyway !!!");
        Console.ReadKey();
        Operation();
        }
        catch
        {
            ShowTakeMoney();
        }
       }

    }
}