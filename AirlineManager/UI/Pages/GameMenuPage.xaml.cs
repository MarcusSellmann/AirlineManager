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
    public partial class GameMenuPage : Page, ISavegameChosenListener {
        public GameMenuPage() {
            InitializeComponent();
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e) {
            new ChooseSavegameWindow(this, ChooseSavegameWindow.SavegameProcess.Save).Show();
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e) {
            new ChooseSavegameWindow(this, ChooseSavegameWindow.SavegameProcess.Load).Show();
        }

        private void btnExitGame_Click(object sender, RoutedEventArgs e) {
            
        }

        public void SavegameChosenSuccessful(ChooseSavegameWindow.SavegameProcess process, string savegameName) {
            if (process == ChooseSavegameWindow.SavegameProcess.Save) {
                SavegameHandler.SaveGame(MainGameController.Instance, savegameName);
            } else if (process == ChooseSavegameWindow.SavegameProcess.Load) {
                SavegameHandler.LoadGame(savegameName);
                NavigationService.Navigate(new DashboardPage());
            }
        }

        public void SavegameChooseAborted() {
        }
    }
}
