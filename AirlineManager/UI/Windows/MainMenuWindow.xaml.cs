using System.Windows;

using MahApps.Metro.Controls;

using AirlineManager.Business;
using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for MainMenuWindow.xaml
	/// </summary>
	public partial class MainMenuWindow : MetroWindow, INewGameCreationSuccessListener {
		public MainMenuWindow() {
			InitializeComponent();

			if (!SavegameHandler.DoesSavegameExists) {
				btnLoadGame.IsEnabled = false;
			}
		}

		private void btnNewGame_Click(object sender, RoutedEventArgs e) {
            new NewGameContextWindow(this).Show();
		}

		private void btnLoadGame_Click(object sender, RoutedEventArgs e) {
            MainGameController.Instance.LoadGame();

            new MainWindow().Show();
            Close();
		}

		private void btnQuit_Click(object sender, RoutedEventArgs e) {
			Close();
		}

        public void NewGameCreationSuccessfull() {
            Close();
        }
    }
}
