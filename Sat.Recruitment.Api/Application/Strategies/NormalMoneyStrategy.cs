using System;

namespace Sat.Recruitment.Api.Application.Strategies
{
    public class NormalMoneyStrategy : IUserMoneyStrategy
    {
        public decimal CalculateMoney(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                return money * percentage;
            }
            else if (money > 10)
            {
                var percentage = Convert.ToDecimal(0.8);
                return money * percentage;
            }
            else
            {
                return 0;
            }
        }
    }
}
