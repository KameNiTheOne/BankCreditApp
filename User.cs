namespace BankApp
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double CreditedMoney { get; set; }
        public double CreditPercentage { get; set; }
        public double HasToReturn { get; set; }
        public virtual void GetCreditPrecentage() { }
        public void WriteInfo()
        {
            Console.WriteLine($"Имя: {Name}\nВозраст: {Age}\nДенег взято в кредит: {CreditedMoney}\nПроцент годовых: {Math.Round(CreditPercentage, 2)}\nЗадолженность банку: {HasToReturn}");
        }
        public void GetAmountToReturn()
        {
            HasToReturn = Math.Round(CreditedMoney * CreditPercentage, 2);
        }
        public User (string formalName, int formalAge, int formalCredMoney, double formalCreditPercentage, double formalHasToReturn)
        {
            Name = formalName; Age = formalAge; CreditedMoney = formalCredMoney; CreditPercentage = formalCreditPercentage; HasToReturn= formalHasToReturn;
        }
        public User(string formalName, int formalAge, int formalCredMoney)
        {
            Name = formalName; Age = formalAge; CreditedMoney = formalCredMoney;
            GetCreditPrecentage();
            GetAmountToReturn();
            WriteInfo();
        }
    }
}
