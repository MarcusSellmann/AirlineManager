using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using AirlineManager.Business;
using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaction logic for FlightScheduleFlightCreationPage.xaml
    /// </summary>
    public partial class FlightScheduleFlightCreationPage : Page {
        #region Attributes
        private ObservableCollection<Route> m_routes = new ObservableCollection<Route>();
        private ObservableCollection<AircraftInstance> m_aircrafts = new ObservableCollection<AircraftInstance>();
        #endregion

        public FlightScheduleFlightCreationPage() {
            List<Route> rs = MainGameController.Instance.UnoperatedRoutes;

            foreach (Route r in rs) {
                m_routes.Add(r);
            }

            List<AircraftInstance> acs = MainGameController.Instance.CurrentAirline.UnassignedAircrafts;

            foreach (AircraftInstance ac in acs) {
                m_aircrafts.Add(ac);
            }

            InitializeComponent();
            lvRoutes.ItemsSource = m_routes;
            lvAircrafts.ItemsSource = m_aircrafts;

            _flightFrequency.Navigate(new FlightScheduleFlightCreationOnceSubpage());
            btnCreateFlight.IsEnabled = false;
        }

        private void lvRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateCreateButtonStatus();
        }

        private void lvAircrafts_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateCreateButtonStatus();
        }

        private void btnCreateFlight_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new FlightSchedulePage());
        }

        private void UpdateCreateButtonStatus() {
            if (lvRoutes.SelectedIndex != -1 &&
                lvAircrafts.SelectedIndex != -1)
            {
                btnCreateFlight.IsEnabled = true;
            } else {
                btnCreateFlight.IsEnabled = false;
            }
        }

        private void rbFlightFrequencyOnce_Checked(object sender, RoutedEventArgs e) {
            if (_flightFrequency == null) {
                _flightFrequency = new Frame();
            }

            _flightFrequency.Navigate(new FlightScheduleFlightCreationOnceSubpage());
        }

        private void rbFlightFrequencyComplex_Checked(object sender, RoutedEventArgs e) {
            if (_flightFrequency == null) {
                _flightFrequency = new Frame();
            }

            _flightFrequency.Navigate(new FlightScheduleFlightCreationComplexSubpage());
        }
    }
}
