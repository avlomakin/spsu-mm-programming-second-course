using System;
using System.ServiceModel;
using UttGameSessionService.ServiceRef;

namespace UttGameSessionService
{
    /// <summary>
    /// just transfer data, all check is on players themselves
    /// </summary>
    public class GameSession : IGameSessionServiceCallback
    {

        private GameSessionServiceClient _client;
        public event EventHandler<bool> SetupSide;
        public event EventHandler<GameSessionMoveDto> MoveReceived; 
        
        public GameSession(string username, string opponentUsername)
        {
            _client = new GameSessionServiceClient(new InstanceContext(this), "NetTcpBinding_IGameSessionService");
            _client.SetupSession(username, opponentUsername);

        }

        public void Step(int bigCell, int position)
        {
            _client.Step(bigCell, position);
        }

        public void SendStep(GameSessionMoveDto move)
        {
            MoveReceived?.Invoke(this, move);
        }

        public void SyncRoles(bool isCross)
        {
            SetupSide?.Invoke(this, isCross);
        }
    }
}