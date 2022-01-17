using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.TextClean
{
	public static class WrapLongText
	{
		public static string Go(string longTextIn, int width)
		{
			int iLast = longTextIn.Length - 1;

			int iStart, iTarget, iEnd, iNextHr;

			var sb = new System.Text.StringBuilder();
			iStart = 0;

			do
			{

				iTarget = iStart + width;

				if (iTarget >= iLast)
				{
					sb.Append(longTextIn.Substring(iStart, iLast - iStart + 1));
					return sb.ToString();
				}

				iNextHr = longTextIn.IndexOf("\r\n", iStart);

				if (iNextHr > iTarget || iNextHr < 0)
				{
					//'Find next previous space
					for (iEnd = iTarget; iEnd > iStart; iEnd -= 1)
					{
						if (longTextIn[iEnd] == " "[0])
						{
							break;
						}
					} // iEnd

					// Check for no spaces
					if (iEnd == iStart)
					{
						iEnd = iStart + width;
						sb.Append(longTextIn.Substring(iStart, iEnd - iStart) + "\r\n");
						iStart = iEnd;
					}
					else
					{
						sb.Append(longTextIn.Substring(iStart, iEnd - iStart) + "\r\n");
						iStart = iEnd + 1;
					}
					
				}
				else
				{
					//'Next Hr before Target
					sb.Append(longTextIn.Substring(iStart, iNextHr - iStart + 1));
					iStart = iNextHr + 1;
				}
			} while (true);
		}
	}
}
