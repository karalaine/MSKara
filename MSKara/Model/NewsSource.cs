using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKara.Model
{
	enum PaywallType
	{
		Free,
		StrictPaywall,
		MonthlyLimit,
		Partial
	}
	class NewsSource
	{
		string sourceName;
		int sourceID;
		PaywallType paywall;
	}
}
