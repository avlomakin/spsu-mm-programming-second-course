using System.Collections.Generic;
using System.ServiceModel;
using UserService.Dto;

namespace UserService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserDto Auth(string username, string password);

        [OperationContract(IsOneWay = true)]
        void Reg(string username, string password);

        [OperationContract]
        List<UserDto> GetTop();

        [OperationContract]
        int GetScore(string username);

        [OperationContract]
        StatDto GetStat(string username);
    }
}