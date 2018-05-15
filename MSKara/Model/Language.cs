using MSKara.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.Model
{
	class Language
	{
		string language;
		string country;
		string domainToUse;
		string languageCode;
		string useToRetrieveLists;
		string mostPopularName;
		string latestName;
		string genericNewsURLPart;
		public static Task<List<Language>> LoadAsync()
		{
			return Task.Run(async () =>
			{
				var languages = new List<Language>();
				string json = await NetworkUtils.LoadApiToStringAsync("listLanguages", false);
				try
				{
					var response = JObject.Parse(json);
					var results = response["responseData"]["supportedLanguages"].Children().ToList();

					foreach (var result in results)
					{
						languages.Add(result.ToObject<Language>());
					}
				}
				catch (JsonReaderException)
				{

				}
				return languages;
			});
		}
	}
}
