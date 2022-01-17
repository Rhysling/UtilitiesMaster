using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.TextClean
{
	public static class Escapes
	{

		public static string EscapeForJs(string str)
		{
			string strExpr;

			System.Text.RegularExpressions.Regex re;

			strExpr = @"\\";
			re = new System.Text.RegularExpressions.Regex(strExpr);
			str = re.Replace(str, @"\\");

			strExpr = @"""";
			re = new System.Text.RegularExpressions.Regex(strExpr);
			str = re.Replace(str, @"\""");

			strExpr = "'";
			re = new System.Text.RegularExpressions.Regex(strExpr);
			str = re.Replace(str, @"\'");

			return str;

		}
			

		public static string EscapeForSql(string str)
		{
			string strExpr;
			System.Text.RegularExpressions.Regex re;

			strExpr = @"'";
			re = new System.Text.RegularExpressions.Regex(strExpr);
			str = re.Replace(str, @"''");

			return str;

		}


		public static string EscapeForSqlLike(string str)
		{
			str = str.Replace(@"[", "[[]");
			str = str.Replace(@"'", "''");
			str = str.Replace(@"%", "[%]");
			str = str.Replace(@"_", "[_]");

			return str;
		}
		

		public static string EscapeForCsv(string str)
		{
			return str.Replace(@"""", @"""""");
		}

	}
}
