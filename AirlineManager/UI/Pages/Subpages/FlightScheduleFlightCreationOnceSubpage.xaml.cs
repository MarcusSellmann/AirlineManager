using System;
using System.Windows.Controls;

namespace AirlineManager.UI.Pages
{
    /// <summary>
    /// Interaktionslogik für FlightScheduleFlightCreationOnceSubpage.xaml
    /// </summary>
    public partial class FlightScheduleFlightCreationOnceSubpage : Page
    {
        public FlightScheduleFlightCreationOnceSubpage()
        {
            InitializeComponent();

            dtpDepartureDateTime.Value = DateTime.Now;
        }
    }
}
