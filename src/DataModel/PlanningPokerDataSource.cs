using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace PlanningPoker.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class PlanningPokerDataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanningPokerDataItem"/> class.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="subtitle">The subtitle.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="description">The description.</param>
        /// <param name="content">The content.</param>
        public PlanningPokerDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Content = content;
        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Content { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class PlanningPokerDataDeck
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanningPokerDataDeck"/> class.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="subtitle">The subtitle.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="description">The description.</param>
        public PlanningPokerDataDeck(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Cards = new ObservableCollection<PlanningPokerDataItem>();
        }                                                       

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public ObservableCollection<PlanningPokerDataItem> Cards { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// ScrumPlanningPokerDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class ScrumPlanningPokerDataSource
    {
        private static ScrumPlanningPokerDataSource dataSource = new ScrumPlanningPokerDataSource();

        private ObservableCollection<PlanningPokerDataDeck> decks = new ObservableCollection<PlanningPokerDataDeck>();
        public ObservableCollection<PlanningPokerDataDeck> Decks
        {
            get { return this.decks; }
        }

        /// <summary>
        /// Gets the groups asynchronous.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<PlanningPokerDataDeck>> GetDecksAsync()
        {
            await dataSource.GetScrumPlanningPokerDataAsync();

            return dataSource.Decks;
        }

        /// <summary>
        /// Gets the group asynchronous.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public static async Task<PlanningPokerDataDeck> GetDeckAsync(string uniqueId)
        {
            await dataSource.GetScrumPlanningPokerDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = dataSource.Decks.Where((deck) => deck.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        /// <summary>
        /// Gets the card asynchronous.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public static async Task<PlanningPokerDataItem> GetCardAsync(string uniqueId)
        {
            await dataSource.GetScrumPlanningPokerDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = dataSource.Decks.SelectMany(deck => deck.Cards).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        /// <summary>
        /// Gets the scrum planning poker data asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task GetScrumPlanningPokerDataAsync()
        {
            if (this.decks.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/PlanningPokerData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Decks"].GetArray();

            foreach (JsonValue deckValue in jsonArray)
            {
                JsonObject deckObject = deckValue.GetObject();
                PlanningPokerDataDeck deck = new PlanningPokerDataDeck(deckObject["UniqueId"].GetString(),
                                                            deckObject["Title"].GetString(),
                                                            deckObject["Subtitle"].GetString(),
                                                            deckObject["ImagePath"].GetString(),
                                                            deckObject["Description"].GetString());

                foreach (JsonValue itemValue in deckObject["Cards"].GetArray())
                {
                    JsonObject itemObject = itemValue.GetObject();
                    deck.Cards.Add(new PlanningPokerDataItem(itemObject["UniqueId"].GetString(),
                                                       itemObject["Title"].GetString(),
                                                       itemObject["Subtitle"].GetString(),
                                                       itemObject["ImagePath"].GetString(),
                                                       itemObject["Description"].GetString(),
                                                       itemObject["Content"].GetString()));
                }
                this.Decks.Add(deck);
            }
        }
    }
}