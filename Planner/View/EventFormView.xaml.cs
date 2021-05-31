﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using Planner.Model;
using Planner.ViewModel;

namespace Planner.View
{
    public partial class EventFormView : Window
    {
        public EventFormView()
        {
            InitializeComponent();
            DataContext = new EventFormViewModel();
        }

        public EventFormView(Event @event)
        {
            InitializeComponent();
            DataContext = new EventFormViewModel(@event);
        }
    }
}