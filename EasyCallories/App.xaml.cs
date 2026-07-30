using Dark.Net;
using System.Windows;

namespace EasyCallories
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DarkNet.Instance.SetCurrentProcessTheme(Theme.Auto);
        }
    }

}
