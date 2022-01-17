using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesMaster.Sql
{
	public class StringArrayListFieldMap
	{
		private List<SqlFieldInfo> map;

		public StringArrayListFieldMap(List<SqlFieldInfo> map)
		{
			this.map = map;
		}

		public List<SqlFieldInfo> GetMap()
		{
			return map;
		}
	}


	public class SqlFieldInfo
	{
		public string Name { get; set; }
		public SqlFieldType FieldType { get; set; }
	}

	public enum SqlFieldType
	{
		_default = 0,
		@int = 1,
		@float = 2,
		@date = 3,
		@datetime = 4,
		varchar50 = 5,
		varchar100 = 6,
		varchar2047 = 8
	}

}
