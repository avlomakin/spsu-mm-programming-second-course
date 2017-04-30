using UltraTT.View;
using UltraTT.ViewModel;
using UttUserService.ServiceRef;
using UttUserService.Social;

namespace UltraTT.Social.ViewModel
{
    public class UserPageViewModel : BaseViewModel
    {

        StatService _statService = new StatService();

        public UserPageViewModel()
        {
            User = _statService.GetUserAndStatistics(Navigator.GetInstance().Principal.Identity.Name);
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


        private StatDto _statistics;
        public StatDto Statistics
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