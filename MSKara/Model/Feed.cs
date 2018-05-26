
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.Model
{
    public class Feed
	{
        public string Title;
        public string Link;
        public string Author;
        public string Description;
        public string Type;
		public List<NewsItem> Entries;
	}
}
