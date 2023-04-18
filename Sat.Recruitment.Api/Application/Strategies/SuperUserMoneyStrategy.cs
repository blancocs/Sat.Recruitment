using System;

namespace Sat.Recruitment.Api.Application.Strategies
{
    public class SuperUserMoneyStrategy : IUserMoneyStrategy
    {
        public decimal CalculateMoney(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                return money * percentage;
            }
            else
            {
                return 0;
            }
        }
    }
}
