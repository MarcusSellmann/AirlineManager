using System.Windows;
using System.Windows.Controls;

using AirlineManager.Business;
using AirlineManager.UI.Interfaces;
using AirlineManager.UI.Windows.Popover;

namespace AirlineManager.UI.Pages
{
    /// <summary>
    /// Interaction logic for GameMenuPage.xaml
    /// </summary>
    public partial class GameMenuPage : Page, ISavegameOverrideInteractionListener {
        public GameMenuPage() {
            InitializeComponent();
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e) {
            if (MainGameController.Instance.DoesSavegameExist()) {
                new SavegameAlreadyExistsWindow(this).Show();
            } else {
                MainGameController.Instance.SaveGame();
            }
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e) {
            MainGameController.Instance.LoadGame();
            NavigationService.Navigate(new DashboardPage());
        }

        private void btnExitGame_Click(object sender, RoutedEventArgs e) {
            
        }

        public void overrideConfirmed() {
            MainGameController.Instance.SaveGame();
        }

        public void overrideAborted() {
        }
    }
}
