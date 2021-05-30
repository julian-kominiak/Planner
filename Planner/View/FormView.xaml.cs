using System;
using System.Collections.Generic;
using System.Windows;

namespace Planner.View
{
    public partial class FormView : Window
    {
        private DateTime _defaultDate = DateTime.Today;
        private string _name = "";
        private string _description = "";

        private string[] _priority = {"Low", "Normal", "High"};
        public FormView(string windowTitle)
        {
            InitializeComponent();
            Title = windowTitle;
            tb1.Text = _name;
            tb2.Text = _description;
            tb3.DisplayDate = _defaultDate;
            tb4.DataContext = _priority;
        }
        // public FormView(DateTime date):this()
        // {
        //     tb3.DisplayDate = date;
        // }
        //
        // public FormView(string name, string description, DateTime date):this()
        // {
        //     tb1.Text = name;
        //     tb2.Text = description;
        //     tb3.SelectedDate = date;
        // }
    }
}