using MahApps.Metro.Controls;

using AirlineManager.Business;
using AirlineManager.UI.Pages.NewGamePages;
using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Windows {
    /// <summary>
    /// Interaktionslogik für NewGameContextWindow.xaml
    /// </summary>
    public partial class NewGameContextWindow : MetroWindow, IPlayerInformationEnteredListener, IAirlineInformationsEnteredListener {
        #region Attributes
        private INewGameCreationSuccessListener m_listener = null;
        private string m_playerName = "";
        #endregion

        public NewGameContextWindow(INewGameCreationSuccessListener listener) {
            m_listener = listener;

            InitializeComponent();

            _mainFrame.Navigate(new PlayerCreationPage(this, this));
        }

        public void PlayerNameEntered(string name) {
            m_playerName = name;
        }

        public void AirlineInformationEntered(string name, string code) {
            MainGameController.Instance.CreatePlayer(m_playerName);
            MainGameController.Instance.CreateAirline(name, code);

            new MainWindow().Show();
            Close();
            m_listener.NewGameCreationSuccessfull();
        }

        public void Aborted() {
            Close();
        }
    }
}
