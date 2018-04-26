using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace AirlineManager.UI.Windows.Popover {
	public partial class PopoverBaseWindow : Window {
		[DllImport("user32.dll")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		private const int WS_SYSMENU = 0x80000;
		private const int GWL_STYLE = -16;

		#region Attributes
		private IntPtr _windowHandle;
		#endregion

		#region Properties
		#endregion

		public PopoverBaseWindow() {
			this.SourceInitialized += Window_SourceInitialized;
		}

		protected void HideAllButtons() {
			if (_windowHandle == null)
				throw new InvalidOperationException("The window has not yet been completely initialized");

			SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_SYSMENU);
		}

		private void Window_SourceInitialized(object sender, EventArgs e) {
			_windowHandle = new WindowInteropHelper(this).Handle;

			HideAllButtons();
		}
	}
}
