using System.Windows;

using AirlineManager.Business;
using AirlineManager.UI.Menu;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for MainMenuWindow.xaml
	/// </summary>
	public partial class MainMenuWindow : Window {
		public MainMenuWindow() {
			InitializeComponent();

            MenuSwitcher.mainMenu = this;

			if (!SavegameHandler.DoesSavegameExists) {
				btnLoadGame.IsEnabled = false;
			}
		}

		public void actionSuccessful(object sender) {
			if (sender is PlayerCreationWindow) {
				AirlineCreationWindow acWin = new AirlineCreationWindow();
				acWin.Callback = this;
				acWin.Show();
			} else if (sender is AirlineCreationWindow) {
				new MainWindow().Show();
				Close();
			}
		}

		public void actionAborted(object sender) {
		}

		private void btnNewGame_Click(object sender, RoutedEventArgs e) {
			PlayerCreationWindow pcWin = new PlayerCreationWindow();
			pcWin.Callback = this;
			pcWin.Show();
		}

		private void btnLoadGame_Click(object sender, RoutedEventArgs e) {

		}

		private void btnQuit_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
