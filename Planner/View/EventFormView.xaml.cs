using Planner.Model;
using Planner.ViewModel;

namespace Planner.View
{
    public partial class EventFormView
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