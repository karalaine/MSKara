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
    public class Language
    {
        [JsonProperty("language")]
        public string LanguageName { get; set; }
        public string Country { get; set; }
        public string DomainToUse { get; set; }
        public string LanguageCode { get; set; }
        public string UseToRetrieveLists { get; set; }
        public string MostPopularName { get; set; }
        public string LatestName { get; set; }
        public string GenericNewsURLPart { get; set; }
        public override string ToString()
        {
            return string.Format("{0} - {1}",Country, LanguageName);
        }
    }
}
