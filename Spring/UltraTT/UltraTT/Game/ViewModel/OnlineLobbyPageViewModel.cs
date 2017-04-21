using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UltraTT.Command;
using UltraTT.Game.Model;
using UltraTT.Game.View;
using UltraTT.View;
using UltraTT.ViewModel;
using UttUserService.Social;

namespace UltraTT.Game.ViewModel
{
    class OnlineLobbyPageViewModel : BaseViewModel
    {
        private OnlineLobbyPageModel _model;
        private bool _isFindingMatch;

        public OnlineLobbyPageViewModel()
        {
            _isFindingMatch = false;
            _model = new OnlineLobbyPageModel();
            _model.MatchFoundEvent += MatchFoundEventHandler;
            _lobbyInfo = "Welcome to online mode";
            FindMatchCommand = new SimpleCommand(FindMatch);
        }

        private void MatchFoundEventHandler(object sender, string e)
        {
            LobbyInfo = "Match found!";
            FindMatchCommand = null;
            Thread.Sleep(1000);
            
            Navigator.GetInstance().Show(new OnlineSessionPageView(e));
        }

        private void FindMatch()
        {

            try
            {
                if (_isFindingMatch)
                {
                    _isFindingMatch = false;
                    _model.Dequeue(Navigator.GetInstance().Principal.Identity.Name);
                    LobbyInfo = "Welcome to online mode";
                }
                else
                {
                    _isFindingMatch = true;
                    _model.Enqueue(Navigator.GetInstance().Principal.Identity.Name);
                    LobbyInfo = "Finding match...";
                }
            }
            catch (Exception e)
            {
                _isFindingMatch = false;
                LobbyInfo = "Server error...";
            }

        }


        private string _lobbyInfo;
        public string LobbyInfo
        {
            get
            {
                return _lobbyInfo;
            }
            set
            {
                _lobbyInfo = value;

                OnPropertyChanged();
            }
        }


        private SimpleCommand _findMatchCommand;
        public SimpleCommand FindMatchCommand
        {
            get
            {
                return _findMatchCommand;
            }
            set
            {
                _findMatchCommand = value;

                OnPropertyChanged();
            }
        }
    }
}
