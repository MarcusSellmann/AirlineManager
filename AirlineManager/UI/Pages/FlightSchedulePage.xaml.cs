using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaction logic for FlightSchedulePage.xaml
    /// </summary>
    public partial class FlightSchedulePage : Page {
		private ObservableCollection<Flight> m_flightSchedule = new ObservableCollection<Flight>();

		public FlightSchedulePage() {
            Dictionary<string, Flight> aFs = MainGameController.Instance.CurrentAirline.FlightSchedule.ScheduledFlights;

			foreach (KeyValuePair<string, Flight> f in aFs) {
                m_flightSchedule.Add(f.Value);
			}

			InitializeComponent();

            lvFlightSchedule.ItemsSource = m_flightSchedule;
		}

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e) {
            NavigationService.Navigate(new FlightScheduleFlightCreationPage());
        }

        private void btnRemove_Click(object sender, System.Windows.RoutedEventArgs e) {

        }
    }
}
