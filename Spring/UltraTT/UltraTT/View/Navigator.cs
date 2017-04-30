using System.Threading;
using System.Threading.Tasks;
using UltraTT.Game.View;
using UltraTT.Security.View;
using UttUserService.Security;
using UttUserService.Social;
using WelcomePageView = UltraTT.Game.View.WelcomePageView;

namespace UltraTT.View
{
    public class Navigator
    {
        private static Navigator _navigator;

        public UttPrincipal Principal { get; set; }

        private IContentHolder _currentHolder;


        private Navigator()
        {
        }

        public static Navigator GetInstance()
        {
            return _navigator ?? (_navigator = new Navigator());
        }

        public void Start(IContentHolder contentHolder)
        {
            _currentHolder = contentHolder;
            _currentHolder.ShowContent(new AuthPageView());
        }


        public void OnlineSessionFound(string opponentName)
        {
            /*var service = new StatService();
            var owner = service.GetUserAndStatistics(Principal.Identity.Name);
            var opponent = service.GetUserAndStatistics(opponentName);
            var vs = new OnlineVersusView(owner, opponent);
            _currentHolder.ShowContent(vs);

            Thread.Sleep(2000);*/
            //var session = new OnlineSessionPageView();
            //session.LoadVm(opponentName);
            _currentHolder.ShowContent(new OnlineSessionPageView(opponentName));

        }
        public void AuthCompleted()
        {
            var gamePage = new GameHostPageView();
            _currentHolder.ShowContent(gamePage);
            _currentHolder = gamePage;
            _currentHolder.ShowContent(new WelcomePageView());
        }

        public void Show(object content)
        {
            _currentHolder.ShowContent(content);
        }
    }
}