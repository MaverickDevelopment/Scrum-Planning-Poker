using PlanningPoker.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace PlanningPoker.Views
{
    public sealed partial class CardPage : Page
    {
        public CardPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;

            // there were added.
            //VisualStateManager.GoToState(this, "FlipCardFront", true);
            //VisualStateManager.GoToState(this, "FlipCardBack", true);
        }

        private void Back_rectangle_tap(object sender, TappedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "FlipCardBack", true);
        }

        private void Front_rectangle_tap(object sender, TappedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "FlipCardFront", true);
        }

        private void backGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "FlipCardBack", true);
        }

        private void frontGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "FlipCardFront", true);
        }
    }
}

