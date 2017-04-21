using System.Collections.Generic;
using System.ServiceModel;
using UserService.Errors;

namespace UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(AuthFault))]
        UserDto Auth(string username, string password);

        [OperationContract]
        void Reg(string username, string password);

        [OperationContract]
        List<UserDto> GetTop();
    }
}