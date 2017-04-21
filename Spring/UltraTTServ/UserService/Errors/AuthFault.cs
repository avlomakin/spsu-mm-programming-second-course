using System.Runtime.Serialization;

namespace UserService.Errors
{
    [DataContract]
    public class AuthFault
    {
        [DataMember]
        public string Error { get; set; }

        public AuthFault(string error)
        {
            Error = error;
        }
    }
}