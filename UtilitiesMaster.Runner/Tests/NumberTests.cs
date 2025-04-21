using System.Text;
using UtilitiesMaster.ExtMethods.ExtINumber;

namespace UtilitiesMaster.Runner.Tests
{
	public static class NumberTests
	{
		public static string NumberFormatter()
		{
			var sb = new StringBuilder();

			double d = 123456789.123456789;
			int i = 123456789;

			sb.AppendLine($"d: val: {d} form0: {d.N(0)}");
			sb.AppendLine($"d: val: {d} form1: {d.N(1)}");
			sb.AppendLine($"d: val: {d} form3: {d.N(3)}");

			sb.AppendLine($"i: val: {i} form0: {i.N(0)}");
			sb.AppendLine($"i: val: {i} form1: {i.N(1)}");
			sb.AppendLine($"i: val: {i} form3: {i.N(3)}");

			return sb.ToString();
		}

	}
}
