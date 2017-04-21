using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltraTT.Game.ViewModel;

namespace UltraTT.Game.View
{
    /// <summary>
    /// Interaction logic for OnlineSessionPageView.xaml
    /// </summary>
    public partial class OnlineSessionPageView : Page
    {
        public OnlineSessionPageView(string opponentUsername)
        {
            DataContext = new OnlineSessionPageViewModel(opponentUsername);
            InitializeComponent();
        }
    }
}
