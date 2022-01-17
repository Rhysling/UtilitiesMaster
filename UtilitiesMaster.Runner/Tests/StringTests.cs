using System;
using System.Collections.Generic;
using System.Linq;
using UtilitiesMaster.ExtMethods.ExtString;

namespace UtilitiesMaster.Runner.Tests;

public static class StringTests
{
	public static void TestRelations()
	{
		var lst = new List<string> {
			"abcde",
			"bbb",
			"123456",
			//"1234",
			//"2",
			//"ABCDE",
			"A",
			""
		};

		int iLen = lst.Count;

		for (int i = 0; i < iLen; i++)
		{
			for (int j = 0; j < iLen; j++)
			{
				Console.WriteLine($@"'{lst[i]}' StrictEqual '{lst[j]}' -- {(lst[i].StrictEqual(lst[j]) ? "True" : "False")}");
				Console.WriteLine($@"'{lst[i]}' LooseEqual '{lst[j]}' -- {(lst[i].LooseEqual(lst[j]) ? "True" : "False")}");
				Console.WriteLine($@"'{lst[i]}' IsGreaterThanOrEqual '{lst[j]}' -- {(lst[i].IsGreaterThanOrEqual(lst[j]) ? "True" : "False")}");
				Console.WriteLine($@"'{lst[i]}' IsLessThanOrEqual '{lst[j]}' -- {(lst[i].IsLessThanOrEqual(lst[j]) ? "True" : "False")}");

				Console.WriteLine();
			}
		}
	}

	public static void TestRegEx()
	{
		var vals = new List<string> {
			"abc 2003/12/31",
			"123456/78/90",
			"abc",
			"",
			"123456/78/90/",
			"def 3456/78/90 more"
		};

		string pattern = @"\d{4}/\d{2}/\d{2}/?$";

		Console.WriteLine($"Pattern = {pattern}");

		foreach (string s in vals)
		{
			string x = s.RegExMatchValue(pattern);
			Console.WriteLine($@"{s} -- IsMatch = {(s.RegExIsMatch(pattern) ? "True" : "False")} -- Val = {s.RegExMatchValue(pattern)}");
		}
	}
}

