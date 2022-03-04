using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Eeditor.Custom_Types;

/* Custom Commands */
namespace Eeditor {
	public partial class MainWindow {
		// New
		private void CommandNewFile_Executed(object sender, ExecutedRoutedEventArgs e) {
			// TODO add functionality to CommandNewFile_Executed
		}
		private void CommandNewFolder_Executed(object sender, ExecutedRoutedEventArgs e) {
			// TODO add functionality to CommandNewFolder_Executed
		}

		// Open
		private void CommandOpenFile_Executed(object sender, ExecutedRoutedEventArgs e) {
			var dialog = new CommonOpenFileDialog();
			dialog.Title = "Open File";
			dialog.IsFolderPicker = false;
			dialog.AllowNonFileSystemItems = false;

			if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
				OpenFile(dialog.FileName);
			}
		}
		private void CommandOpenFolder_Executed(object sender, ExecutedRoutedEventArgs e) {
			var dialog = new CommonOpenFileDialog();
			dialog.Title = "";
			dialog.IsFolderPicker = true;

			if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
				currentPath = dialog.FileName;
				LoadDirectory();
			}
		}

		// Save
		private void CommandSave_Executed(object sender, ExecutedRoutedEventArgs e) {
			CodeTab codeTab = (CodeTab)this.tabsCode.SelectedItem;
			if (codeTab != null)
				File.WriteAllText(codeTab.filePath, (codeTab.Content as CodeBox).Text);
		}
		private void CommandSaveAll_Executed(object sender, ExecutedRoutedEventArgs e) {
			foreach (CodeTab codeTab in this.tabsCode.Items) {
				if (codeTab == null) break;
				File.WriteAllText(codeTab.filePath, (codeTab.Content as TextBox).Text);
			}
		}

		// Exit
		private void CommandExit_Executed(object sender, ExecutedRoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		// Tabs
		private void CommandCloseTab_Executed(object sender, ExecutedRoutedEventArgs e) {
			this.tabsCode.Items.Remove(this.tabsCode.SelectedItem);
		}
	}
}
