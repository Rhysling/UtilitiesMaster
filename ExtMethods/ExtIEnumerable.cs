using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.ExtensionMethods.ExtIEnumerable
{
	public static class ExtIEnumerable
	{
		public static bool IsEmpty<T>(this IEnumerable<T> source)
		{
			return !source.Any();
		}

	}
}
