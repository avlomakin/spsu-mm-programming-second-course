﻿using System;
using System.Threading;
using System.Windows.Input;
using GameLogic;
using UltraTT.Game.Model;
using UltraTT.View;

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
            /*while (_model.Owner == Cell.Empty)
            {

            }*/
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



        public override void GotWinnerHandler(object sender, Cell arg)
        {
            GameInfo = arg == _model.Owner ? "YOU WIN!" : "you lose(";
            CommandManager.InvalidateRequerySuggested();
        }

        public override void OwnerSwitchedHandler(object sender, Cell arg)
        {
            GameInfo = arg == _model.Owner ? "Your turn" : "Waiting for an opponent";
            CommandManager.InvalidateRequerySuggested();
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