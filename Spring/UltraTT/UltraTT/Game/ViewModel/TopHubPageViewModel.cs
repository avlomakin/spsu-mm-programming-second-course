using System;
using UltraTT.Command;
using UltraTT.Game.View;
using UltraTT.Social.View;
using UltraTT.View;
using UltraTT.ViewModel;

namespace UltraTT.Game.ViewModel
{
    public class TopHubPageViewModel : BaseViewModel
    {

        public TopHubPageViewModel()
        {
            _showCommand = new RelayCommand(Show);
        }

        private RelayCommand _showCommand;
        public RelayCommand ShowCommand
        {
            get
            {
                return _showCommand;
            }
            set
            {
                _showCommand = value;

                OnPropertyChanged();
            }
        }

        public void Show(object obj)
        {
            var instance = Activator.CreateInstance((Type) obj);
            Navigator.GetInstance().Show(instance);
        }

        public Type HotSeat => typeof(HotSeatPageView);

        public Type LeaderBoard => typeof(LeaderboardPageView);

        public Type UserPage => typeof(UserPageView);

        public Type OnlineLobby => typeof(OnlineLobbyPageView);
    }
}