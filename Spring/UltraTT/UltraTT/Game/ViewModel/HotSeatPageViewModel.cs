using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic;
using UltraTT.Command;
using UltraTT.Game.Model;
using UltraTT.Model;
using UltraTT.ViewModel;

namespace UltraTT.Game.ViewModel
{
    public sealed class HotSeatPageViewModel : GameViewModel
    {
        private HotSeatModel _model;


        public HotSeatPageViewModel() : base()
        {
            _newGameCommand = new SimpleCommand(NewGame);
            NewGame();
        }


        #region Properties
        private SimpleCommand  _newGameCommand;

        public SimpleCommand NewGameCommand
        {
            get { return _newGameCommand; }
            set
            {
                _newGameCommand = value;

                OnPropertyChanged();
            }
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
        #endregion


        public override void NewGame()
        {
            _model = new HotSeatModel();
            DefaultSetup(_model);
            GameInfo = "Current player: Cross";
            
            base.NewGame();
        }

        public override void GotWinnerHandler(object sender, Cell arg)
        {
            GameInfo = "We have a winner: " + arg;
        }

        public override void OwnerSwitchedHandler(object sender, Cell arg)
        {
            GameInfo = "Current player: " + arg;
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
        }
    }
}