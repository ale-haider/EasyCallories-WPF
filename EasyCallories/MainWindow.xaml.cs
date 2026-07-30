using Dark.Net;
using EasyCallories.Handlers;
using EasyCallories.ViewModels;
using System.Windows;

namespace EasyCallories
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppStartupHandler.StartupChecks();
            InitializeComponent();
            DarkNet.Instance.SetWindowThemeWpf(this, Theme.Dark);
            this.DataContext = new MainViewModel();
        }
    }
}