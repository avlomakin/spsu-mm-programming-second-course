using System.Windows.Controls;
using UltraTT.Social.ViewModel;

namespace UltraTT.Social.View
{
    /// <summary>
    /// Interaction logic for LeaderboardPageView.xaml
    /// </summary>
    public partial class LeaderboardPageView : Page
    {
        private LeaderboardPageViewModel _viewModel;

        public LeaderboardPageView()
        {
            DataContext = new LeaderboardPageViewModel();
            InitializeComponent();
        }
    }
}
