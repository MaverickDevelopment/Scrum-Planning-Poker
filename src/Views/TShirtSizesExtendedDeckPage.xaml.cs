using PlanningPoker.ViewModels;
using Windows.UI.Xaml.Controls;

namespace PlanningPoker.Views
{
    public sealed partial class TShirtSizesExtendedDeckPage : Page
    {
        public TShirtSizesExtendedDeckPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public DeckPageViewModel ViewModel => this.DataContext as DeckPageViewModel;

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.Card.DeckName = "T-Shirt Sizes Extended";
            ViewModel.Card.Value = ((Button)sender).Content.ToString();
            ViewModel.GotoCardPage();
        }
    }
}
