using System;
using System.Windows;
using System.Windows.Threading;

namespace AirlineManager.UI.Windows {
	/// <summary>
	/// Interaction logic for LoadingWindow.xaml
	/// </summary>
	public partial class LoadingWindow : Window {
		int m_progress;
		bool m_increase = true;

		public LoadingWindow() {
			InitializeComponent();

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Tick += UpdateProgressBar;
			timer.Tick += UpdateUI;
			timer.Start();
		}

		public void UpdateUI(object sender, EventArgs e) {
			pbProgress.Value = m_progress;
		}

		private void UpdateProgressBar(object sender, EventArgs e) {
			if ((m_progress <= 0 && m_increase == false) ||
				(m_progress >= 100 && m_increase == true)) {
				m_increase = !m_increase;
            }

			if (m_increase) {
				m_progress += 5;
			} else {
				m_progress -= 5;
			}
		}
	}
}
