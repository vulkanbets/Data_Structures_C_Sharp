using System.Windows;

namespace WpfAppTreeView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create ViewModel
            WpfAppTreeViewModel VM = new WpfAppTreeViewModel();

            // Show View Window through ViewModel
            VM.showView();
        }
    }
}
