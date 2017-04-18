using PlanningPoker.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Template10.Utils;
using System.Linq;
using System;

namespace PlanningPoker.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // strongly-typed view models enable x:bind
        //public SettingsPageViewModel ViewModel => this.DataContext as SettingsPageViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = Template10.Services.SerializationService.SerializationService
                .Json.Deserialize<int>(e.Parameter?.ToString());
            MyPivot.SelectedIndex = index;
        }
    }
}

