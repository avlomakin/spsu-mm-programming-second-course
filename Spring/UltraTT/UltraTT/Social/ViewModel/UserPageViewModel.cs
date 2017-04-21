using UltraTT.ViewModel;
using UttUserService.Social;

namespace UltraTT.Social.ViewModel
{
    public class UserPageViewModel : BaseViewModel
    {

        StatService _statService = new StatService();

        public UserPageViewModel()
        {
            User = _statService.GetUserAndStatistics();
            Statistics = User.Statistics;
        }

        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;

                OnPropertyChanged();
            }
        }


        private Statistics _statistics;
        public Statistics Statistics
        {
            get
            {
                return _statistics;
            }
            set
            {
                _statistics = value;

                OnPropertyChanged();
            }
        }

    }
}