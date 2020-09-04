using System.Windows;
using System.Windows.Controls;

using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Pages.NewGamePages {
    /// <summary>
    /// Interaktionslogik für AirlineCreationPage.xaml
    /// </summary>
    public partial class AirlineCreationPage : Page {
        #region Attributes
        private IAirlineInformationsEnteredListener m_listener = null;
        #endregion

        public AirlineCreationPage(IAirlineInformationsEnteredListener listener) {
            m_listener = listener;

            InitializeComponent();

            btnCreate.IsEnabled = false;
        }

        private void btnAbort_Click(object sender, RoutedEventArgs e) {
            m_listener.Aborted();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e) {
            m_listener.AirlineInformationEntered(tbName.Text, tbCode.Text);
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e) {
            UpdateCreationButtonState();
        }

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e) {
            UpdateCreationButtonState();
        }

        private void UpdateCreationButtonState() {
            btnCreate.IsEnabled = tbName.Text.Length > 0 && tbCode.Text.Length > 0;
        }
    }
}
