using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UtilitiesMaster.TextClean
{
	public static class ValidateText
	{

		public static bool ValidateDate(string dateIn)
		{

			if (DateTime.TryParse(dateIn, out DateTime d))
			{
				return (d > DateTime.Parse("1/1/1950") && d < DateTime.Parse("1/1/2100"));
			}

			return false;
		}


		public static bool ValidateEmail(string email)
		{
			//'Dim strExpr As String = "^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"
			string strExpr = @"^[A-Za-z0-9][A-Za-z0-9.!#$%&'*+\-/=?^_`{|}~]*@[A-Za-z0-9.-]+\.[A-Za-z]{2,9}$";
			return Regex.Match(email, strExpr, RegexOptions.IgnoreCase).Success;
		}

		public static bool ValidatePasswordComplexity(string pw, int minLength,
			int maxLength, bool hasLetter, bool hasDigit, bool hasSpecialChar)
		{
			string p = pw.Trim();

			if (p.Length > maxLength || p.Length < minLength)
			{
				return false;
			}

			bool b = Regex.Match(p, @"[a-zA-Z]+").Success;
			b = b && Regex.Match(p, @"\d+").Success;
			b = b && Regex.Match(p, @"[^\w]+").Success;

			return b;
		}
	}
}
