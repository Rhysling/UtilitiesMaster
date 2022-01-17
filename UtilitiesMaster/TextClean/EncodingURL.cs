using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.TextClean
{
	public static class EncodingURL
	{

		public static string UrlEncode(string strIn)
		{
			string s = strIn;

			s = s.Replace("%", "%25");
			s = s.Replace("+", "%2B");

			s = s.Replace("!", "%21");
			s = s.Replace(@"""", "%22");
			s = s.Replace("#", "%23");
			s = s.Replace("$", "%24");
			//'("%", "%25") above

			s = s.Replace("&", "%26");
			s = s.Replace("'", "%27");
			s = s.Replace("(", "%28");
			s = s.Replace(")", "%29");

			s = s.Replace("*", "%2A");
			//'s = s.Replace("+", "%2B") above
			s = s.Replace(@",", "%2C");
			s = s.Replace(@"-", "%2D");
			s = s.Replace(@".", "%2E");
			s = s.Replace(@"/", "%2F");

			s = s.Replace(@":", "%3A");
			s = s.Replace(@";", "%3B");
			s = s.Replace(@"<", "%3C");
			s = s.Replace(@"=", "%3D");
			s = s.Replace(@">", "%3E");
			s = s.Replace(@"?", "%3F");
			s = s.Replace(@"@", "%40");

			s = s.Replace(@"[", "%5B");
			s = s.Replace(@"\", "%5C");
			s = s.Replace(@"]", "%5D");
			s = s.Replace(@"^", "%5E");
			s = s.Replace(@"_", "%5F");
			s = s.Replace(@"`", "%60");

			s = s.Replace("~", "%7E");
		
			s = s.Replace(" ", "+");

			return s;
		}

	}
}
