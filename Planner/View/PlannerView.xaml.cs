using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planner.View
{
    public partial class PlannerView : UserControl
    {
        public PlannerView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(PlannerView));
        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(PlannerView));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        private void AddEventOnClick(object sender, RoutedEventArgs e)
        {
            EditFormView addView = new EditFormView(DateTime.Today);
            addView.Show();
        }

        private void EditEventOnClick(object sender, RoutedEventArgs e)
        {
            EditFormView editView = new EditFormView("Testowy tytuł", "Testowy opis", DateTime.Today);
            editView.Show();
        }

        private void DeleteEventOnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
