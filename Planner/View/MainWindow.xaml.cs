using System.Windows;
using Planner.View;

namespace Planner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginView loginView = new LoginView();
            loginView.Show();
        }
    }
}