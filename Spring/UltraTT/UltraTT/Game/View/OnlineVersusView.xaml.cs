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
using UttUserService.Social;

namespace UltraTT.Game.View
{
    /// <summary>
    /// Interaction logic for OnlineVersusView.xaml
    /// </summary>
    public partial class OnlineVersusView : Page
    {
        public OnlineVersusView(User cross, User nought)
        {
            InitializeComponent();
            Cross.DataContext = cross;
            Nought.DataContext = nought;
        }
    }
}
