using System;
using System.Windows;
using System.Windows.Controls;

namespace Eeditor {
	class CodeBox : TextBox {
		protected override void OnInitialized(EventArgs e) {
			base.OnInitialized(e);
			AcceptsReturn = true;
			AcceptsTab = true;
			IsReadOnly = false;
			Padding = new Thickness(3);
		}
	}
}
