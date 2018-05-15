using MSKara.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.ViewModel
{
	class LanguageViewModel : ViewModelBase
	{
		ResetableObservableCollection<Language> _languages;
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
			}
		}
		private async Task LoadLanguagesAsync()
		{
			await RunTaskAsync(async () =>
			{
				var items = await Language.LoadAsync();
				Languages.Reset(items);
			});
		}
	}
}
