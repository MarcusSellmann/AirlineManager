using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Pages.NewGamePages {
    /// <summary>
    /// Interaktionslogik für PlayerCreationPage.xaml
    /// </summary>
    public partial class PlayerCreationPage : Page {
        #region Attributes
        IPlayerInformationEnteredListener m_pListener = null;
        IAirlineInformationsEnteredListener m_aListener = null;
        #endregion

        public PlayerCreationPage(IPlayerInformationEnteredListener pListener, IAirlineInformationsEnteredListener aListener) {
            m_pListener = pListener;
            m_aListener = aListener;

            InitializeComponent();

            btnNext.IsEnabled = false;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e) {
            m_pListener.PlayerNameEntered(tbName.Text);
            NavigationService.Navigate(new AirlineCreationPage(m_aListener));
        }

        private void btnAbort_Click(object sender, RoutedEventArgs e) {
            m_pListener.Aborted();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e) {
            btnNext.IsEnabled = tbName.Text.Length > 0;
        }
    }
}
