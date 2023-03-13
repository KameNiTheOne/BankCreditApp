using System.Text;
using static System.Console;
namespace BankApp
{
    public static class Instruments
    {
        public static void WaitForUser()
        {
            WriteLine("\nЧтобы продолжить, нажмите 'Enter'");
            ReadLine();
            Clear();
        }
        public static string GetName()
        {
            while (true)
            {
                WriteLine("Введите имя:");
                string Input = GetFormatedString(ReadLine());
                if (Input.Length is not < 3 or > 30)
                {
                    return Input;
                }
                Clear();
            }
        }
        public static int GetAge()
        {
            while(true)
            {
                WriteLine("Введите возраст:");
                int Input = GetIntFromString(ReadLine());
                if(Input < 0)
                {
                    Clear();
                    continue;
                }
                return Input;
            }
        }
        static string GetFormatedString(string Input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Input);
            return Convert.ToString(sb.Replace('\t', ' '));
        }
        public static int GetLoanedMoney()
        {
            while (true)
            {
                WriteLine("Введите кол - во денег в кредит (Минимум 100 тыс, максимум 1 миллион):");
                int Input = GetIntFromString(ReadLine());
                if (Input < 0)
                {
                    Clear();
                    continue;
                }
                else if(Input < 100000)
                {
                    return 100000;
                }
                else if(Input > 1000000)
                {
                    return 1000000;
                }
                return Input;
            }
        }
        public static int GetIdOfUser()
        {
            while (true)
            {
                WriteLine("Введите номер клиента:");
                int Input = GetIntFromString(ReadLine());
                if (Input < 0)
                {
                    continue;
                }
                else if (Input > Repository.Users.Count || Input == 0)
                {
                    WriteLine("Такого клиента нет.");
                    continue;
                }
                return Input;
            }
        }
        static int GetIntFromString(string Input)
        {
            try
            {
                int test = int.Parse(Input);
            }
            catch (FormatException)
            {
                return -1;
            }
            return int.Parse(Input);
        }
    }
}
