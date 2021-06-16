using Planner.ViewModel;

namespace Planner.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel.Planner.OpenLoginView();
        }
    }
}