using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }
        
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(Event), typeof(PlannerView));
        public Event SelectedItem
        {
            get { return (Event)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        public static readonly DependencyProperty TooltipProperty =
            DependencyProperty.Register("Tooltip", typeof(string), typeof(PlannerView));
        public string Tooltip
        {
            get { return (string)GetValue(TooltipProperty); }
            set { SetValue(TooltipProperty, value); }
        }

        public static readonly DependencyProperty AddEventProperty =
            DependencyProperty.Register("AddEvent", typeof(ICommand), typeof(PlannerView));
        public ICommand AddEvent
        {
            get { return (ICommand)GetValue(AddEventProperty); }
            set { SetValue(AddEventProperty, value); }
        }

        public static readonly DependencyProperty EditEventProperty =
            DependencyProperty.Register("EditEvent", typeof(ICommand), typeof(PlannerView));
        public ICommand EditEvent
        {
            get { return (ICommand)GetValue(EditEventProperty); }
            set { SetValue(EditEventProperty, value); }
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
