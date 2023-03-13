namespace TestNumbers
{
    public class General : User
    {
        public General(string formalName, int formalAge, int formalCredMoney) : base(formalName, formalAge, formalCredMoney) { }
        public override void GetCreditPrecentage()
        {
            Console.WriteLine("Вы - обычный человек, вам обычный процент.");
            CreditPercentage = 1.2 - Math.Round(CreditedMoney / 10000000, 2);
        }
    }
}
