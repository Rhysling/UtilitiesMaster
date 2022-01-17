using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;
using UtilitiesMaster.TypeConversionMapping;

namespace UtilitiesMaster.Sql
{
	public class StringArrayListDataReader : IDataReader
	{
		private class PropInfo
		{
			public string Name { get; set; }
			public Type PropType { get; set; }
			public string SqlTypeName { get; set; }
		}

		private List<string[]> fullList;
		private List<PropInfo> properties;
		int fieldCount;
		int firstRow;
		int rowCount;
		int iCurrent;

		public StringArrayListDataReader(IEnumerable<string[]> list, bool fieldNamesInFirstLine, StringArrayListFieldMap map)
		{
			fullList = list.ToList();
			fieldCount = fullList[0].Length;
			firstRow = fieldNamesInFirstLine ? 1 : 0;
			rowCount = fullList.Count;
			this.Reset();

			if (fieldNamesInFirstLine)
			{
				properties = fullList[0].Select(a => new PropInfo { Name = a, PropType = typeof(string) }).ToList();
			}
			else
			{
				properties = Enumerable.Range(0, fieldCount).Select(i => new PropInfo { Name = "Column " + i.ToString(), PropType = typeof(string) }).ToList();
			}

			if (map != null)
			{
				var sm = map.GetMap();
				if (sm.Count != fieldCount) throw new ArgumentOutOfRangeException("StringArrayListFieldMap not same length as field count.");

				properties = properties.Zip(sm, (p, s) => new PropInfo {
					Name = String.IsNullOrWhiteSpace(s.Name) ? p.Name : s.Name,
					PropType = p.PropType,
					SqlTypeName = SqlTypeMap.SqlTypeFromEnum(s.FieldType)
				}).ToList();
			}

			
		}

		#region IDataReader Members

		public void Close()
		{
			// Nothing to do here.
		}

		public void Reset()
		{
			iCurrent = firstRow - 1;
		}

		public int Depth
		{
			get { return 0; }
		}

		public DataTable GetSchemaTable()
		{
			throw new NotImplementedException();
		}

		public bool IsClosed
		{
			get { return false; }
		}

		public bool NextResult()
		{
			throw new NotImplementedException();
		}

		public bool Read()
		{
			iCurrent += 1;
			return (iCurrent < rowCount);
		}

		public int RecordsAffected
		{
			get { return rowCount; }
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Close();
		}

		#endregion

		#region IDataRecord Members

		public int FieldCount
		{
			get { return properties.Count; }
		}

		public bool GetBoolean(int i)
		{
			throw new NotImplementedException();
		}

		public byte GetByte(int i)
		{
			throw new NotImplementedException();
		}

		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			throw new NotImplementedException();
		}

		public char GetChar(int i)
		{
			throw new NotImplementedException();
		}

		public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			throw new NotImplementedException();
		}

		public IDataReader GetData(int i)
		{
			throw new NotImplementedException();
		}

		public string GetDataTypeName(int i)
		{
			return properties[i].SqlTypeName ?? "varchar(2047)";
		}

		public DateTime GetDateTime(int i)
		{
			throw new NotImplementedException();
		}

		public decimal GetDecimal(int i)
		{
			throw new NotImplementedException();
		}

		public double GetDouble(int i)
		{
			throw new NotImplementedException();
		}

		public Type GetFieldType(int i)
		{
			return properties[i].PropType;
		}

		public float GetFloat(int i)
		{
			throw new NotImplementedException();
		}

		public Guid GetGuid(int i)
		{
			throw new NotImplementedException();
		}

		public short GetInt16(int i)
		{
			throw new NotImplementedException();
		}

		public int GetInt32(int i)
		{
			throw new NotImplementedException();
		}

		public long GetInt64(int i)
		{
			throw new NotImplementedException();
		}

		public string GetName(int i)
		{
			return properties[i].Name;
		}

		public int GetOrdinal(string name)
		{
			throw new NotImplementedException();
		}

		public string GetString(int i)
		{
			throw new NotImplementedException();
		}

		public object GetValue(int i)
		{
			return fullList[iCurrent][i];
		}

		public int GetValues(object[] values)
		{
			throw new NotImplementedException();
		}

		public bool IsDBNull(int i)
		{
			throw new NotImplementedException();
		}

		public object this[string name]
		{
			get { return fullList[iCurrent][properties.FindIndex(a => a.Name == name)]; }
		}

		public object this[int i]
		{
			get { return fullList[iCurrent][i]; }
		}

		#endregion
	}
}