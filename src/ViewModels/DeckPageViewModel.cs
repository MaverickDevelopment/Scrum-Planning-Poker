using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using PlanningPoker.Models;

namespace PlanningPoker.ViewModels
{
    public class DeckPageViewModel : ViewModelBase
    {
        //private string activeDeckName = string.Empty;
        //public string ActiveDeckName
        //{
        //    get { return activeDeckName; }
        //    set { Set(ref activeDeckName, value); }
        //}

        //private string _Value = string.Empty;
        //public string Value
        //{
        //    get { return _Value; }
        //    set { Set(ref _Value, value); }
        //}

        private CardModel _Card;
        public CardModel Card
        {
            get { return _Card; }
            set { Set(ref _Card, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeckPageViewModel"/> class.
        /// </summary>
        public DeckPageViewModel()
        {
            _Card = new CardModel() { DeckName = "", Value = "", Points = "0" };

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                //Value = "Designtime value";
                //DeckName = "Sample Deck";
                return;
            }
        }

        /// <summary>
        /// Called when [navigated to].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="state">The state.</param>
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                //if (state.ContainsKey(nameof(Value)))
                //{
                //    Value = state[nameof(Value)]?.ToString();
                //    ActiveDeckName = state[nameof(ActiveDeckName)]?.ToString();
                //}

                // clear any cache
                state.Clear();
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [navigated from asynchronous].
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="suspending">if set to <c>true</c> [suspending].</param>
        /// <returns></returns>
        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                //state[nameof(Value)] = Value;
                //state[nameof(ActiveDeckName)] = ActiveDeckName;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Raises the <see cref="E:NavigatingFrom" /> event.
        /// </summary>
        /// <param name="args">The <see cref="Template10.Services.NavigationService.NavigatingEventArgs" /> instance containing the event data.</param>
        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            return Task.CompletedTask;
        }

        /// <summary>
        /// Navigate to the Card page.
        /// </summary>
        public void GotoCardPage()
        {
            this.NavigationService.Navigate(typeof(Views.CardPage), this.Card);
        }
    }
}

