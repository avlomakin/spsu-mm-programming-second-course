using System.Windows.Controls;
using UltraTT.Security.ViewModel;

namespace UltraTT.Security.View
{
    /// <summary>
    /// Interaction logic for AuthPageView.xaml
    /// </summary>
    public partial class AuthPageView : Page
    {
        AuthPageViewModel viewModel;
        public AuthPageView()
        {
            viewModel = new AuthPageViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
