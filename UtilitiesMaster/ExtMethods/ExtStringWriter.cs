using System;
using System.IO;
using System.Text;

namespace UtilitiesMaster.ExtMethods.ExtStringWriter
{
	public class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding
		{
			get { return Encoding.UTF8; }
		}
	}
}
