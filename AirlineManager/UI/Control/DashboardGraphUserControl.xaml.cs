using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace AirlineManager.UI.Control {
	/// <summary>
	/// Interaction logic for DashboardUserControl.xaml
	/// </summary>
	public partial class DashboardGraphUserControl : UserControl {
		public string DiagrammTitle {get; set;}
		public SeriesCollection Collection { get; set; }
		public Func<double, string> FormatterXAxis { get; set; }
		public Func<double, string> FormatterYAxis { get; set; }
		public string TitleXAxis { get; set; }
		public string TitleYAxis { get; set; }
		public bool ShowLegend { get; set; }

		public DashboardGraphUserControl() {
			InitializeComponent();
			DataContext = this;

			FormatterXAxis = value => value.ToString();
			FormatterYAxis = value => value.ToString();

			ShowLegend = true;
		}
	}
}
