using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanningPoker.Enums;
using Template10.Mvvm;
using Windows.UI.Xaml;

namespace PlanningPoker.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();

        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPartViewModel" /> class.
        /// </summary>
        public SettingsPartViewModel()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                _settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        /// <summary>
        /// Gets or sets the default planning deck.
        /// </summary>
        /// <value>
        /// The default planning deck.
        /// </value>
        public PlanningDeck DefaultPlanningDeck
        {
            get { return _settings.DefaultPlanningDeck; }
            set
            {
                _settings.DefaultPlanningDeck = value;
                base.RaisePropertyChanged();
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
            get { return _settings.UseShellBackButton; }
            set
            {
                _settings.UseShellBackButton = value;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use light theme button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use light theme button]; otherwise, <c>false</c>.
        /// </value>
        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
            set
            {
                _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use automatic hide selected card button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use automatic hide selected card button]; otherwise, <c>false</c>.
        /// </value>
        public bool UseAutoHideSelectedCardButton
        {
            get { return _settings.UseAutoHideSelectedCardButton; }
            set
            {
                _settings.UseAutoHideSelectedCardButton = value;
                base.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets the available planning decks.
        /// </summary>
        /// <value>
        /// The decks.
        /// </value>
        public List<PlanningDeck> Decks { get; } = Enum.GetValues(typeof(PlanningDeck)).Cast<PlanningDeck>().ToList<PlanningDeck>();

    }

    public class AboutPartViewModel : ViewModelBase
    {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("ms-windows-store://review/?ProductId=9WZDNCRFK20H");

        /// <summary>
        /// Reviews the this application.
        /// </summary>
        public async void ReviewThisApp()
        {
            await Windows.System.Launcher.LaunchUriAsync(RateMe);
        }

        /// <summary>
        /// Supports the and feedback.
        /// </summary>
        public void SupportAndFeedback()
        {
            string emailTo = "maverickapps@outlook.com";
            string subject = $"Feedback and Support for '{DisplayName}'";
            StringBuilder body = new StringBuilder();
            body.AppendLine().AppendLine();
            body.AppendLine($"{DisplayName} v{Version}").AppendLine().AppendLine();

            ComposeEmail(subject, body.ToString(), emailTo);
        }

        /// <summary>
        /// Shares the this application.
        /// </summary>
        public void ShareThisApp()
        {                        
            Uri link = new Uri("https://www.microsoft.com/store/apps/9WZDNCRFK20H/");
            string subject = $"Checkout '{DisplayName}' for Windows 10";
            StringBuilder body = new StringBuilder();
            body.AppendLine(link.ToString()).AppendLine();

            ComposeEmail(subject, body.ToString());
        }

        /// <summary>
        /// Composes the email.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        private async void ComposeEmail(string subject, string body)
        {
            ComposeEmail(subject, body, string.Empty);
        }

        /// <summary>
        /// Composes the email.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="to">To.</param>
        private async void ComposeEmail(string subject, string body, string to)
        {
            //REFERENCE: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/mt269391.aspx
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();

            if (!string.IsNullOrWhiteSpace(to))
            {
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(to);
                emailMessage.To.Add(emailRecipient);
            }

            emailMessage.Subject = subject;
            emailMessage.Body = body;

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
    }
}

