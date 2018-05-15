using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MSKara.Utils
{
	class NetworkUtils
	{
		static async Task<string> LoadUrlToStringAsync(string url)
		{
			using (HttpClient wc = new HttpClient())
			{
				return await wc.GetStringAsync(url);
			}
		}
		public static async Task<string> LoadApiToStringAsync(string api, bool domainSelected = true)
		{
			string clientId = Settings.UserID;
			string desc = Settings.AppDescription;
			string domain = domainSelected ? Settings.DomainToUse : "high.fi";
			string apikey = Settings.APIKey;
			string
				url = string.Format("http://{0}/api/?{1}&APIKEY={2}&deviceID={3}&appID={4}", domain, api, apikey, clientId, desc);
			return await LoadUrlToStringAsync(url);
		}
	}
}
