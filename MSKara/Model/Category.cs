using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.Model
{
	public class Category
    {
        public string Title;
        public bool Highlight;
        public DateTime AvailableUntil;
        public int SectionID;
        public int Depth;
        public string HtmlFilename;
        public int ParentSectionID;

        public override string ToString()
        {
            return Title;
        }
    }
}
