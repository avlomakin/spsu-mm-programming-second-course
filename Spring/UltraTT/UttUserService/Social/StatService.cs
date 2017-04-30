using System;
using System.Collections.Generic;
using System.Linq;
using UttUserService.ServiceRef;

namespace UttUserService.Social
{

    /// <summary>
    /// TODO: RENAME SERVICE
    /// </summary>
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

        public User GetUserAndStatistics(string username)
        {
            using (var client = new ServiceRef.UserServiceClient("NetTcpBinding_IUserService"))
            {
                var stat = client.GetStat(username);
                return new User(username, stat.Score)
                {
                    Statistics = stat
                };
            }

        }
    }
}