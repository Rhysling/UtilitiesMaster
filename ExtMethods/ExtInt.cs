using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.ExtensionMethods
{
	public static class ExtInt
	{
		public static string N(this int value, int decimals)
		{
			if (decimals < 0) throw new ArgumentOutOfRangeException("Can't have negative decimal places.");
			return value.ToString("n" + decimals.ToString());
		}
	}
}
