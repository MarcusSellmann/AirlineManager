using System.Windows;
using AirlineManager.Business;
using AirlineManager.Business.ExceptionHandling;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for PlayerCreationWindow.xaml
	/// </summary>
	public partial class PlayerCreationWindow : Window {
		public PlayerCreationWindow() {
			InitializeComponent();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e) {
			try {
				MainGameController.Instance.CreatePlayer(tbName.Text);
				Close();
            } catch (IncorrectInputUIException exc) {
				MessageBox.Show(exc.CorrectInputHint);
			}
        }
	}
}
