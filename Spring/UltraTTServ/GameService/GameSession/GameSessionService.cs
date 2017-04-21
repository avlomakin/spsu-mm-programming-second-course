using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace GameService.GameSession
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GameSessionService : IGameSessionService
    {
        private GameSessionService _opponentService;
        private IGameSessionServiceCallback _sender;
        private bool _isMyTurn;
        public  bool Found { get; private set; }
        public bool SetupFinished { get; private set; }


        public bool IsCross { get; set; }

        public GameSessionService()
        {
            _sender = OperationContext.Current.GetCallbackChannel<IGameSessionServiceCallback>();
        }


        public void Step(int bigCell, int position)
        {
            if(_isMyTurn)
                _opponentService.Step(bigCell, position);
            else 
                _sender.SendStep(new GameSessionMoveDto(){BigCell =  bigCell, Position = position, IsCross = IsCross});
            _isMyTurn = !_isMyTurn;
        }

        List<GameSessionMoveDto> IGameSessionService.Sync()
        {
            throw new NotImplementedException();
        }

        public void SetupSession(string username, string opponentUsername)
        {

            Found = false;
            SetupFinished = false;
            GameSessionManager.RegNewSession(username, this);
            Console.WriteLine(username + "Regd");

            _opponentService = GameSessionManager.GetGameSesionService(opponentUsername);

            Console.WriteLine(username + " found " + opponentUsername + " service");
            Found = true;

            while (!_opponentService.Found)
            {
                
            }

            var lockingObj = Min(this, _opponentService);

            lock (lockingObj)
            {
                if (!SetupFinished)
                {
                    var rnd = new Random().Next(0, 1);
                    IsCross = rnd == 1;
                    _opponentService.IsCross = rnd != 1;
                    SetupFinished = true;
                    _opponentService.SetupFinished = true;
                }
            }

            Console.WriteLine(username + ": " + (IsCross ? "cross" : "nought"));

            _isMyTurn = IsCross;

            _sender.SyncRoles(IsCross);
        }

        private static object Min(object a, object b)
        {
            return a.GetHashCode() < b.GetHashCode() ? a : b;
        }
    }
}