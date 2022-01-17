using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.Sql
{
	public static class MakeSql
	{
		public static string InClause(string columnName, string[] values)
		{
			if (string.IsNullOrWhiteSpace(columnName))
			{
				throw new ArgumentException("Column name cannot be empty.");
			}

			if (values != null && values.Length > 0)
			{
				//Remove any null elements
				values = values.Where(a => a != null).Select(b => b).ToArray();

				int i;
				int len = values.Length;
				for (i = 0; i < len; i += 1)
				{
					values[i] = "'" + UtilitiesMaster.TextClean.Escapes.EscapeForSql(values[i]) + "'";
				}
				return "(" + columnName + " IN (" + string.Join(",", values.Select(b => b)) + ")) ";
			}

			return "";
		}

		public static string InClause(string columnName, int[] values)
		{
			if (string.IsNullOrWhiteSpace(columnName))
			{
				throw new ArgumentException("Column name cannot be empty.");
			}

			if (values != null && values.Length > 0)
			{
				return "(" + columnName + " IN (" + string.Join(",", values.Select(b => string.Format("{0:F0}", b))) + ")) ";
			}

			return "";
		}

		public static string JoinClausesWith(string andOr, string[] clauses)
		{
			if (string.IsNullOrWhiteSpace(andOr))
			{
				throw new ArgumentException("Need either AND or OR here.");
			}

			if (clauses == null)
				return "";

			//Remove any null elements
			clauses = clauses.Where(a => a != null).Select(b => b).ToArray();

			if (clauses.Length > 0)
			{
				andOr = " " + andOr.Trim() + " ";
				return "(" + string.Join(andOr, clauses.Where(a => !string.IsNullOrWhiteSpace(a)).Select(b => b.Trim())) + ") ";
			}

			return "";
		}

	}
}
