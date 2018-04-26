using System;
using System.Windows;
using System.Windows.Controls;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaktionslogik für FlightScheduleFlightCreationComplexSubpage.xaml
    /// </summary>
    public partial class FlightScheduleFlightCreationComplexSubpage : Page
    {
        public FlightScheduleFlightCreationComplexSubpage()
        {
            InitializeComponent();

            tpDepartureTime.Value = DateTime.Now;
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e) {
            cbMonday.IsChecked = 
            cbTuesday.IsChecked = 
            cbWednesday.IsChecked = 
            cbThursday.IsChecked = 
            cbFriday.IsChecked = 
            cbSaturday.IsChecked = 
            cbSunday.IsChecked = true;
        }

        private void btnSelectNone_Click(object sender, RoutedEventArgs e) {
            cbMonday.IsChecked =
            cbTuesday.IsChecked =
            cbWednesday.IsChecked =
            cbThursday.IsChecked =
            cbFriday.IsChecked =
            cbSaturday.IsChecked =
            cbSunday.IsChecked = false;
        }
    }
}
