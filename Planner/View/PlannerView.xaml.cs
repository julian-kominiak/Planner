using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Planner.Model;

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
        
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(List<Event>), typeof(PlannerView));
        public List<Event> ItemsSource
        {
            get { return (List<Event>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(Event), typeof(PlannerView));
        public Event SelectedItem
        {
            get { return (Event)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        
        public static readonly DependencyProperty TooltipProperty =
            DependencyProperty.Register("Tooltip", typeof(string), typeof(PlannerView));
        public string Tooltip
        {
            get { return (string)GetValue(TooltipProperty); }
            set { SetValue(TooltipProperty, value); }
        }

        //zrob w mvvm tak jak delete
        private void AddEventOnClick(object sender, RoutedEventArgs e)
        {
            EditFormView addView = new EditFormView(DateTime.Today);
            addView.Show();
        }

        //zrob w mvvm tak jak delete
        private void EditEventOnClick(object sender, RoutedEventArgs e)
        {
            EditFormView editView = new EditFormView("Testowy tytuł", "Testowy opis", DateTime.Today);
            editView.Show();
        }

        public static readonly DependencyProperty DeleteEventProperty =
            DependencyProperty.Register("DeleteEvent", typeof(ICommand), typeof(PlannerView));
        public ICommand DeleteEvent
        {
            get { return (ICommand)GetValue(DeleteEventProperty); }
            set { SetValue(DeleteEventProperty, value); }
        }
    }
}
