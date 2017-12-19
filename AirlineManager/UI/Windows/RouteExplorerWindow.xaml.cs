using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using AirlineManager.Data;
using AirlineManager.Business;
using BruTile.Predefined;
using Mapsui.Layers;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for RouteExplorerWindow.xaml
	/// </summary>
	public partial class RouteExplorerWindow : Window {
		private ObservableCollection<Route> m_routes = new ObservableCollection<Route>();
        Mapsui.Map m_map = null;

        public RouteExplorerWindow() {
			MainGameController controller = MainGameController.Instance;
			List<Route> routes = controller.OperatedRoutes;

			foreach (Route r in routes) {
				m_routes.Add(r);
			}

			InitializeComponent();

			dgRoutes.ItemsSource = m_routes;

            m_map = RoutesMapControl.Map;
            m_map.Layers.Add(new TileLayer(KnownTileSources.Create()));
        }

        private void btnAdd_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {

        }

        private void btnRemove_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {

        }
    }
}
