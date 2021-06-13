using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _login;

        private ICommand _createAccountButton;

        private ICommand _loginButton;

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public ICommand LoginButton
        {
            get
            {
                if (_loginButton == null)
                {
                    _loginButton = new RelayCommand(PerformLoginAction, canLogin);
                }

                return _loginButton;
            }
        }

        private void PerformLoginAction(object parameter)
        {
            PasswordBox passwordBox = (PasswordBox) parameter;
            MessageBox.Show(passwordBox.Password);
        }

        private bool canLogin(object parameter)
        {
            return true;
        }
    }
}