using System.Security.Permissions;
using System.Windows.Controls;
using UltraTT.View;

namespace UltraTT.Game.View
{
    /// <summary>
    /// Interaction logic for GameHostPageView.xaml
    /// </summary>
    public partial class GameHostPageView : Page, IContentHolder
    {
        public GameHostPageView()
        {
            InitializeComponent();
        }

        public void ShowContent(object content)
        {
            WorkingFrame.Content = content;
        }
    }
}
