using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using UserService.Errors;

namespace UserService
{

    public class UserService : IUserService
    {
        public UserDto Auth(string username, string password)
        {
            User user = Users.FirstOrDefault(u => u.Username == username);


            Console.WriteLine(username + " connected");

            if (user == null)
            {
                throw new FaultException<AuthFault>(new AuthFault("auth failed"), new FaultReason("auth failed"));
            }

            Password userPassword = user.Password;

            if (userPassword == null)
            {
                throw new FaultException<AuthFault>(new AuthFault("auth failed"), new FaultReason("auth failed"));
            }

            string hashPassword = CalculateHash(password, userPassword.Salt);

            if (hashPassword == userPassword.Hash)
            {
                return new UserDto()
                {
                    Username = user.Username,
                    Roles = user.Roles.Select(i => (int) i).ToList()
                };
            }
            throw new FaultException<AuthFault>(new AuthFault("auth failed"), new FaultReason("auth failed"));
        }

        public void Reg(string username, string password)
        {
            var user = new User();
            user.Username = username;
            user.Roles = new List<Role>(){Role.User};
            user.Password = new Password {Salt = "123"};
            user.Password.Hash = CalculateHash(password, user.Password.Salt);
            Users.Add(user);
        }

        private string CalculateHash(string textPassword, string salt)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(textPassword + salt);

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }


        public List<UserDto> GetTop()
        {
            return UserStorage();
        }

        #region NeedDelete

        private static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Roles = new List<Role>()
                {
                    Role.User,
                    Role.Adminsitrator
                },
                Username = "Admin",
                Password = new Password()
                {
                    Id = 1,
                    Hash = "xwTbOsdKA0KO76NurjcxBTZPDtohnWAVwO8ui0BWwfU=",
                    Salt = "123"
                }
            },
            new User()
            {
                Id = 1,
                Roles = new List<Role>()
                {
                    Role.User,
                },
                Username = "Pashko",
                Password = new Password()
                {
                    Id = 1,
                    Hash = "xwTbOsdKA0KO76NurjcxBTZPDtohnWAVwO8ui0BWwfU=",
                    Salt = "123"
                }
            }
        };


        private static List<UserDto> UserStorage()
        {
            var rnd = new Random();
            return new List<UserDto>(Enumerable.Repeat(new UserDto()
            {
                Username = "Loser",
                Score = 1234
            }, 10));
        }

        #endregion
    }
}
