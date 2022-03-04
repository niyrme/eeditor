using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Eeditor {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
		private NameValueCollection appSettings = ConfigurationManager.AppSettings;

		public App() {
			this.Startup += AppStartup_Locale;
		}

		private void AppStartup_Locale(object sender, StartupEventArgs e) {
			CultureInfo ci;

			try {
				ci = new CultureInfo(appSettings["language"].ToString());
			}
			catch {
				ci = new CultureInfo("en-US");
			}

			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;

			CultureInfo.DefaultThreadCurrentCulture = ci;
			CultureInfo.DefaultThreadCurrentUICulture = ci;
		}
	}
}
