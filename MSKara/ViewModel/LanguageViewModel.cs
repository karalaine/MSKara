using MSKara.Model;
using MSKara.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.ViewModel
{
	public class LanguageViewModel : ViewModelBase
	{
		private ResetableObservableCollection<Language> _languages;
        private Language _selectedLanguage;
		public LanguageViewModel()
		{
			Languages = new ResetableObservableCollection<Language>();
		}

		public ResetableObservableCollection<Language> Languages
		{
			get { return _languages; }
			private set
			{
				Set(ref _languages, value);
                SelectedLanguage = value.FirstOrDefault();
            }
        }

        public Language SelectedLanguage {
            get => _selectedLanguage;
            set => Set(ref _selectedLanguage, value);
        }
        public void UpdateToSettings()
        {
            Settings.UsedLanguage = _selectedLanguage.UseToRetrieveLists;
            Settings.DomainToUse = _selectedLanguage.DomainToUse;
            Settings.GenericNewsURLPart = _selectedLanguage.GenericNewsURLPart;
            Settings.UseToRetrieveLists = _selectedLanguage.UseToRetrieveLists;
        }
        public async Task LoadLanguagesAsync()
		{
			await RunTaskAsync(async () =>
			{

                string json = await NetworkUtils.LoadApiToStringAsync("api/?act=listLanguages&", false);
                try
                {
                    var response = JObject.Parse(json);
                    var results = response["responseData"]["supportedLanguages"].Children().ToList();
                    Languages.Reset(results.Select((item => item.ToObject<Language>())));
                    SelectedLanguage = Languages.FirstOrDefault();
                    UpdateToSettings();
                }
                catch (JsonReaderException)
                {

                }
			});
		}
	}
}
