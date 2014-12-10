using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter
{
	public class MappedClassInfo
	{
		public string FileName { get; private set; }
		private readonly HbmClass _classInfo;

		public MappedClassInfo(HbmClass classInfo, string fileName)
		{
			FileName = fileName;
			_classInfo = classInfo;

			Properties = new List<MappedPropertyInfo>();
			if (classInfo.Id != null)
			{
				Properties.Add(new MappedPropertyInfo(classInfo.Id, fileName));
			}
			if (classInfo.Items != null)
			{
				Properties.AddRange(_classInfo.Items.Select(x => new MappedPropertyInfo(x, fileName)));
			}
			string[] parts = classInfo.name.Split(new[] {','});
			ClassName = parts[0];
		    if (parts.Length > 1)
		    {
                AssemblyName = parts[1].Trim();
		    }

		    Mutable = classInfo.mutable;
		    Cache = classInfo.cache;

			TableName = classInfo.table;
		}

		[NotNull]
		public string AssemblyName { get; private set; }

		[NotNull]
		public string ClassName { get; private set; }

		[NotNull]
		public string TableName { get; private set; }

        public Boolean Mutable { get; private set; }

        public HbmCache Cache { get; private set; }

		[NotNull]
		public List<MappedPropertyInfo> Properties { get; private set; }
	}
}