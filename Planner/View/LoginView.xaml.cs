using System.Windows;
using System.Windows.Controls;
using Planner.ViewModel;

namespace Planner.View
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        
    }
}