using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Eeditor.Custom_Types {
	class CodeTab : TabItem {

		public string filePath;
		public string fileName;

		protected override void OnInitialized(EventArgs e) {
			base.OnInitialized(e);
		}

		public void AddTo(TabControl tabControl) {
			tabControl.Items.Add(this);
		}
	}
}
