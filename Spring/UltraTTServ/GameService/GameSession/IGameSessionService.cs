using System.Collections.Generic;
using System.ServiceModel;

namespace GameService.GameSession
{
    [ServiceContract(CallbackContract = typeof(IGameSessionServiceCallback))]
    public interface IGameSessionService
    {

        [OperationContract(IsOneWay = true)]
        void SetupSession(string username, string opponentUsername);

        [OperationContract(IsOneWay = true)]
        void Step(int bigCell, int position);

        [OperationContract(IsOneWay = true)]
        void Won();

        /// <summary>
        /// get all filled cells in format (big cell, position, owner)
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<GameSessionMoveDto> Sync();
    }
}