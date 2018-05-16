using System;
using System.Windows;
using System.Windows.Threading;
using AirlineManager.UI.Pages;
using MahApps.Metro.Controls;

namespace AirlineManager {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow {
		private DispatcherTimer m_timer = null;

		public MainWindow() {
			InitializeComponent();

			m_timer = new DispatcherTimer();
			m_timer.Interval = new TimeSpan(0, 0, 1);
			m_timer.Tick += MainGameTick;
            m_timer.Start();

			_mainFrame.Navigate(new DashboardPage());
		}

		private void MainGameTick(object sender, EventArgs e) {
			lblCurrentTime.Content = DateTime.Now.ToString();
        }

		private void btnDashboard_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new DashboardPage());
		}

		private void btnAircrafts_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new AircraftInstancePage());
		}

		private void btnRoutes_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new RoutesPage());
		}

		private void btnMaintainance_Click(object sender, RoutedEventArgs e) {
            _mainFrame.Navigate(new MaintenancePage());
		}

		private void btnAirports_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new AirportsPage());
		}

        private void btnGameMenu_Click(object sender, RoutedEventArgs e) {
            _mainFrame.Navigate(new GameMenuPage());
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e) {
            _mainFrame.Navigate(new FlightSchedulePage());
        }
    }
}
