using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.TextClean
{
	public static class FormatOutputText
	{

		public static string LeadStr(string strIn, int ShowLen)
		{
			//'*** Shows the first n letters of a string,
			//'    followed by "..." if more than n
			int ls = strIn.Length;
			if (ls <= ShowLen)
			{
				return strIn;
			}

			return strIn.Substring(0, ShowLen) + "...";
		}
		
		public static string FormatDate(string date)
		{
			DateTime dt;
			if (DateTime.TryParse(date, out dt))
				return FormatDate(dt);
		
			return "-none-";
		}

		public static string FormatDate(DateTime date)
		{
			if (date <= DateTime.Parse("1/1/1902"))
				return "-none-";
			
			return date.ToShortDateString();
		}

		public static string FormatDateTime(string dateTime)
		{
			DateTime dt;
			if (DateTime.TryParse(dateTime, out dt))
				return FormatDateTime(dt);
					
			return "-none-";
		}

		public static string FormatDateTime(DateTime dateTime)
		{
			if (dateTime <= DateTime.Parse("1/1/1902"))
				return "-none-";

			return string.Format("{0:g}", dateTime);
		}


		public static string FormatByteCountDisplay(long byteCount)
		{
			if (byteCount >= 1000000)
			{
				return string.Format("{0:n1}M", byteCount / 1000000);
			}
			else if ((byteCount >= 1000) && (byteCount < 1000000))
			{
				return string.Format("{0:n1}k", byteCount / 1000);
			}

			return string.Format("{0:n1} bytes", byteCount);
		}

	}
}
