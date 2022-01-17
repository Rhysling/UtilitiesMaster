using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UtilitiesMaster.TextClean
{
	// Tags in the format: [TagName]

	public static class TagReplaceText
	{

		public static string Replace(string inputText, string tagName, string replacementText)
		{
			string result = "";

			if (!String.IsNullOrEmpty(inputText))
			{
				tagName = tagName.Replace("[", "");
				tagName = tagName.Replace("]", "");

				var re = new Regex(@"\[" + tagName + "]", RegexOptions.IgnoreCase);
				result = re.Replace(inputText, replacementText);
				re = null;
			}

			return result;
		}

		public static int CountAllTags(string inputText)
		{
			int result = 0;

			if (!String.IsNullOrEmpty(inputText))
			{
				var re = new Regex(@"\[.*?\]", RegexOptions.IgnoreCase);

				result = re.Matches(inputText).Count;
				re = null;
			}

			return result;
		}

	}
}
