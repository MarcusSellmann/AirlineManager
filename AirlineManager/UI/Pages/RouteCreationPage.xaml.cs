using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AirlineManager.Business;
using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaction logic for RouteCreationPage.xaml
    /// </summary>
    public partial class RouteCreationPage : Page {
        private ObservableCollection<Airport> m_airports = new ObservableCollection<Airport>();
        private ObservableCollection<AircraftInstance> m_aircrafts = new ObservableCollection<AircraftInstance>();

        public RouteCreationPage() {
            List<AircraftInstance> acs = MainGameController.Instance.CurrentAirline.UnassignedAircrafts;

            foreach (AircraftInstance ac in acs) {
                m_aircrafts.Add(ac);
            }

            List<Airport> aps = AirportDatabase.Instance.DB;

            foreach (Airport ap in aps) {
                m_airports.Add(ap);
            }

            InitializeComponent();

            cbOrigin.ItemsSource = m_airports;
            cbDestination.ItemsSource = m_airports;
            btnCreateRoute.IsEnabled = false;
        }

        private void cbOrigin_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateCreateButtonStatus();
            UpdateRouteType();
        }

        private void cbDestination_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateCreateButtonStatus();
            UpdateRouteType();
        }

        private void cbAssignedAc_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateCreateButtonStatus();
        }

        private void tboRouteNumber_TextChanged(object sender, TextChangedEventArgs e) {
            UpdateCreateButtonStatus();
        }

        private void btnCreateRoute_Click(object sender, RoutedEventArgs e) {
            RouteType rt = RouteType.Domestic;

            if (lblRouteType.Content.Equals(RouteType.International.ToString())) {
                rt = RouteType.International;
            }

            MainGameController.Instance.CurrentAirline.AddRoute(new Route(rt,
                                                                          tboRouteNumber.Text,
                                                                          (Airport)cbOrigin.SelectedItem,
                                                                          (Airport)cbDestination.SelectedItem,
                                                                          new Dictionary<ClassType, long>()));
            NavigationService.Navigate(new RoutesPage());
        }

        private bool IsOriginDestinationChoiceValid() {
            if (cbOrigin.SelectedIndex > -1 && cbDestination.SelectedIndex > -1 &&
                cbOrigin.SelectedValue != cbDestination.SelectedValue) {
                return true;
            } else {
                return false;
            }
        }

        private void UpdateRouteType() {
            if (cbOrigin.SelectedIndex == -1 || cbDestination.SelectedIndex == -1) {
                lblRouteType.Content.Equals("undefined");
            } else if (m_airports[cbOrigin.SelectedIndex].Country.Equals(m_airports[cbDestination.SelectedIndex].Country)) {
                lblRouteType.Content.Equals(RouteType.Domestic.ToString());
            } else {
                lblRouteType.Content.Equals(RouteType.International.ToString());
            }
        }

        private void UpdateCreateButtonStatus() {
            if (IsOriginDestinationChoiceValid() &&
                tboRouteNumber.Text.Length > 0 &&
                !MainGameController.Instance.IsRouteExisting(tboRouteNumber.Text)) {
                btnCreateRoute.IsEnabled = true;
            } else {
                btnCreateRoute.IsEnabled = false;
            }
        }
    }
}
