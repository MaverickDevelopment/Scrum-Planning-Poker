using System;
using PlanningPoker.Enums;
using Windows.UI.Xaml;

namespace PlanningPoker.Services.SettingsServices
{
    public interface ISettingsService
    {
        PlanningDeck DefaultPlanningDeck { get; set; }
        bool UseShellBackButton { get; set; }
        bool UseAutoHideSelectedCardButton { get; set; }
        ApplicationTheme AppTheme { get; set; }
        TimeSpan CacheMaxDuration { get; set; }
    }
}
