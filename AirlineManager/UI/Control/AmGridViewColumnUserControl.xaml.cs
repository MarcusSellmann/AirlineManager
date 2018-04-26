using System.Windows.Controls;

namespace AirlineManager.UI.Control {
	/// <summary>
	/// Interaction logic for AmGridViewColumnUserControl.xaml
	/// </summary>
	public partial class AmGridViewColumnUserControl : GridViewColumn {
		public string Text { get; set; }

		public AmGridViewColumnUserControl() {
			InitializeComponent();
		}
	}
}
