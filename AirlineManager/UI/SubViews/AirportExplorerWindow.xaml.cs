using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.UI.SubViews {
	/// <summary>
	/// Interaction logic for AirportExplorerWindow.xaml
	/// </summary>
	public partial class AirportExplorerWindow : Window {
		ObservableCollection<Airport> m_airports = new ObservableCollection<Airport>();

		public AirportExplorerWindow() {
			InitializeComponent();

			AirportDatabase aDb = AirportDatabase.Instance;
			List<Airport> airports = aDb.DB;

			foreach (Airport ap in airports) {
				m_airports.Add(ap);
			}

			lbAirports.ItemsSource = m_airports;
		}
	}
}
