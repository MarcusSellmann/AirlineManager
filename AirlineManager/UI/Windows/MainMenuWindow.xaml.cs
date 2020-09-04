using System.Windows;

using MahApps.Metro.Controls;

using AirlineManager.Business;
using AirlineManager.UI.Interfaces;
using AirlineManager.UI.Windows.Popover;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for MainMenuWindow.xaml
	/// </summary>
	public partial class MainMenuWindow : MetroWindow, INewGameCreationSuccessListener, ISavegameChosenListener {
		public MainMenuWindow() {
			InitializeComponent();

			if (!SavegameHandler.DoesAnySavegameExist()) {
				btnLoadGame.IsEnabled = false;
			}
		}

		private void btnNewGame_Click(object sender, RoutedEventArgs e) {
            new NewGameContextWindow(this).Show();
		}

		private void btnLoadGame_Click(object sender, RoutedEventArgs e) {
            new ChooseSavegameWindow(this, ChooseSavegameWindow.SavegameProcess.Load).Show();
		}

		private void btnQuit_Click(object sender, RoutedEventArgs e) {
			Close();
		}

        public void NewGameCreationSuccessfull() {
            MainGameController.Instance.GameClock.InitGameClock();
            MainGameController.Instance.GameClock.StartGameTick();
            Close();
        }

        public void SavegameChosenSuccessful(ChooseSavegameWindow.SavegameProcess process, string savegameName) {
            SavegameHandler.LoadGame(savegameName);
            MainGameController.Instance.GameClock.StartGameTick();
            new MainWindow().Show();
            Close();
        }

        public void SavegameChooseAborted() {
        }
    }
}
