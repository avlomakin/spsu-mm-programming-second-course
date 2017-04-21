using System.Threading;
using System.Windows.Controls;
using UltraTT.View;

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
            WelcomeLabel.Content = "Welcome, " + Navigator.GetInstance().Principal.Identity.Name;
        }
    }
}
