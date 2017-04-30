using System;
using System.Threading;
using System.Windows.Input;
using GameLogic;
using UltraTT.Game.Model;
using UltraTT.Game.View;
using UltraTT.View;
using UttUserService.Social;

namespace UltraTT.Game.ViewModel
{
    public sealed class OnlineSessionPageViewModel : GameViewModel
    {
        private OnlineSessionModel _model;
        private string _opponentUsername;

        public OnlineSessionPageViewModel(string opponentUsername)
        {
            _opponentUsername = opponentUsername;
            _model = new OnlineSessionModel(Navigator.GetInstance().Principal.Identity.Name, opponentUsername);
            DefaultSetup(_model);
            GameInfo = "Waiting for an opponent";
            NewGame();
        }


        private string _gameInfo;
        public string GameInfo
        {
            get
            {
                return _gameInfo;
            }
            set
            {
                _gameInfo = value;

                OnPropertyChanged();
            }
        }



        private User _crossUser;
        public User CrossUser
        {
            get
            {
                return _crossUser;
            }
            set
            {
                _crossUser = value;

                OnPropertyChanged();
            }
        }


        private User _noughtUser;
        public User NoughtUser
        {
            get
            {
                return _noughtUser;
            }
            set
            {
                _noughtUser = value;

                OnPropertyChanged();
            }
        }


        public override void GotWinnerHandler(object sender, Cell arg)
        {
            var winner = arg == Cell.Cross ? CrossUser : NoughtUser;
            var loser = arg != Cell.Cross ? CrossUser : NoughtUser;

            Navigator.GetInstance().Show(new SessionResultView(winner, loser));
        }

        public override void OwnerSwitchedHandler(object sender, Cell arg)
        {
            if (CrossUser == null || NoughtUser == null) SetupSides(); 
            GameInfo = arg == _model.Owner ? "Your turn" : "Waiting for an opponent's step";
            CommandManager.InvalidateRequerySuggested();
        }

        private void SetupSides()
        {
            var service = new StatService();
            var owner = service.GetUserAndStatistics(Navigator.GetInstance().Principal.Identity.Name);
            var opponent = service.GetUserAndStatistics(_opponentUsername);
            CrossUser = _model.Owner == Cell.Cross ? owner : opponent;
            NoughtUser = _model.Owner != Cell.Cross ? owner : opponent;
        }

        public override bool IsCellValid(object obj)
        {
            if (obj == null) return true;
            var bigCell = ((Tuple<int, int>)obj).Item1;
            var position = ((Tuple<int, int>)obj).Item2;
            return _model.IsCellValid(bigCell, position);
        }

        protected override void Step(object obj)
        {
            var bigCell = ((Tuple<int, int>)obj).Item1;
            var position = ((Tuple<int, int>)obj).Item2;

            _model.Step(bigCell, position);
            CommandManager.InvalidateRequerySuggested();
        }
    }
}