using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.Model
{
	public enum PaywallType
	{
		Free,
		StrictPaywall,
		MonthlyLimit,
		Partial
	}
    public class NewsSource
	{
        public string SourceName;
        public int SourceID;
        public PaywallType Paywall;
	}
}
