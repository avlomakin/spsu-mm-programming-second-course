using UltraTT.Game.View;
using UltraTT.Security.View;
using UttUserService.Security;
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