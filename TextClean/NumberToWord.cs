using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitiesMaster.ExtMethods.ExtString;

namespace UtilitiesMaster.TextClean
{
	public static class NumberToWord
	{

		public static string SpellNumber(double numberIn, NumberType numType)
		{
			string integerNum = "";
			//string fractionNum = "";
			string integerText = "";
			string fractionText = "";
			string temp;

			string[] place = {
				"",
				"",
				" Thousand ",
				" Million ",
				" Billion ",
				" Trillion ",
				"",
				"",
				"",
				"",
			};

			string myNumber = numberIn.ToString();

			// Position of decimal place 0 if none.  decimalPlace = InStr(MyNumber, ".")
			int decimalIndex = myNumber.IndexOf(".");

			// Split int and fraction parts.
			if (decimalIndex > -1)
			{
				fractionText = GetTens((myNumber.Substring(decimalIndex + 1) + "00").Left(2), false);
				integerNum = myNumber.Left(decimalIndex).Trim();
			}
			else
			{
				integerNum = myNumber;
			}

			int count = 1;

			while (integerNum != "")
			{
				temp = GetHundreds(integerNum.Right(3), (count == 1));
				if (temp != "") integerText = temp + place[count] + integerText;
				if (integerNum.Length > 3)
				{ integerNum = integerNum.Left(integerNum.Length - 3); }
				else
				{ integerNum = ""; }

				count += 1;
			}


			switch(numType)
			{
				case NumberType.Dollars:
					switch (integerText)
					{
						case "": integerText = "No Dollars"; break;
						case "One": integerText = "One Dollar"; break;
						default: integerText = integerText.Trim() + " Dollars"; break;
					}

					switch (fractionText)
					{
						case "": fractionText = " and No Cents"; break;
						case "One": fractionText = " and One Cent"; break;
						default: fractionText = " and " + fractionText + " Cents"; break;
					}

					break;

				default:
					if (integerText == "") { integerText = "Zero"; }
					else { integerText = integerText.Trim(); }

					switch (fractionText)
					{
						case "": fractionText = ""; break;
						case "One": fractionText = " and One Hundredth"; break;
						default: fractionText = " and " + fractionText + " Hundredths"; break;
					}

					break;
			}

			return integerText + fractionText;
		}


		// Converts a number from 100-999 into text.
		public static string GetHundreds(string numberIn, bool isTensGroup)
		{
			string result = "";
			if (String.IsNullOrEmpty(numberIn) || (Int32.Parse(numberIn) == 0)) return "";

			numberIn = ("000" + numberIn).Right(3);

			// Convert the hundreds place.
			if (numberIn.Substring(0, 1) != "0")
			{ result = GetDigit(numberIn.Substring(0, 1)) + " Hundred "; }

			// Convert the tens and ones place.
			if (numberIn.Substring(1, 1) != "0")
			{
				result += GetTens(numberIn.Substring(1, 2), isTensGroup);
			}
			else
			{
				result += GetDigit(numberIn.Substring(2, 1));
			}

			return result;
		}


		// Converts a number from 10 to 99 into text.
		public static string GetTens(string numberIn, bool hasHyphen)
		{
			if (String.IsNullOrEmpty(numberIn)) return "";

			string result = "";
			string onesText = "";

			if (Int32.Parse(numberIn.Substring(0, 1)) == 1)  // Value 10-19 ...
			{
				switch(Int32.Parse(numberIn))
				{
					case 10: result = "Ten"; break;
					case 11: result = "Eleven"; break;
					case 12: result = "Twelve"; break;
					case 13: result = "Thirteen"; break;
					case 14: result = "Fourteen"; break;
					case 15: result = "Fifteen"; break;
					case 16: result = "Sixteen"; break;
					case 17: result = "Seventeen"; break;
					case 18: result = "Eighteen"; break;
					case 19: result = "Nineteen"; break;
					default: result = ""; break;
				}
			}
			else                                            // Value 20-99 ...
			{
			switch(Int32.Parse(numberIn.Substring(0, 1)))
				{
					case 2: result = "Twenty "; break;
					case 3: result = "Thirty "; break;
					case 4: result = "Forty "; break;
					case 5: result = "Fifty "; break;
					case 6: result = "Sixty "; break;
					case 7: result = "Seventy "; break;
					case 8: result = "Eighty "; break;
					case 9: result = "Ninety "; break;
					default: result = ""; break;
				}

				onesText = GetDigit(numberIn.Right(1));

				if (hasHyphen && (result.Length > 0) && (onesText.Length > 0))
				{ result = result.Trim() + "-" + onesText; }
				else
				{	result += onesText; }

			}

			return result.Trim();
		}


		// Converts a number from 1 to 9 into text.
		public static string GetDigit(string numberIn)
		{
			if (String.IsNullOrEmpty(numberIn)) return "";

			string result = "";

			switch(Int32.Parse(numberIn))
			{
				case 1: result = "One"; break;
				case 2: result = "Two"; break;
				case 3: result = "Three"; break;
				case 4: result = "Four"; break;
				case 5: result = "Five"; break;
				case 6: result = "Six"; break;
				case 7: result = "Seven"; break;
				case 8: result = "Eight"; break;
				case 9: result = "Nine"; break;
				default: result = ""; break;
			}

			return result;
		}

	}


	public enum NumberType
	{
		Number = 0,
		Dollars = 1
	}

}
