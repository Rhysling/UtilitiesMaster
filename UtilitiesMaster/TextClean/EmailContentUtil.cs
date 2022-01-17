using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtilitiesMaster.TextClean
{
	public class EmailContentUtil
	{
		private Regex reEmailLoose = new Regex(@"[^\s\[\(<]+@\S+\.[^\s\]\)>]+");
		//private Regex reRemoveChars = new Regex(@"[<>\(\)\[\]]");

		public string ExtractAddresses(string text)
		{
			var ms = reEmailLoose.Matches(text);

			var nl = new List<string>();
			foreach (Match m in ms)
				nl.Add(m.Value);

			//reRemoveChars.Replace(a, "")
			nl = nl.Select(a => a.Replace("mailto:", "").Replace(":", "").Trim('.')).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();

			return String.Join(",", nl);
		}


		public string ExtractTrackingCode(string imgName, string text)
		{
			imgName = imgName.Replace(".", @"\.");
			var re = new Regex($@"{imgName}\?k=(\w+)""");

			var m = re.Match(text);
			if (!m.Success) return "";

			return m.Groups[1].Value;
		}
	}
}
