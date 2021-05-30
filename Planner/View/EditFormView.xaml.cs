﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace Planner.View
{
    public partial class EditFormView : Window
    {
        private DateTime _defaultDate = DateTime.Today;
        private string _name = "";
        private string _description = "";

        private string[] _priority = {"Low", "Normal", "High"};
        public EditFormView()
        {
            InitializeComponent();
            tb1.Text = _name;
            tb2.Text = _description;
            tb3.DisplayDate = _defaultDate;
            tb4.DataContext = _priority;
        }
        public EditFormView(DateTime date):this()
        {
            tb3.DisplayDate = date;
        }

        public EditFormView(string name, string description, DateTime date):this()
        {
            tb1.Text = name;
            tb2.Text = description;
            tb3.SelectedDate = date;
        }
    }
}