using System.Windows.Controls;
using UltraTT.Social.ViewModel;

namespace UltraTT.Social.View
{
    /// <summary>
    /// Логика взаимодействия для UserPageView.xaml
    /// </summary>
    public partial class UserPageView : Page
    {
        private UserPageViewModel _viewModel;
        public UserPageView()
        {
            _viewModel = new UserPageViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
