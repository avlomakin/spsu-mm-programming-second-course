using System;
using System.Collections.Generic;
using System.Linq;

namespace UttUserService.Social
{
    public class StatService
    {
        public List<User> GetTop()
        {
            using (var client = new ServiceRef.UserServiceClient("NetTcpBinding_IUserService"))
            {
                var users =  client.GetTop();
                var result = users.Select(u => new User(u.Username, u.Score)).ToList();
                return result;
            }
        }

        public User GetUserAndStatistics()
        {
            return new User("Admin", 999)
            {
                Statistics = new Statistics(99.2, 100, 76.3, 1234)
            };
        }
    }
}