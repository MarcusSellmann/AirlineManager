using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.UI.Pages {
	/// <summary>
	/// Interaction logic for AircraftsPage.xaml
	/// </summary>
	public partial class AircraftsPage : Page {
		private ObservableCollection<Aircraft> m_aircrafts = new ObservableCollection<Aircraft>();

		public AircraftsPage() {
			AircraftDatabase aDb = AircraftDatabase.Instance;
			List<Aircraft> aircrafts = aDb.DB;

			foreach (Aircraft ac in aircrafts) {
				m_aircrafts.Add(ac);
			}

			InitializeComponent();

			lvAircrafts.ItemsSource = m_aircrafts;
		}
	}
}
