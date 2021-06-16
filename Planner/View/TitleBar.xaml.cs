using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Planner.View
{
    public partial class TitleBar : UserControl
    {
        private Window currentWindow;
        public TitleBar()
        {
            InitializeComponent();
            currentWindow = Window.GetWindow(this);
            
        }

        private void Bar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                currentWindow.DragMove();
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentWindow.Title == "Planner")
            {
                Application.Current.Shutdown();
            }
            else
            {
                currentWindow.Close();
            }
        }
    }
}