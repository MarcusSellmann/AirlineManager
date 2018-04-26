using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages
{
    /// <summary>
    /// Interaction logic for AircraftInstancePage.xaml
    /// </summary>
    public partial class AircraftInstancePage : Page
    {
        private ObservableCollection<AircraftInstance> m_aircraftInstances = new ObservableCollection<AircraftInstance>();

        public AircraftInstancePage()
        {
            MainGameController mGc = MainGameController.Instance;
            List<AircraftInstance> aircraftInstances = mGc.CurrentAirline.OwnedAircrafts;

            foreach (AircraftInstance ai in aircraftInstances)
            {
                m_aircraftInstances.Add(ai);
            }

            InitializeComponent();

            lvAircraftInstances.ItemsSource = m_aircraftInstances;
        }

        private void btnAddNewAircraftInstance_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AircraftMarketPage());
        }
    }
}
