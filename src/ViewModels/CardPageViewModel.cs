using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningPoker.Models;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace PlanningPoker.ViewModels
{
    public class CardPageViewModel : ViewModelBase
    {
        //private string deckName = string.Empty;
        //public string DeckName
        //{
        //    get { return deckName; }
        //    set { Set(ref deckName, value); }
        //}

        //private string cardValue = "0";
        //public string CardValue
        //{
        //    get { return cardValue; }
        //    set { Set(ref cardValue, value); }
        //}

        //private string previousCardValue = string.Empty;
        //public string PreviousCardValue
        //{
        //    get { return previousCardValue; }
        //    set { Set(ref previousCardValue, value); }
        //}

        private CardModel _Card;
        public CardModel Card
        {
            get { return _Card; }
            set { Set(ref _Card, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardPageViewModel"/> class.
        /// </summary>
        public CardPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                //this.CardValue = "0";
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
                //if (state.ContainsKey(nameof(CardValue)))
                //{
                //    CardValue = state[nameof(CardValue)]?.ToString();
                //    PreviousCardValue = state[nameof(PreviousCardValue)]?.ToString();
                //}

                // clear any cache
                state.Clear();
            }
            else
            {
                //PreviousCardValue = CardValue;

                // use navigation parameter
                //CardValue = parameter?.ToString();
                Card = parameter as CardModel;
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
                //state[nameof(CardValue)] = CardValue;
                //state[nameof(PreviousCardValue)] = PreviousCardValue;
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
    }
}

