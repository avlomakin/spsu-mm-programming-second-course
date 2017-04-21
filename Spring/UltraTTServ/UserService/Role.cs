using System.Runtime.Serialization;

namespace UserService
{
    [DataContract]
    public enum Role : byte
    {
        [EnumMember]
        Adminsitrator,
        [EnumMember]
        User
    }
}