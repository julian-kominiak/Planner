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
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(PlannerView));

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(PlannerView));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(List<Event>), typeof(PlannerView));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(Event), typeof(PlannerView));

        public static readonly DependencyProperty TooltipProperty =
            DependencyProperty.Register("Tooltip", typeof(string), typeof(PlannerView));

        public static readonly DependencyProperty AddEventProperty =
            DependencyProperty.Register("AddEvent", typeof(ICommand), typeof(PlannerView));

        public static readonly DependencyProperty EditEventProperty =
            DependencyProperty.Register("EditEvent", typeof(ICommand), typeof(PlannerView));

        public static readonly DependencyProperty DeleteEventProperty =
            DependencyProperty.Register("DeleteEvent", typeof(ICommand), typeof(PlannerView));

        public PlannerView()
        {
            InitializeComponent();
        }

        public DateTime SelectedDate
        {
            get => (DateTime) GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public List<Event> ItemsSource
        {
            get => (List<Event>) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public Event SelectedItem
        {
            get => (Event) GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public string Tooltip
        {
            get => (string) GetValue(TooltipProperty);
            set => SetValue(TooltipProperty, value);
        }

        public ICommand AddEvent
        {
            get => (ICommand) GetValue(AddEventProperty);
            set => SetValue(AddEventProperty, value);
        }

        public ICommand EditEvent
        {
            get => (ICommand) GetValue(EditEventProperty);
            set => SetValue(EditEventProperty, value);
        }

        public ICommand DeleteEvent
        {
            get => (ICommand) GetValue(DeleteEventProperty);
            set => SetValue(DeleteEventProperty, value);
        }
    }
}