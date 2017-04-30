using System;
using System.Threading;
using UltraTT.Command;
using UltraTT.Security.View;
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


        private string _confirm;
        public string Confirm
        {
            get
            {
                return _confirm;
            }
            set
            {
                _confirm = value;

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

                if (Confirm != Password)
                {
                    ErrorText = "Passwords doesn't match";
                    return;
                }

                _authenticationService.RegUser(Username, Password);

                Navigator.GetInstance().Show(new AuthPageView());
            }
            catch (Exception ex)
            {
                ErrorText = $"ERROR: {ex.Message}";
            }
        }
    }
}