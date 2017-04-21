using System.Collections.Generic;


namespace UttUserService.Security
{
    public class User
    {
        public string Username { get; set; }

        public List<Role> Roles { get; set; }
    }
}