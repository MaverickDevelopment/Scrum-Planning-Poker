using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using PlanningPoker.Services.SettingsServices;
using Windows.ApplicationModel.Activation;

namespace PlanningPoker
{
    sealed partial class App : Template10.Common.BootStrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region App settings

            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
        }
        
        /// <summary>
        /// Raises the <see cref="E:InitializeAsync" /> event. Runs even if restored from state.
        /// </summary>
        /// <param name="args">The <see cref="IActivatedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // content may already be shell when resuming
            if ((Window.Current.Content as Views.Shell) == null)
            {
                // setup hamburger shell
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                Window.Current.Content = new Views.Shell(nav);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [start asynchronous]. Runs only when not restored from state.
        /// </summary>
        /// <param name="startKind">The start kind.</param>
        /// <param name="args">The <see cref="IActivatedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            //TODO: pass in the configured default deck
            //NavigationService.Navigate(typeof(Views.FibonacciDeckPage));

            var defaultDeck = SettingsService.Instance.DefaultPlanningDeck;
            switch (defaultDeck)
            {
                case Enums.PlanningDeck.Fibonacci:
                    NavigationService.Navigate(typeof(Views.FibonacciDeckPage));
                    break;
                case Enums.PlanningDeck.PlanningPoker:
                    NavigationService.Navigate(typeof(Views.PlanningPokerDeckPage));
                    break;
                case Enums.PlanningDeck.PlayingCards:
                    NavigationService.Navigate(typeof(Views.PlayingCardsDeckPage));
                    break;
                case Enums.PlanningDeck.TShirtSizes:
                    NavigationService.Navigate(typeof(Views.TShirtSizesDeckPage));
                    break;
                case Enums.PlanningDeck.TShirtSizesExtended:
                    NavigationService.Navigate(typeof(Views.TShirtSizesExtendedDeckPage));
                    break;
            }
            
            return Task.CompletedTask;
        }
    }
}

