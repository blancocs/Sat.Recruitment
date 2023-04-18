namespace Sat.Recruitment.Api.Application.Strategies
{
    public class PremiumMoneyStrategy : IUserMoneyStrategy
    {
        public decimal CalculateMoney(decimal money)
        {
            if (money > 100)
            {
                return money * 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
