using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Validators;
using EasyCatch.Tests.TestCases;
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

            var userRequest = new UserRegisterRequest();

            //Act
            userRequest.Errors = UserValidator.ValidateUserRegister(userRequest);
            
            //Assert
            Assert.AreEqual(expectedErrorsCount, userRequest.Errors.Count);
        }
        [Test,TestCaseSource(typeof(RegisterTestCases),"OneValidPropIsProvided")]
        public void When_Registering_And_Only_One_Valid_Prop_Is_Provided_Should_Return_Four_Errors(UserRegisterRequest userRequest)
        {
            //Prepare
            var expectedErrorsCount = 4;

            //Act
            userRequest.Errors = UserValidator.ValidateUserRegister(userRequest);

            //Assert
            Assert.AreEqual(expectedErrorsCount, userRequest.Errors.Count);
        }
    }
}