using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using UtilitiesMaster.ExtMethods.ExtStringWriter;

namespace UtilitiesMaster.ExtMethods.ExtXml
{
	public static class XmlExtensions
	{
		public static string ToStringWithDeclaration(this XDocument doc)
		{
			if (doc == null)
				throw new ArgumentNullException("doc");

			using (TextWriter writer = new Utf8StringWriter())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(writer))
				{
					doc.Save(writer);
				}
				return writer.ToString();
			}
		}

	}
}
