using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaktionslogik für AirportsLicensePage.xaml
    /// </summary>
    public partial class AirportsLicensePage : Page {
        ObservableCollection<Airport> m_airports = new ObservableCollection<Airport>();

        public AirportsLicensePage() {
            InitializeComponent();

            List<Airport> aDB = MainGameController.Instance.UnlicensedAirports;

            foreach (Airport a in aDB) {
                m_airports.Add(a);
            }

            lvUnlicensedAirports.ItemsSource = m_airports;
        }

        private void btnBuyLicense_Click(object sender, System.Windows.RoutedEventArgs e) {
            foreach (Airport a in lvUnlicensedAirports.SelectedItems) {
                MainGameController.Instance.CurrentAirline.BuyAirportLicense(a);
            }
            
            NavigationService.Navigate(new AirportsPage());
        }

        private void lvUnlicensedAirports_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnBuyLicense.IsEnabled = IsEnoughMoneyAvailable();
        }

        private bool IsEnoughMoneyAvailable() {
            return MainGameController.Instance.CurrentAirline.Money >= Airline.PRIZE_AIRPORT_LICENSE * lvUnlicensedAirports.SelectedItems.Count;
        }
    }
}
