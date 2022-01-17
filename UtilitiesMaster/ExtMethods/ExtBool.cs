using System;

namespace UtilitiesMaster.ExtMethods.ExtBool
{
	public static class ExtBool
	{
		public static string AsTrueFalse(this bool val)
		{
				return val ? "true" : "false";
		}

		public static string AsTrueFalse(this bool? val)
		{
			if (!val.HasValue) return "";
			return val.Value ? "true" : "false";
		}
	}
}