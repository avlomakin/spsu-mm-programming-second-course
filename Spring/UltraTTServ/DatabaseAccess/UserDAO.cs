using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Npgsql;

namespace DatabaseAccess
{
    public class UserDAO
    {
        public UttContext Context { private get; set; }

        public User GetUser(string username)
        {
            var result = Context.Users.First(u => u.Username == username);
            return result;
        }

        public User Validate(string username, string password)
        {
            var user = GetUser(username);

            if (user == null) throw new Exception("User with such login does not exist");
            if (password != user.Password) throw new Exception("password is incorrect");

            return user;
        }

        public void CreateUser(string username, string password)
        {
            Context.Users.Add(new User()
            {
                Password = password,
                Username = username
            });
            Context.SaveChanges();
        }



    }
}