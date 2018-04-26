using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business.Databases;
using AirlineManager.Data;
using Mapsui.Projection;
using Mapsui.Utilities;

namespace AirlineManager.UI.Pages {
	/// <summary>
	/// Interaction logic for AirportsPage.xaml
	/// </summary>
	public partial class AirportsPage : Page {
		ObservableCollection<Airport> m_airports = new ObservableCollection<Airport>();
		Mapsui.Map m_map = null;

		public AirportsPage() {
			InitializeComponent();

			AirportDatabase aDb = AirportDatabase.Instance;
			List<Airport> airports = aDb.DB;

			foreach (Airport ap in airports) {
				m_airports.Add(ap);
			}

			lvAirports.ItemsSource = m_airports;

			m_map = AirportsMapControl.Map;
			m_map.Layers.Add(OpenStreetMap.CreateTileLayer());
		}

		private void lvAirports_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			Airport ap = m_airports[(sender as ListView).SelectedIndex];

			var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(ap.Coordinate.Longitude, ap.Coordinate.Latitude);
			m_map.NavigateTo(sphericalMercatorCoordinate);
			m_map.NavigateTo(m_map.Resolutions[12]);
		}

        private void ICAO_Header_Click(object sender, System.Windows.RoutedEventArgs e) {

        }
    }
}
