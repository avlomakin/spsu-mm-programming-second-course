using System.Threading;
using System.Windows.Controls;

namespace UltraTT.Game.View
{
    /// <summary>
    /// Interaction logic for WelcomePageView.xaml
    /// </summary>
    public partial class WelcomePageView : Page
    {
        public WelcomePageView()
        {
            InitializeComponent();
            WelcomeLabel.Content = "Welcome, " + Thread.CurrentPrincipal.Identity.Name;
        }
    }
}
