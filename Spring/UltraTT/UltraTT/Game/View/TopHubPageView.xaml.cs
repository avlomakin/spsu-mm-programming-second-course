using System.Windows.Controls;
using UltraTT.Game.ViewModel;

namespace UltraTT.Game.View
{
    /// <summary>
    /// Interaction logic for TopHubPageView.xaml
    /// </summary>
    public partial class TopHubPageView : Page
    {
        private readonly TopHubPageViewModel _viewModel;
        public TopHubPageView()
        {
            InitializeComponent();
            _viewModel = new TopHubPageViewModel();
            DataContext = _viewModel;
        }
    }
}
