using System.Collections.Generic;
using EasyCatch.API.Core.Requests;

namespace EasyCatch.Tests.TestCases
{
    public class RegisterTestCases
    {
        private static string WrongPassword { get; set; } = "wrongPass";
        private static string WrongEmail { get; set; } = "wrongMail";
        private static string WrongName { get; set; } = "WrongName1";
        private static string WrongSurname { get; set; } = "WrongSurname1";
        
        
        public static List<UserRegisterRequest> OneValidPropIsProvided { get; set; } = new List<UserRegisterRequest>{
            new UserRegisterRequest(){ Login ="TestLogin" },
            new UserRegisterRequest(){ Login ="TestLogin", Email = WrongEmail },
            new UserRegisterRequest(){ Login ="TestLogin", Name = WrongName },
            new UserRegisterRequest(){ Login ="TestLogin", Surname = WrongSurname },
            new UserRegisterRequest(){ Login ="TestLogin", Password = WrongPassword },
            new UserRegisterRequest(){ Login ="TestLogin", Password = WrongPassword, Email = WrongEmail },
            new UserRegisterRequest(){ Login ="TestLogin", Password = WrongPassword, Email = WrongEmail, Name = WrongName },
            new UserRegisterRequest(){ Login ="TestLogin", Password = WrongPassword, Email = WrongEmail, Name = WrongName, Surname = WrongSurname },

            new UserRegisterRequest(){ Password ="TestPassword220@" },
            new UserRegisterRequest(){ Password ="TestPassword220@", Email = WrongEmail },
            new UserRegisterRequest(){ Password ="TestPassword220@", Name = WrongName },
            new UserRegisterRequest(){ Password ="TestPassword220@", Surname = WrongSurname },
            new UserRegisterRequest(){ Password ="TestPassword220@", Surname = WrongSurname, Email = WrongEmail},
            new UserRegisterRequest(){ Password ="TestPassword220@", Surname = WrongSurname, Email = WrongEmail, Name = WrongName},

            new UserRegisterRequest(){ Email = "email@test.com" },
            new UserRegisterRequest(){ Email = "email@test.com", Password = WrongPassword },
            new UserRegisterRequest(){ Email = "email@test.com", Name=WrongName },
            new UserRegisterRequest(){ Email = "email@test.com", Surname = WrongSurname },
            new UserRegisterRequest(){ Email = "email@test.com", Surname = WrongSurname, Password = WrongPassword },
            new UserRegisterRequest(){ Email = "email@test.com", Surname = WrongSurname, Password =  WrongPassword, Name=WrongName },

            new UserRegisterRequest(){ Name = "TestName" },
            new UserRegisterRequest(){ Name = "TestName", Password = WrongPassword },
            new UserRegisterRequest(){ Name = "TestName", Email = WrongEmail },
            new UserRegisterRequest(){ Name = "TestName", Surname = WrongSurname },
            new UserRegisterRequest(){ Name = "TestName", Surname = WrongSurname, Password = WrongPassword},
            new UserRegisterRequest(){ Name = "TestName", Surname = WrongSurname, Password = WrongPassword, Email = WrongEmail },
            
            new UserRegisterRequest(){ Surname = "TestSurname" },
            new UserRegisterRequest(){ Surname = "TestSurname", Password = WrongPassword},
            new UserRegisterRequest(){ Surname = "TestSurname", Email = WrongEmail},
            new UserRegisterRequest(){ Surname = "TestSurname", Name=WrongName},
            new UserRegisterRequest(){ Surname = "TestSurname", Name=WrongName, Password = WrongPassword },
            new UserRegisterRequest(){ Surname = "TestSurname", Name=WrongName, Password = WrongPassword, Email=WrongEmail}
        
        };
    }
}