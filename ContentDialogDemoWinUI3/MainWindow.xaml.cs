using ContentDialogDemoUWP;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Foundation.Metadata;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContentDialogDemoWinUI3 {
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window {

        public MainWindow() {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            var confirmDialog = new ConfirmContentDialog();

            // Use this code to associate the dialog to the appropriate AppWindow by setting
            // the dialog's XamlRoot to the same XamlRoot as an element that is already present in the AppWindow.
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8)) {
                confirmDialog.XamlRoot = this.Content.XamlRoot;
            }

            var result = await confirmDialog.ShowAsync();

            (sender as Button).Content = result.ToString();
        }
    }
}
