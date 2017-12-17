using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for AircraftExplorerWindow.xaml
	/// </summary>
	public partial class AircraftExplorerWindow : Window {
		private ObservableCollection<Aircraft> m_aircrafts = new ObservableCollection<Aircraft>();

		public AircraftExplorerWindow() {
			AircraftDatabase aDb = AircraftDatabase.Instance;
			List<Aircraft> aircrafts = aDb.DB;

			foreach (Aircraft ac in aircrafts) {
				m_aircrafts.Add(ac);
            }

			InitializeComponent();

			dgAircrafts.ItemsSource = m_aircrafts;
		}
	}
}
