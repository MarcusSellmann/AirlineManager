using System.Windows.Controls;
using System.Windows.Media;

namespace AirlineManager.UI.Control {
	/// <summary>
	/// Interaction logic for DashboardInfoTileUserControl.xaml
	/// </summary>
	public partial class DashboardInfoTileUserControl : UserControl {
		#region Properties
		public string Title { get; set; }
		public string Value { get; set; }
		public new SolidColorBrush Background { get; set; }
		public new SolidColorBrush Foreground { get; set; }
		#endregion

		public DashboardInfoTileUserControl() {
			InitializeComponent();
			DataContext = this;

			Title = "Title";
			Value = "0";

			Background = Brushes.White;
			Foreground = Brushes.Black;
		}
	}
}
