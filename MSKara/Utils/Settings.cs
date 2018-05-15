using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.Utils
{
	class Settings
	{
		static Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
		Settings()
		{
			Windows.Storage.ApplicationData.Current.DataChanged += Current_DataChanged;
		}

		private void Current_DataChanged(Windows.Storage.ApplicationData sender, object args)
		{
			throw new NotImplementedException();
		}

		public static string UsedLanguage
		{
			get
			{
				return roamingSettings.Values["usedLanguage"] as string;
			}
			set
			{
				roamingSettings.Values["usedLanguage"] = value;
			}
		}
		public static string DomainToUse
		{
			get
			{
				return roamingSettings.Values["domainToUse"] as string;
			}
			set
			{
				roamingSettings.Values["domainToUse"] = value;
			}
		}
		public static string UserID
		{
			get
			{
				var id = roamingSettings.Values["userId"];
				if(id == null)
				{
					id = Guid.NewGuid().ToString();
					roamingSettings.Values["userId"] = id;
				}
				return id as string;
			}
		}

		public static string APIKey
		{
			get { return "5fe4def6522ac51f0965da88e481e39e"; }
		}
		public static string AppDescription
		{
			get { return "Rust Uutiskeräin 0.1"; }
		}
	}
}
