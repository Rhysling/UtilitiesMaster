using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace UtilitiesMaster.ExtensionMethods
{
	public static class ExtEnum
	{
		public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
		{
			var values = from TEnum e in Enum.GetValues(typeof(TEnum))
									 select new { ID = e, Name = e.ToString() };
			return new SelectList(values, "Id", "Name", enumObj);
		}

		public static List<UtilitiesMaster.Lists.IdNameItem> ToListItems<TEnum>(this TEnum enumObj)
		{
			return (from TEnum e in Enum.GetValues(typeof(TEnum))
							select new UtilitiesMaster.Lists.IdNameItem { Id = Convert.ToInt32(e), Name = e.ToString() }).ToList();
		}

	}
}
