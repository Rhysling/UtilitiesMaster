using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMaster.Sql
{
	public class SqlBcpWriter
	{
		private string conString;

		public SqlBcpWriter (string conString)
		{
			this.conString = conString;
		}


		public void RunForStringArrayList(List<string[]> list, bool fieldNamesInFirstLine, string tableName, StringArrayListFieldMap map)
		{

			using (StringArrayListDataReader reader = new StringArrayListDataReader(list, fieldNamesInFirstLine, map))
			using (SqlConnection conn = new SqlConnection(conString))
			using (SqlBulkCopy bcp = new SqlBulkCopy(conn))
			{
				var sb = new System.Text.StringBuilder();
				sb.Append("IF EXISTS(SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '");
				sb.Append(tableName);
				sb.Append("') DROP TABLE dbo.");
				sb.Append(tableName);
				sb.Append("; CREATE TABLE dbo." + tableName + " (");
				
				int lastIndex = reader.FieldCount - 1;
				int i;

				for (i = 0; i <= lastIndex; i += 1)
				{
					sb.Append("[" + reader.GetName(i) + "] " + reader.GetDataTypeName(i) + " NULL");
					if (i < lastIndex) sb.Append(", ");
				}

				sb.Append("); ");
				

				conn.Open();

				bcp.DestinationTableName = tableName;
				
				using (SqlCommand createTable = new SqlCommand(sb.ToString(), conn))
				{
					createTable.ExecuteNonQuery();
				}

				bcp.WriteToServer(reader);
				conn.Close();
			}

		}
	}
}
