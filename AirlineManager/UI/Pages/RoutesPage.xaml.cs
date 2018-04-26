using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Data;
using AirlineManager.Business;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Geometries;
using Mapsui.Styles;
using Mapsui.Utilities;
using Mapsui.Projection;

using System;
using System.Windows.Input;

using AirlineManager.Business.Databases;

namespace AirlineManager.UI.Pages {
	/// <summary>
	/// Interaction logic for RoutesPage.xaml
	/// </summary>
	public partial class RoutesPage : Page {
		private ObservableCollection<Route> m_routes = new ObservableCollection<Route>();
		Mapsui.Map m_map = null;

		public RoutesPage() {
			List<Route> routes = MainGameController.Instance.CurrentAirline.RouteNetwork;

            foreach (Route r in routes) {
				m_routes.Add(r);
			}

			InitializeComponent();
			
			lvRoutes.ItemsSource = m_routes;

			m_map = RoutesMapControl.Map;
			m_map.Layers.Add(OpenStreetMap.CreateTileLayer());

			//InsertTestData();
		}

		private void RemoveExistingRouteLayers() {
			RemoveExistingLayers("RouteLayer");
		}

		private void RemoveExistingLayers(string layerName) {
			var existingRouteLayers = m_map.Layers.FindLayer(layerName);

			try {
				foreach (var routeLayer in existingRouteLayers) {
					m_map.Layers.Remove(routeLayer);
				}
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		private void lvRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			RemoveExistingRouteLayers();

			var style = new VectorStyle {
				Fill = null,
				Outline = null,
				Line = { Color = Color.Red, Width = 4 }
			};

			Route r = m_routes[(sender as ListView).SelectedIndex];

			ILayer memlayer = new MemoryLayer {
				Name = "RouteLayer",
				Style = style,
				DataSource = new MemoryProvider(new Feature {
					Styles = new List<IStyle> { style },
					Geometry = new LineString(new[] {
						SphericalMercator.FromLonLat(r.Origin.Coordinate.Longitude, r.Origin.Coordinate.Latitude),
						SphericalMercator.FromLonLat(r.Destination.Coordinate.Longitude, r.Destination.Coordinate.Latitude)
					})
				})
			};

			m_map.Layers.Add(memlayer);
			m_map.ViewChanged(false);
		}

		private void InsertTestData() {
			AirportDatabase aDb = AirportDatabase.Instance;
			AircraftInstanceDatabase aiDB = AircraftInstanceDatabase.Instance;

			Dictionary<ClassType, long> tp = new Dictionary<ClassType, long>();
			tp[ClassType.Economy] = 100;
			tp[ClassType.Business] = 200;
			tp[ClassType.First] = 300;
			tp[ClassType.Cargo] = 10;

			UsedAircraftInstanceContainer[] acs = aiDB.UsedAircrafts.ToArray();

			Route r1 = new Route(RouteType.Domestic, "NA1250", aDb.DB[0], aDb.DB[1], tp);
			Route r2 = new Route(RouteType.Domestic, "NA5181", aDb.DB[1], aDb.DB[2], tp);

			m_routes.Add(r1);
			m_routes.Add(r2);
		}

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new RouteCreationPage());
        }

        private void btnRemove_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
