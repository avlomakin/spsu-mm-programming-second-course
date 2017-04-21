using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UttUserService.Security
{
    public class AuthenticationService
    {

        public User AuthenticateUser(string username, string textPassword)
        {
            using (var client = new ServiceRef.UserServiceClient("NetTcpBinding_IUserService"))
            {
                var transferedData = client.Auth(username, textPassword);
                return new User()
                {
                    Username = transferedData.Username,
                    Roles = transferedData.Roles.Select(i => (Role)i).ToList()
                };
            }
        }
    }
}