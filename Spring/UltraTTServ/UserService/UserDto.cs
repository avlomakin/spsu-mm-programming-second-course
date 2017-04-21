using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public List<int> Roles { get; set; }

        [DataMember]
        public int Score { get; set; }
    }
}
