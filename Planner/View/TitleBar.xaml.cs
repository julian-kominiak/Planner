using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Planner.View
{
    public partial class TitleBar : UserControl
    {
        public TitleBar()
        {
            InitializeComponent();

        }

        private void Bar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            if(e.ChangedButton == MouseButton.Left)
                myWindow?.DragMove();
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            if (myWindow?.Title == "Planner")
            {
                Application.Current.Shutdown();
            }
            else
            {
                myWindow?.Close();
            }
        }
    }
}