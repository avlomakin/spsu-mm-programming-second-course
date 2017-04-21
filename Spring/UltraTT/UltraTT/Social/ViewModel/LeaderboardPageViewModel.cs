using System.Collections.Generic;
using UltraTT.ViewModel;
using UttUserService.Social;

namespace UltraTT.Social.ViewModel
{
    public class LeaderboardPageViewModel : BaseViewModel
    {
        StatService _statService = new StatService();

        public LeaderboardPageViewModel()
        {
            Users = _statService.GetTop();
        }

        private List<User> _users;
        public List<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;

                OnPropertyChanged();
            }
        }

    }
}