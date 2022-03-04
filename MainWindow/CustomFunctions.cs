using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Eeditor.Custom_Types;

namespace Eeditor {
	public partial class MainWindow {
		// Functions
		private void LoadDirectory() {
			this.stackFiles.Items.Clear();

			var directories = Directory.GetDirectories(currentPath, "*", SearchOption.TopDirectoryOnly);
			var files = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);

			foreach (var directory in directories) {
				string dirName = directory.Substring(currentPath.Length).StartsWith(@"\") ? directory.Substring(currentPath.Length + 1) : directory.Substring(currentPath.Length);
				if (!Convert.ToBoolean(appSettings["showDotFolders"])) {
					if (dirName.StartsWith(".")) continue;
				}

				this.stackFiles.Items.Add(
					new ListBoxItem() {
						FontSize = 14,
						FontWeight = FontWeights.Bold,
						Content = $"\U0001F4C1 {dirName}"
					}
				);
			}
			foreach (var file in files) {
				string fileName = file.Substring(currentPath.Length).StartsWith(@"\") ? file.Substring(currentPath.Length + 1) : file.Substring(currentPath.Length);
				if (!Convert.ToBoolean(appSettings["showDotFiles"])) {
					if (file.StartsWith(".")) continue;
				}

				this.stackFiles.Items.Add(
					new ListBoxItem() {
						FontSize = 14,
						Content = $"\U0001F5CE {fileName}",
					}
				);
				// TODO: add double-click event to files list
				// this.stackFiles.AddHandler(MouseDoubleClickEvent, StackFilesDoubleClick);
			}
		}
		private void OpenFile(string path) {
			string fileName = path.Remove(0, path.LastIndexOf('\\') + 1);

			CodeTab codeTab = new CodeTab();
			codeTab.filePath = path;
			codeTab.fileName = fileName;
			codeTab.Header = fileName;
			codeTab.IsSelected = true;
			codeTab.Content = new CodeBox() {
				Text = File.ReadAllText(path)
			};

			codeTab.AddTo(this.tabsCode);
		}
	}
}
