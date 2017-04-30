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
    /// Interaction logic for SessionResultView.xaml
    /// </summary>
    public partial class SessionResultView : Page
    {
        public SessionResultView(User winner, User loser)
        {

            InitializeComponent();
            Loser.DataContext = loser;
            Winner.DataContext = winner;
        }
    }
}
