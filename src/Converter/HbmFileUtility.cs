using System;
using System.IO;
using System.Text;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Util;

namespace NHibernateHbmToFluent.Converter
{
	public static class HbmFileUtility
	{
		public const string NHibernateFileExtension = ".hbm.xml";

		public static MappedClassInfo LoadFile(string nhibernateFilePath)
		{
			MappingDocumentParser parser = new MappingDocumentParser();
			HbmMapping mapping;

			try
			{
				using (FileStream stream = File.OpenRead(nhibernateFilePath))
				{
					mapping = parser.Parse(stream);
				}
			}
			catch (Exception)
			{
				Console.WriteLine(nhibernateFilePath);
				throw;
			}

			if (mapping.Items.Length != 1)
			{
				throw new ParserException("NHibernate file has NO data: " + nhibernateFilePath);
			}

			MappedClassInfo classInfo = new MappedClassInfo((HbmClass) mapping.Items[0], nhibernateFilePath);
			return classInfo;
		}

		public static MappedClassInfo LoadFromString(string hbmData)
		{
			MappingDocumentParser parser = new MappingDocumentParser();
			MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(hbmData));
			HbmMapping mapping = parser.Parse(stream);

			if (mapping.Items.Length != 1)
			{
				throw new ParserException("NO data in: " + hbmData);
			}

			MappedClassInfo classInfo = new MappedClassInfo((HbmClass) mapping.Items[0], "from text");
			return classInfo;
		}
	}
}