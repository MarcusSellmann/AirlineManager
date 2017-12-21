﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AirlineManager.Business.Databases;
using AirlineManager.Data;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Utilities;

namespace AirlineManager.UI.SubViews {
	/// <summary>
	/// Interaction logic for AirportExplorerWindow.xaml
	/// </summary>
	public partial class AirportExplorerWindow : Window {
		ObservableCollection<Airport> m_airports = new ObservableCollection<Airport>();
		Mapsui.Map m_map = null;

		public AirportExplorerWindow() {
			InitializeComponent();

			AirportDatabase aDb = AirportDatabase.Instance;
			List<Airport> airports = aDb.DB;

			foreach (Airport ap in airports) {
				m_airports.Add(ap);
			}

			dgAirports.ItemsSource = m_airports;

			m_map = AirportsMapControl.Map;
            m_map.Layers.Add(OpenStreetMap.CreateTileLayer());
		}

		private void dgAirports_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			Airport ap = m_airports[(sender as DataGrid).SelectedIndex];
			
			var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(ap.Coordinate.Longitude, ap.Coordinate.Latitude);
			m_map.NavigateTo(sphericalMercatorCoordinate);
			m_map.NavigateTo(m_map.Resolutions[12]);
		}
	}
}
