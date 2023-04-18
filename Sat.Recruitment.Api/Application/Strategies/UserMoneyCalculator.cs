using System;

namespace Sat.Recruitment.Api.Application.Strategies
{
    public class UserMoneyCalculator
    {
        public decimal CalculateMoneyToAdd(string userType, decimal money)
        {
            IUserMoneyStrategy userMoneyStrategy;

            switch (userType)
            {
                case "Normal":
                    userMoneyStrategy = new NormalMoneyStrategy();
                    break;
                case "SuperUser":
                    userMoneyStrategy = new SuperUserMoneyStrategy();
                    break;
                case "Premium":
                    userMoneyStrategy = new PremiumMoneyStrategy();
                    break;
                default:
                    throw new ArgumentException("Invalid user type.");
            }

            return userMoneyStrategy.CalculateMoney(money);
        }
    }
}
