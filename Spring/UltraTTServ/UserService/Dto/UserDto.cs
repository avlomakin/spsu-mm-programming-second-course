using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UserService.Dto
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

        public UserDto(string name, int score)
        {
            Username = name;
            Score = score;
        }

        public UserDto()
        {
            
        }
    }
}
