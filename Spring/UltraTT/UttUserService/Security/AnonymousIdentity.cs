using System.Collections.Generic;
using UttUserService.ServiceRef;


namespace UttUserService.Security
{
    public class AnonymousIdentity : UttIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, new List<Role>())
        { }
    }
}