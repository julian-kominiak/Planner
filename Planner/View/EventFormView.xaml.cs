using System;
using System.Collections.Generic;
using System.Windows;

namespace Planner.View
{
    public partial class EventFormView : Window
    {
        public EventFormView(string windowTitle)
        {
            InitializeComponent();
            Title = windowTitle;
        }
    }
}