using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.ExtensionMethods.ExtDecimal
{
	public static class ExtDecimal
	{
		public static bool IsNullOrEquals(this decimal? value, decimal valueToCheck)
		{
			return (value ?? valueToCheck) == valueToCheck;
		}
	}
}
