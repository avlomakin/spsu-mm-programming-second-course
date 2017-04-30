using System.ServiceModel;
using System.Threading;
using ExternalServices.GameSession;
using GameLogic;

namespace UltraTT.Game.Model
{
    public class OnlineSessionModel : GameModel, IGameSessionServiceCallback
    {
        private GameSessionServiceClient _client;
        public Cell Owner { get; private set; }

        public OnlineSessionModel(string username, string opponentUsername)
        {
            Owner = Cell.Empty;
            _client = new GameSessionServiceClient(new InstanceContext(this), "NetTcpBinding_IGameSessionService");
            _client.Open();
            _client.SetupSession(username, opponentUsername);
            CurrentOwner = Cell.Cross;
        }

        public override bool IsCellValid(int bigCell, int smallCell)
        {
            return (Owner == CurrentOwner && base.IsCellValid(bigCell, smallCell));
        }


        public override void Step(int bigCell, int position)
        {
            _client.StepAsync(bigCell, position);
            base.Step(bigCell, position);
        }

        protected override void CheckForWinner()
        {
            var winner = GameField.Check();

            if (winner != Cell.Empty)
            {
                IsFinished = true;
                if(winner ==Owner)_client.WonAsync();
                OnGotWinner(winner);
            }
        }

        /// <summary>
        /// TODO: RENAME RECEIVE STEP
        /// </summary>
        /// <param name="move"></param>
        public void SendStep(GameSessionMoveDto move)
        {
            bool ok = base.IsCellValid(move.BigCell, move.Position);
            if (ok)
            {
                base.Step(move.BigCell, move.Position);
            }
        }

        public void SyncRoles(bool isCross)
        {
            Owner = isCross ? Cell.Cross : Cell.Nought;
            OnOwnerSwitched(CurrentOwner);
        }

        ~OnlineSessionModel()
        {
            _client.Close();
        }
    }
}