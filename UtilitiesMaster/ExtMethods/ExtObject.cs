using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.ExtensionMethods
{
	public static class ExtObject
	{
		public static bool IsDate(this Object obj)
		{
			if (obj is null)
				return false;

			string strDate;
			try
			{

				strDate = obj.ToString() ?? "";
				DateTime dt = DateTime.Parse(strDate);
				if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
				{ 
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}


	}
}
