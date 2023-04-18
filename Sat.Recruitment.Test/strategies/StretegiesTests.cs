using Sat.Recruitment.Api.Application.Exceptions;
using Sat.Recruitment.Api.Application.Strategies;
using Sat.Recruitment.Api.Domain.DTOs;
using Sat.Recruitment.Api.Domain.Models;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.strategies
{
    
    public class StretegiesTests
    {
        private readonly UserMoneyCalculator moneyCalculator = new UserMoneyCalculator();

        [Fact]
        public void Normal_user_money_100_should_be_180()
        {
            var user = new UserDTO { Email = "seba1@gmail.com", Money = 100, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" };


            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            user.Money.ShouldBe(180);
        }

        [Fact]
        public void Normal_user_money_110_should_be_123()
        {
            var user = new UserDTO { Email = "seba1@gmail.com", Money = 110, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Normal" };


            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            user.Money.ShouldBe((decimal)123.20);
        }


        [Fact]
        public void Super_user_money_110_should_be()
        {
            var user = new UserDTO { Email = "seba1@gmail.com", Money = 110, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "SuperUser" };


            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            user.Money.ShouldBe((decimal)132);
        }

        [Fact]
        public void Super_user_money_80_should_be()
        {
            var user = new UserDTO { Email = "seba1@gmail.com", Money = 80, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "SuperUser" };


            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            user.Money.ShouldBe((decimal)80);
        }

        [Fact]
        public void Premium_user_money_110_should_be()
        {
            var user = new UserDTO { Email = "seba1@gmail.com", Money = 110, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Premium" };


            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            user.Money.ShouldBe((decimal)330);
        }

        [Fact]
        public void Premium_user_money_80_should_be()
        {
            var user = new UserDTO { Email = "seba1@gmail.com", Money = 80, Address = "Pintos 195", Name = "Seba", Phone = "+541156925433", UserType = "Premium" };


            var userMoneyCalculator = new UserMoneyCalculator();
            user.Money += userMoneyCalculator.CalculateMoneyToAdd(user.UserType, user.Money);

            user.Money.ShouldBe((decimal)80);
        }



    }
}
