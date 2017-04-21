using System.ServiceModel;

namespace GameService.GameSession
{
    [ServiceContract]
    public interface IGameSessionServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendStep(GameSessionMoveDto move);

        [OperationContract(IsOneWay = true)]
        void SyncRoles(bool isCross);

    }
}