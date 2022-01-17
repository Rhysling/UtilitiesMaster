using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.ExtensionMethods
{
	public static class ExtDoubleNull
	{
		public static bool IsNullOrValue(this double? value, double valueToCheck)
		{
			return (value ?? valueToCheck) == valueToCheck;
		}
	}
}
