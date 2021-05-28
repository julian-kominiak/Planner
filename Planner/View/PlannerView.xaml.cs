﻿using System;
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

        public static readonly DependencyProperty CalendarSelectedDateProperty =
            DependencyProperty.Register(
                nameof(CalendarSelectedDate),
                typeof(DateTime),
                typeof(PlannerView));
        public DateTime CalendarSelectedDate
        {
            get { return (DateTime)GetValue(CalendarSelectedDateProperty); }
            set { SetValue(CalendarSelectedDateProperty, value); }
        }


    }
}
