using System.Windows;
using AirlineManager.Business;
using AirlineManager.Business.ExceptionHandling;
using AirlineManager.UI.Interfaces;
using AirlineManager.UI.Windows.Popover;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for PlayerCreationWindow.xaml
	/// </summary>
	public partial class PlayerCreationWindow : Window {
		IPopoverWindowCreatorCallback m_callback = null;

		public IPopoverWindowCreatorCallback Callback {
			get {
				return m_callback;
			}

			set {
				m_callback = value;
			}
		}

		public PlayerCreationWindow() : base() {
			InitializeComponent();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e) {
			try {
				MainGameController.Instance.CreatePlayer(tbName.Text);
				m_callback.actionSuccessful(this);
				base.Close();
			} catch (IncorrectInputUIException exc) {
				MessageBox.Show(exc.CorrectInputHint);
			}
        }

		private void btnAbort_Click(object sender, RoutedEventArgs e) {
			m_callback.actionAborted(this);
			base.Close();
		}
	}
}
