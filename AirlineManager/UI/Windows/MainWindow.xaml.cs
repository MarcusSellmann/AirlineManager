using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

using MahApps.Metro.Controls;

using AirlineManager.Business;
using AirlineManager.UI.Pages;

namespace AirlineManager {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow {
        private enum MainMenuTabs {
            Dashboard,
            Aircrafts,
            Airports,
            Routes,
            Schedule,
            Maintenance,
            GameMenu
        }

        #region Attributes
        private DispatcherTimer m_timer = null;
        private MainMenuTabs m_lastActiveTab;
        #endregion

        public MainWindow() {
			InitializeComponent();

			m_timer = new DispatcherTimer();
			m_timer.Interval = new TimeSpan(0, 0, 1);
			m_timer.Tick += MainGameTick;
            m_timer.Start();

			_mainFrame.Navigate(new DashboardPage());
            UpdateActiveTabBackground(MainMenuTabs.Dashboard);
        }

		private void MainGameTick(object sender, EventArgs e) {
            DateTime currTime = MainGameController.Instance.GameClock.CurrentTimeGameTime;

            lblCurrentDate.Content = currTime.ToString("ddd dd.MM.yyyy");
            lblCurrentTime.Content = currTime.ToString("HH:mm:ss");
        }

		private void btnDashboard_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new DashboardPage());
            UpdateActiveTabBackground(MainMenuTabs.Dashboard);
        }

		private void btnAircrafts_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new AircraftInstancePage());
            UpdateActiveTabBackground(MainMenuTabs.Aircrafts);
        }

		private void btnRoutes_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new RoutesPage());
            UpdateActiveTabBackground(MainMenuTabs.Routes);
        }

		private void btnMaintainance_Click(object sender, RoutedEventArgs e) {
            UpdateActiveTabBackground(MainMenuTabs.Maintenance);
        }

		private void btnAirports_Click(object sender, RoutedEventArgs e) {
			_mainFrame.Navigate(new AirportsPage());
            UpdateActiveTabBackground(MainMenuTabs.Airports);
        }

        private void btnGameMenu_Click(object sender, RoutedEventArgs e) {
            _mainFrame.Navigate(new GameMenuPage());
            UpdateActiveTabBackground(MainMenuTabs.GameMenu);
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e) {
            _mainFrame.Navigate(new FlightSchedulePage());
            UpdateActiveTabBackground(MainMenuTabs.Schedule);
        }

        private void UpdateActiveTabBackground(MainMenuTabs activeTab) {
            m_lastActiveTab = activeTab;

            btnDashboard.Background = Brushes.Transparent;
            btnAircrafts.Background = Brushes.Transparent;
            btnAirports.Background = Brushes.Transparent;
            btnRoutes.Background = Brushes.Transparent;
            btnSchedule.Background = Brushes.Transparent;
            btnMaintainance.Background = Brushes.Transparent;
            btnGameMenu.Background = Brushes.Transparent;

            Brush highlightedButton = (Brush)Application.Current.TryFindResource("AmButtonHighlightedBackground");

            switch (activeTab) {
                case MainMenuTabs.Dashboard:
                    btnDashboard.Background = highlightedButton;
                    break;

                case MainMenuTabs.Aircrafts:
                    btnAircrafts.Background = highlightedButton;
                    break;

                case MainMenuTabs.Airports:
                    btnAirports.Background = highlightedButton;
                    break;

                case MainMenuTabs.Routes:
                    btnRoutes.Background = highlightedButton;
                    break;

                case MainMenuTabs.Schedule:
                    btnSchedule.Background = highlightedButton;
                    break;

                case MainMenuTabs.Maintenance:
                    btnMaintainance.Background = highlightedButton;
                    break;

                case MainMenuTabs.GameMenu:
                    btnGameMenu.Background = highlightedButton;
                    break;

                default:
                    break;
            }
        }

        private void ShowStatusBar() {
            Storyboard sb = Resources["sbShowStatusBar"] as Storyboard;
            sb.Begin(lblStatusBar);
        }

        private void HideStatusBar() {
            Storyboard sb = Resources["sbHideStatusBar"] as Storyboard;
            sb.Begin(lblStatusBar);
        }
    }
}
