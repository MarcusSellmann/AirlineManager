using System.Windows;
using AirlineManager.Business;
using AirlineManager.Business.ExceptionHandling;
using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for AirlineCreationWindow.xaml
	/// </summary>
	public partial class AirlineCreationWindow : Window {
		IPopoverWindowCreatorCallback m_callback = null;

		public IPopoverWindowCreatorCallback Callback {
			get {
				return m_callback;
			}

			set {
				m_callback = value;
			}
		}

		public AirlineCreationWindow() {
			InitializeComponent();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e) {
			try {
				MainGameController.Instance.CreateAirline(tbName.Text, tbCode.Text);
				m_callback.actionSuccessful(this);
				Close();
			} catch (IncorrectInputUIException exc) {
				MessageBox.Show(exc.CorrectInputHint);
			}
		}

		private void btnAbort_Click(object sender, RoutedEventArgs e) {
			m_callback.actionAborted(this);
			Close();
		}
	}
}
