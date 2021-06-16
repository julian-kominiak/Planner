using System.Windows;
using System.Windows.Input;

namespace Planner.View
{
    public partial class TitleBar
    {
        public static readonly DependencyProperty BarTitleProperty =
            DependencyProperty.Register("BarTitle", typeof(string), typeof(PlannerView));

        public TitleBar()
        {
            InitializeComponent();
        }

        public string BarTitle
        {
            get => (string) GetValue(BarTitleProperty);
            set => SetValue(BarTitleProperty, value);
        }

        private void Bar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            if (e.ChangedButton == MouseButton.Left)
                myWindow?.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            if (myWindow?.Title == "Planner")
                Application.Current.Shutdown();
            else
                myWindow?.Close();
        }
    }
}