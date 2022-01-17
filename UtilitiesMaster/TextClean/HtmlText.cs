using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UtilitiesMaster.TextClean
{
	public static class HtmlText
	{

		public static string StripHtmlTags(string inputText, string[] tagNames)
		{
			string strExpr = "";

			foreach (string s in tagNames)
			{
				strExpr += @"(</?" + s + @"[^>]*>)|";
			}

			strExpr = strExpr.Substring(0, strExpr.Length - 1);

			var re = new Regex(strExpr, RegexOptions.IgnoreCase);
			var result = re.Replace(inputText, "");
			re = null;

			return result;
		}

		public static string StripAllHtmlTags(string inputText)
		{
			string result = "";

			if (!String.IsNullOrEmpty(inputText))
			{
				var re = new Regex(@"<(.|\n)+?>", RegexOptions.IgnoreCase);

				//'Replace all HTML tag matches with the empty string
				result = re.Replace(inputText, "");
				re = null;

				//'Replace all < and > with &lt; and &gt;
				result = Regex.Replace(result, "<", "&lt;");
				result = Regex.Replace(result, ">", "&gt;");
			}

			return result;
		}

	}
}
