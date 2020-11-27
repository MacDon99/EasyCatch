using System.Collections.Generic;
using EasyCatch.API.Core.Requests;

namespace EasyCatch.Tests.TestCases
{
    public class RegisterTestCases
    {
        public static List<UserRegisterRequest> OnePropIsMissingTestCases { get; set; } = new List<UserRegisterRequest>{
            new UserRegisterRequest(){ Login ="TestLogin" },
            new UserRegisterRequest(){ Password ="TestPassword220@" },
            new UserRegisterRequest(){ Email = "email@test.com" },
            new UserRegisterRequest(){ Name = "TestName" },
            new UserRegisterRequest(){ Surname = "TestSurname" }
        };
    }
}