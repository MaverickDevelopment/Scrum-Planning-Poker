using System;
using PlanningPoker.Enums;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;

namespace PlanningPoker.Services.SettingsServices
{
    public partial class SettingsService : ISettingsService
    {
        public static SettingsService Instance { get; }
        Template10.Services.SettingsService.ISettingsHelper _helper;

        /// <summary>
        /// Initializes the <see cref="SettingsService"/> class.
        /// </summary>
        static SettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="SettingsService"/> class from being created.
        /// </summary>
        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        /// <summary>
        /// Gets or sets the default planning deck.
        /// </summary>
        /// <value>
        /// The default planning deck.
        /// </value>
        public PlanningDeck DefaultPlanningDeck
        {   
            get
            {
                var defaultPlanningDeck = PlanningDeck.Fibonacci;
                var value = _helper.Read<string>(nameof(DefaultPlanningDeck), defaultPlanningDeck.ToString());
                return Enum.TryParse<PlanningDeck>(value, out defaultPlanningDeck) ? defaultPlanningDeck : PlanningDeck.Fibonacci;
            }
            set
            {
                _helper.Write(nameof(DefaultPlanningDeck), value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use shell back button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use shell back button]; otherwise, <c>false</c>.
        /// </value>
        public bool UseShellBackButton
        {
            get { return _helper.Read<bool>(nameof(UseShellBackButton), true); }
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                    BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use automatic hide selected card button].
        /// </summary>
        /// <value>
        /// <c>true</c> if [use automatic hide selected card button]; otherwise, <c>false</c>.
        /// </value>
        public bool UseAutoHideSelectedCardButton
        {
            get { return _helper.Read<bool>(nameof(UseAutoHideSelectedCardButton), true); }
            set
            {
                _helper.Write(nameof(UseAutoHideSelectedCardButton), value);
                //ApplyUseAutoHideSelectedCardButton(value);
                //BootStrapper.Current. = value;
            }
        }

        /// <summary>
        /// Gets or sets the application theme.
        /// </summary>
        /// <value>
        /// The application theme.
        /// </value>
        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Light;
                var value = _helper.Read<string>(nameof(AppTheme), theme.ToString());
                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                BootStrapper.Current.NavigationService.Frame.RequestedTheme = value.ToElementTheme();
            }
        }

        /// <summary>
        /// Gets or sets the maximum duration of the cache.
        /// </summary>
        /// <value>
        /// The maximum duration of the cache.
        /// </value>
        public TimeSpan CacheMaxDuration
        {
            get { return _helper.Read<TimeSpan>(nameof(CacheMaxDuration), TimeSpan.FromDays(2)); }
            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }
    }
}

