using MSKara.Model;
using MSKara.Utils;
using MSKara.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara2017.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ResetableObservableCollection<Category> _categories;
        private Category _selectedCategory;
        ResetableObservableCollection<NewsItem> _newsItems;
        public ResetableObservableCollection<NewsItem> NewsItems
        {
            get { return _newsItems; }
            private set
            {
                Set(ref _newsItems, value);
            }
        }


        public MainViewModel()
        {
            Categories = new ResetableObservableCollection<Category>();
            NewsItems = new ResetableObservableCollection<NewsItem>();
        }
 
        public ResetableObservableCollection<Category> Categories
        {
            get { return _categories; }
            private set
            {
                Set(ref _categories, value);
                SelectedCategory = value.FirstOrDefault();
            }
        }
        internal Category SelectedCategory { get => _selectedCategory; set => Set(ref _selectedCategory, value); }
        public async Task LoadCategoriesAsync()
        {
            await RunTaskAsync(async () =>
            {

                string json = await NetworkUtils.LoadApiToStringAsync(string.Format("api/?act=listCategories&usedLanguage={0}&", Settings.UseToRetrieveLists), true);
                try
                {
                    var response = JObject.Parse(json);
                    var results = response["responseData"]["categories"].Children().ToList();
                    Categories.Reset(results.Select((item => item.ToObject<Category>())));
                    SelectedCategory = Categories.FirstOrDefault();
                }
                catch (JsonReaderException)
                {

                }
            });
        }

        private string GenerateNewsAPICall(Category category, int page)
        {
            string url = Settings.GenericNewsURLPart + "/";
            if (category != null)
                url += category.HtmlFilename + "/";
            if (page != -1)
                url += page.ToString() + "/";

            return url + "json-private?";
        }
        public async Task LoadNewsAsync(Category category = null, int page = -1)
        {
            await RunTaskAsync(async () =>
            {

                string json = await NetworkUtils.LoadApiToStringAsync(GenerateNewsAPICall(category, page), true);
                try
                {
                    var response = JObject.Parse(json);
                    var feed = response["responseData"]["feed"].ToObject<Feed>();
                    NewsItems.Reset(feed.Entries);
                }
                catch (JsonReaderException)
                {

                }
            });
        }

    }
}
