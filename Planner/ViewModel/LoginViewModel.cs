using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Planner.Data;
using Planner.Model;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private ICommand _createAccountButton;
        private string _login;

        private ICommand _loginButton;

        private Brush _loginLabelBrush;

        private Brush _passwordBoxBrush;

        public string Login
        {
            get => _login;
            set
            {
                SetProperty(ref _login, value);
                LoginLabelBrush = Brushes.DarkGray;
                PasswordBoxBrush = Brushes.DarkGray;
            }
        }

        public ICommand LoginButton
        {
            get
            {
                if (_loginButton == null) _loginButton = new RelayCommand(PerformLoginAction, CanLogin);

                return _loginButton;
            }
        }

        public Brush LoginLabelBrush
        {
            get
            {
                if (_loginLabelBrush == null) return _loginLabelBrush = Brushes.DarkGray;

                return _loginLabelBrush;
            }
            set => SetProperty(ref _loginLabelBrush, value);
        }

        public Brush PasswordBoxBrush
        {
            get
            {
                if (_passwordBoxBrush == null) return _passwordBoxBrush = Brushes.DarkGray;

                return _passwordBoxBrush;
            }
            set => SetProperty(ref _passwordBoxBrush, value);
        }

        public ICommand CreateAccountButton
        {
            get
            {
                if (_createAccountButton == null)
                    _createAccountButton = new RelayCommand(PerformCreateAccountAction, CanLogin);

                return _createAccountButton;
            }
        }

        private void PerformLoginAction(object parameter)
        {
            var passwordBox = (PasswordBox) parameter;
            var user = new User(Login, passwordBox.Password);
            if (UsersDTO.checkIfUserExists(user))
            {
                MainViewModel.Planner.CurrentUser = Login;
                MainViewModel.Planner.LoginView.Close();
            }
            else
            {
                WrongCredentials(passwordBox);
            }
        }

        private bool CanLogin(object parameter)
        {
            var passwordBox = (PasswordBox) parameter;
            return Login is not null && passwordBox.Password != "";
        }

        private void WrongCredentials(PasswordBox passwordBox)
        {
            Login = "";
            passwordBox.Password = "";
            LoginLabelBrush = Brushes.Red;
            passwordBox.BorderBrush = Brushes.Red;
        }

        private void PerformCreateAccountAction(object parameter)
        {
            var passwordBox = (PasswordBox) parameter;
            var user = new User(Login, passwordBox.Password);

            if (UsersDTO.checkIfUserExists(user))
            {
                WrongCredentials(passwordBox);
            }
            else
            {
                UsersDTO.CreateUser(user);
                MainViewModel.Planner.CurrentUser = Login;
                MainViewModel.Planner.LoginView.Close();
            }
        }
    }
}