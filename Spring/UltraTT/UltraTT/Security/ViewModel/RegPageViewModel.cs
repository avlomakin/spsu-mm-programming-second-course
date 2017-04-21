using System;
using System.Threading;
using UltraTT.Command;
using UltraTT.View;
using UltraTT.ViewModel;
using UttUserService.Security;

namespace UltraTT.Security.ViewModel
{
    public class RegPageViewModel : BaseViewModel
    {
        private AuthenticationService _authenticationService;

        public RegPageViewModel()
        {
            _authenticationService = new AuthenticationService();
            RegCommand = new SimpleCommand(Reg);
        }

        #region Properties
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


        private SimpleCommand _regCommand;
        public SimpleCommand RegCommand
        {
            get
            {
                return _regCommand;
            }
            set
            {
                _regCommand = value;

                OnPropertyChanged();
            }
        }

        #endregion


        private void Reg()
        {
            try
            {
                ErrorText = String.Empty;
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, Password);

                //Get the current principal object
                UttPrincipal uttPrincipal = Thread.CurrentPrincipal as UttPrincipal;
                if (uttPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                uttPrincipal.Identity = new UttIdentity(user.Username, user.Roles);

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