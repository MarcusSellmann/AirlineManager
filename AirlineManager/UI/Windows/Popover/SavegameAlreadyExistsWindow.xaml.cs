using AirlineManager.UI.Interfaces;

using MahApps.Metro.Controls;

namespace AirlineManager.UI.Windows.Popover {
    /// <summary>
    /// Interaktionslogik für SavegameAlreadyExistsWindow.xaml
    /// </summary>
    public partial class SavegameAlreadyExistsWindow : MetroWindow {
        #region Attributes
        private ISavegameOverrideInteractionListener m_listener = null;
        #endregion

        public SavegameAlreadyExistsWindow(ISavegameOverrideInteractionListener listener) {
            m_listener = listener;

            InitializeComponent();
        }

        private void btnAbort_Click(object sender, System.Windows.RoutedEventArgs e) {
            m_listener.overrideAborted();
            Close();
        }

        private void btnConfirm_Click(object sender, System.Windows.RoutedEventArgs e) {
            m_listener.overrideConfirmed();
            Close();
        }
    }
}
