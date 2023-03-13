namespace TestNumbers
{
    public class Senior : User
    {
        public Senior(string formalName, int formalAge, int formalCredMoney) : base(formalName, formalAge, formalCredMoney) { }
        public override void GetCreditPrecentage()
        {
            Console.WriteLine("Старикам меньший процент!");
            CreditPercentage = 1.15 - Math.Round(CreditedMoney / 10000000, 2);
        }
    }
}
