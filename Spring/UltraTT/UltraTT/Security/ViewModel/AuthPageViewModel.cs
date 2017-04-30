using System;
using System.Threading;
using UltraTT.Command;
using UltraTT.Security.View;
using UltraTT.View;
using UltraTT.ViewModel;
using UttUserService.Security;

namespace UltraTT.Security.ViewModel
{
    public class AuthPageViewModel : BaseViewModel
    {
        private readonly AuthenticationService _authenticationService;

        public AuthPageViewModel()
        {
            _authenticationService = new AuthenticationService();
            LoginCommand = new SimpleCommand(Login);
        }

        #region Properties

        public SimpleCommand RegPage => new SimpleCommand(ShowRegPage);



        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;

                OnPropertyChanged();
            }
        }


        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;

                OnPropertyChanged();
            }
        }


        private string _errorText;
        public string ErrorText
        {
            get
            {
                return _errorText;
            }
            set
            {
                _errorText = value;

                OnPropertyChanged();
            }
        }


        private SimpleCommand _loginCommand;
        public SimpleCommand LoginCommand
        {
            get
            {
                return _loginCommand;
            }
            set
            {
                _loginCommand = value;

                OnPropertyChanged();
            }
        }

        #endregion


        private void ShowRegPage()
        {
            Navigator.GetInstance().Show(new RegPageView());
        }

        private void Login()
        {
            try
            {
                ErrorText = String.Empty;
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, Password);

                //Get the current principal object
                //Authenticate the user
                Navigator.GetInstance().Principal = new UttPrincipal()
                {
                    Identity = new UttIdentity(user.Username, user.Roles)
                };

                Navigator.GetInstance().AuthCompleted();
            }
            catch (UnauthorizedAccessException)
            {
                ErrorText = "Username or password is incorrect";
            }
            catch (Exception ex)
            {
                ErrorText = $"ERROR: {ex.Message}";
            }
        }

    }
}