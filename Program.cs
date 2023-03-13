using BankApp;

class Program
{
    static void Main()
    {
        FileFramework.Restore();
        bool end = false;
        while (!end)
        {
            Console.WriteLine("Добро пожаловать в банк!");
            Console.WriteLine("Выберите, что вы хотите сделать:");
            Console.WriteLine("1 - Добавить нового клиента\n2 - Удалить клиента\n3 - Посмотреть всех клиентов\n4 - Сохранить и выйти(В appdata)");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Menu.AddClient();
                        Instruments.WaitForUser();
                    }
                    break;
                case "2":
                    {
                        if (Repository.Users.Any())
                        {
                            Menu.RemoveClient();
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте клиента!");
                        }
                        Instruments.WaitForUser();
                    }
                    break;
                case "3":
                    {
                        if (Repository.Users.Any())
                        {
                            Menu.ShowAllClients();
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте клиента!");
                        }
                        Instruments.WaitForUser();
                    }
                    break;
                case "4":
                    {
                        if (Repository.Users.Any())
                        {
                            FileFramework.Save();
                            Console.WriteLine("Данные успешно сохранены!");
                        }
                        Console.Clear();
                        Console.WriteLine("Выхожу!");
                        end = true;
                    }
                    break;
                default:
                    {
                        Console.Clear();
                    }
                    break;
            }
        }
    }
}
public static class Repository
{
    public static List<User> Users = new List<User>();
}
public static class Menu
{
    public static void AddClient()
    {
        Console.Clear();
        string Name = Instruments.GetName();
        int Age = Instruments.GetAge();
        int LoanMoney = Instruments.GetLoanedMoney();
        if (Age < 18)
        {
            Console.WriteLine($"{Name} не допущен к получению кредита, слишком малый возраст.");
        }
        else if (Age > 60)
        {
            Repository.Users.Add(new Senior(Name, Age, LoanMoney));
        }
        else
        {
            Repository.Users.Add(new General(Name, Age, LoanMoney));
        }
    }
    public static void RemoveClient()
    {
        Console.Clear();
        for (int i = 0; i < Repository.Users.Count; i++)
        {
            Console.WriteLine(i + 1 + ":");
            Repository.Users[i].WriteInfo();
            Console.WriteLine("****************************");
        }
        int RemoveId = Instruments.GetIdOfUser();
        Repository.Users.RemoveAt(RemoveId - 1);
        Console.WriteLine($"Клиент под номером {RemoveId} удалён.");
    }
    public static void ShowAllClients()
    {
        Console.Clear();
        foreach (User user in Repository.Users)
        {
            user.WriteInfo();
            Console.WriteLine("****************************");
        }
    }
}