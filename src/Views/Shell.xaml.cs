using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace PlanningPoker.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }

        public static HamburgerMenu HamburgerMenu { get { return Instance.MyHamburgerMenu; } }

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            Loaded += Shell_Loaded;
        }

        private void Shell_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SettingsButton.IsEnabled = false;
        }

        public Shell(INavigationService navigationService)
        {
            Instance = this;
            InitializeComponent();
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }
    }
}

