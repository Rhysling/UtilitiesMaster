using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.TextClean
{
	public static class PluralSingular
	{
		// Convert the input word from plural to singular
		public static string PluralToSingular(string plural) 
		{
			if (plural.Length < 2)
			{
				return plural;
			}

			//'Convert to lowercase for easier comparison
			string lower = plural.ToLower();
			string res;

			//'Rule out a few exceptions
			if (lower == "feet")
			{
				res = "Foot";
			}
			else if (lower == "geese")
			{
				res = "Goose";
			}
			else if (lower == "men")
			{
				res = "Man";
			}
			else if (lower == "women")
			{
				res = "Woman";
			}
			else if (lower == "criteria")
			{
				res = "Criterion";
			}
			else if (lower == "data")
			{
				res = "Datum";
			}
			//else if (lower == "xxxx") // *** Next exception here ***
			//{ 
			//	res = "Xxxx";
			//}

			// Plural uses "ies" if word ends with "y" preceeded by a non-vowel
			else if (lower.EndsWith("ies") && ("aeiou".IndexOf(lower.Substring(lower.Length - 4, 1)) < 0))
			{
				res = plural.Substring(0, plural.Length - 3) + "y";
			}
				

			// Ends with "es"
			else if (lower.EndsWith("xes"))
			{
				res = plural.Substring(0, plural.Length - 2);
			}

			// Ends with "s"
			else if (lower.EndsWith("s"))
			{
				res = plural.Substring(0, plural.Length - 1);
			}
			
			else // Return the word unchanged
			{
				res = plural;
			}

			// Result must preserve the original word's capitalization
			if (plural == lower)
			{
				return res.ToLower();
			}
			else if (plural == plural.ToUpper()) 
			{
				return res.ToUpper();
			}

			return res;

		}

	}
}
