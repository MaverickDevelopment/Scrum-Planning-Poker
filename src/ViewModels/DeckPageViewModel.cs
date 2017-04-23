using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using PlanningPoker.Models;

namespace PlanningPoker.ViewModels
{
    public class DeckPageViewModel : ViewModelBase
    {
        public ObservableCollection<CardModel> CardModels { get; }

        public CardModel Card { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeckPageViewModel"/> class.
        /// </summary>
        public DeckPageViewModel()
        {
            CardModels = new ObservableCollection<CardModel>();
            Card = new CardModel { DeckName = "", Value = "", Points = "0" };

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

            LoadCardModels(parameter as string);

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

        private void LoadCardModels(string deckName)
        {
            CardModels.Clear();

            switch (deckName)
            {
                case "Fibonacci":
                    LoadFibonacciCards(deckName);
                    break;
                case "Planning Poker":
                    LoadPlanningPokerCards(deckName);
                    break;
                case "Playing Cards":
                    LoadPlayingCards(deckName);
                    break;
                case "T-Shirt Sizes":
                    LoadTshirtSizeCards(deckName);
                    break;
                case "T-Shirt Sizes Extended":
                    LoadTshirtSizeExtendedCards(deckName);
                    break;
            }
        }

        private void LoadFibonacciCards(string deckName)
        {
            CardModels.Add(new CardModel { DeckName = deckName, Value = "0" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "1" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "2" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "3" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "5" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "8" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "13" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "21" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "34" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "55" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "89" });
        }

        private void LoadPlanningPokerCards(string deckName)
        {
            CardModels.Add(new CardModel { DeckName = deckName, Value = "0" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "1/2" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "1" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "2" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "3" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "5" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "8" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "13" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "20" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "40" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "100" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "Inf" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "?" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "Java" });
        }

        private void LoadPlayingCards(string deckName)
        {
            CardModels.Add(new CardModel { DeckName = deckName, Value = "A" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "2" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "3" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "5" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "8" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "K" });
        }

        private void LoadTshirtSizeCards(string deckName)
        {
            CardModels.Add(new CardModel { DeckName = deckName, Value = "XS" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "S" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "M" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "L" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "XL" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "XXL" });
        }

        private void LoadTshirtSizeExtendedCards(string deckName)
        {
            CardModels.Add(new CardModel { DeckName = deckName, Value = "XS" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "S" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "M" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "M+" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "L" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "L+" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "XL" });
            CardModels.Add(new CardModel { DeckName = deckName, Value = "XL+" });
        }
    }
}

