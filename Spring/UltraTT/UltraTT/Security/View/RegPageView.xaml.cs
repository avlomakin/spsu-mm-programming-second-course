using System.Windows.Controls;
using UltraTT.Security.ViewModel;

namespace UltraTT.Security.View
{
    /// <summary>
    /// Interaction logic for RegPageView.xaml
    /// </summary>
    public partial class RegPageView : Page
    {
        
        public RegPageView()
        {
            DataContext = new RegPageViewModel();
            InitializeComponent();
        }
    }
}
