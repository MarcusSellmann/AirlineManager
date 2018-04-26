using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business;
using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages {
	/// <summary>
	/// Interaction logic for AircraftsPage.xaml
	/// </summary>
	public partial class AircraftMarketPage : Page {
		private ObservableCollection<UsedAircraftInstanceContainer> m_aircraftInstances = new ObservableCollection<UsedAircraftInstanceContainer>();

		public AircraftMarketPage() {
            RefreshUsedAircraftDatabase();
			InitializeComponent();

            lvMarketAircraftInstances.ItemsSource = m_aircraftInstances;
            btnBuyAircraftInstance.IsEnabled = false;
		}

        private void RefreshUsedAircraftDatabase() {
            AircraftInstanceDatabase aiDb = AircraftInstanceDatabase.Instance;
            List<UsedAircraftInstanceContainer> aircraftInstances = aiDb.UsedAircrafts;
            m_aircraftInstances.Clear();

            foreach (UsedAircraftInstanceContainer ai in aircraftInstances) {
                m_aircraftInstances.Add(ai);
            }
        }

        private void btnBuyAircraftInstance_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (lvMarketAircraftInstances.SelectedItem != null) {
                UsedAircraftInstanceContainer acToBuy = (lvMarketAircraftInstances.SelectedItem as UsedAircraftInstanceContainer);

                if (MainGameController.Instance.BuyAircraft(acToBuy)) {
                    RefreshUsedAircraftDatabase();
                    NavigationService.Navigate(new AircraftInstancePage());
                }
            }
        }

        private void lvMarketAircraftInstances_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListView lv = sender as ListView;

            if (lvMarketAircraftInstances.SelectedItem != null) {
                UsedAircraftInstanceContainer usedAc = (lvMarketAircraftInstances.SelectedItem as UsedAircraftInstanceContainer);
                long alBudget = MainGameController.Instance.CurrentAirline.Money;

                if (usedAc.Aircraft.CurrentValue < alBudget && usedAc.AvailableTill >= DateTime.Now) {
                    btnBuyAircraftInstance.IsEnabled = true;
                } else {
                    btnBuyAircraftInstance.IsEnabled = false;
                }
            }
        }
    }
}
