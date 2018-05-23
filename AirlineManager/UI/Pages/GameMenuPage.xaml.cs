using System.Windows;
using System.Windows.Controls;
using AirlineManager.Business;

namespace AirlineManager.UI.Pages
{
    /// <summary>
    /// Interaction logic for GameMenuPage.xaml
    /// </summary>
    public partial class GameMenuPage : Page {
        public GameMenuPage() {
            InitializeComponent();
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e) {
            MainGameController.Instance.SaveGame();
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e) {
            MainGameController.Instance.LoadGame();
            NavigationService.Navigate(new DashboardPage());
        }

        private void btnExitGame_Click(object sender, RoutedEventArgs e) {
            
        }
    }
}
