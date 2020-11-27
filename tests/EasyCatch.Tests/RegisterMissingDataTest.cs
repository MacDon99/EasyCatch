using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Validators;
using NUnit.Framework;

namespace EasyCatch.Tests
{
    public class RegisterMissingDataTest
    {
    public UserValidations UserValidator { get; set; }
    
        [SetUp]
        public void Setup()
        {
            UserValidator= new UserValidations();
        }

        [Test]
        public void When_Registering_And_Nothing_Is_Provided_Should_Return_Five_Errors()
        {
            //Prepare
            var expectedErrorsCount = 5;

            var userRequest = new UserRegisterRequest(){
                Login ="",
                Password ="",
                Email = "",
                Name = "",
                Surname = ""
            };

            //Act
            userRequest.Errors = UserValidator.ValidateUserRegister(userRequest);
            
            //Assert
            Assert.AreEqual(expectedErrorsCount, userRequest.Errors.Count);
        }
        [Test]
        public void When_Registering_And_Only_One_Valid_Prop_Is_Provided_Should_Return_Four_Errors()
        {
            //Prepare
            var expectedErrorsCount = 4;

            var userRequest1 = new UserRegisterRequest(){
                Login ="TestLogin",
                Password ="",
                Email = "",
                Name = "",
                Surname = ""
            };
            var userRequest2 = new UserRegisterRequest(){
                Login ="",
                Password ="TestPassword220@",
                Email = "",
                Name = "",
                Surname = ""
            };
            var userRequest3 = new UserRegisterRequest(){
                Login ="",
                Password ="",
                Email = "email@test.com",
                Name = "",
                Surname = ""
            };
            var userRequest4 = new UserRegisterRequest(){
                Login ="",
                Password ="",
                Email = "",
                Name = "TestName",
                Surname = ""
            };
            var userRequest5 = new UserRegisterRequest(){
                Login ="",
                Password ="",
                Email = "",
                Name = "",
                Surname = "TestSurname"
            };

            //Act
            userRequest1.Errors = UserValidator.ValidateUserRegister(userRequest1);
            userRequest2.Errors = UserValidator.ValidateUserRegister(userRequest2);
            userRequest3.Errors = UserValidator.ValidateUserRegister(userRequest3);
            userRequest4.Errors = UserValidator.ValidateUserRegister(userRequest4);
            userRequest5.Errors = UserValidator.ValidateUserRegister(userRequest5);

            //Assert
            Assert.AreEqual(expectedErrorsCount, userRequest1.Errors.Count);
            Assert.AreEqual(expectedErrorsCount, userRequest2.Errors.Count);
            Assert.AreEqual(expectedErrorsCount, userRequest3.Errors.Count);
            Assert.AreEqual(expectedErrorsCount, userRequest4.Errors.Count);
            Assert.AreEqual(expectedErrorsCount, userRequest5.Errors.Count);
        }
    }
}