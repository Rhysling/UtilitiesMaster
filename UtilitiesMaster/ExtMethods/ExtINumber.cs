using System.Numerics;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace UtilitiesMaster.ExtMethods.ExtINumber;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ExtINumber
{
	public static bool IsNullOrValue<T>(this T? value, T valueToCheck) where T : struct, INumber<T>
	{
		return (value ?? valueToCheck) == valueToCheck;
	}

	public static string N<T>(this T value, int decimals) where T : struct, INumber<T>
	{
		ArgumentOutOfRangeException.ThrowIfNegative(decimals);
		string s = value.ToString() ?? "";

		int d = s.IndexOf('.');
		int len = s.Length;
		string whole = "", fract = "";

		if (s == "")
		{
			whole = "0";
			fract = "";
		}

		else if (d == -1)
		{
			whole = s;
			fract = "";
		}

		else if (d == 0)
		{
			whole = "0";
			fract = (len <=1) ? "" : s[1..];
		}

		else if (d > 0)
		{
			var spl = s.Split('.');
			whole = spl[0];
			fract = spl[1] ?? "";
		}

		if (decimals == 0)
			return whole;

		int fl = fract.Length;

		return fl > decimals
			? whole + "." + fract[..decimals]
			: whole + "." + fract.PadRight(decimals, '0');

	}

}
