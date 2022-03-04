using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Eeditor {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		private NameValueCollection appSettings = ConfigurationManager.AppSettings;
		private string currentPath;

		public MainWindow() {
			InitializeComponent();

			int fontSize;
			try {
				fontSize = Convert.ToInt32(appSettings["fontSize"]);
			}
			catch (Exception) {
				fontSize = 14;
			}

			this.menuVersion.InputGestureText = $"{Assembly.GetExecutingAssembly().GetName().Version}";
			this.FontFamily = new FontFamily($"{Convert.ToString(appSettings["fontFamily"])}, monospace");
			this.FontSize = Math.Abs(fontSize);
		}
	}
}
