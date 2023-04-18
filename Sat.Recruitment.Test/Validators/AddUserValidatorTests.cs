using System;
using System.Dynamic;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Domain.DTOs;
using Sat.Recruitment.Api.Infrastructure.Validators;

using Shouldly;
using Xunit;

namespace Sat.Recruitment.Test.Validators
{
    public class AddUserValidatorTests
    {

        private readonly UserDTOValidator _validator;


        public AddUserValidatorTests()
        {
            _validator = new UserDTOValidator();
        }

        [Fact]
        public async Task Should_have_validation_error_when_email_invalid()
        {
            //arrange
            var dto = new UserDTO { Email = "sebagmail.com", Money = 180, Address = "Pintos 195", Name = "seba", Phone = "+541156925433", UserType = "Normal" };

            TestValidationResult<UserDTO> result = await _validator.TestValidateAsync(dto);

            result.ShouldHaveValidationErrorFor(x => x.Email);


        }

        [Fact]
        public async Task Should_have_validation_error_when_name_invalid()
        {
            //arrange
            var dto = new UserDTO { Email = "seba@gmail.com", Money = 180, Address = "Pintos 195", Name = "", Phone = "+541156925433", UserType = "Normal" };

            TestValidationResult<UserDTO> result = await _validator.TestValidateAsync(dto);

            result.ShouldHaveValidationErrorFor(x => x.Name);


        }

        [Fact]
        public async Task Should_have_validation_error_when_Adress_invalid()
        {
            //arrange
            var dto = new UserDTO { Email = "seba@gmail.com", Money = 180, Address = "", Name = "seba", Phone = "+541156925433", UserType = "Normal" };

            TestValidationResult<UserDTO> result = await _validator.TestValidateAsync(dto);

            result.ShouldHaveValidationErrorFor(x => x.Address);


        }

        [Fact]
        public async Task Should_have_validation_error_when_usertype_invalid()
        {
            //arrange
            var dto = new UserDTO { Email = "sebagmail.com", Money = 180, Address = "Pintos 195", Name = "seba", Phone = "+541156925433", UserType = "TipoInvalido" };

            TestValidationResult<UserDTO> result = await _validator.TestValidateAsync(dto);

            result.ShouldHaveValidationErrorFor(x => x.UserType);


        }

        [Fact]
        public async Task Should_have_validation_error_when_phone_invalid()
        {
            //arrange
            var dto = new UserDTO { Email = "sebagmail.com", Money = 180, Address = "Pintos 195", Name = "seba", Phone = "+54", UserType = "TipoInvalido" };

            TestValidationResult<UserDTO> result = await _validator.TestValidateAsync(dto);

            result.ShouldHaveValidationErrorFor(x => x.UserType);


        }
    }
}
