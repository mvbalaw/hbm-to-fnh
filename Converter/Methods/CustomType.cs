using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class CustomType
	{
		private readonly CodeFileBuilder _builder;

		public CustomType(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo item)
		{
			if (item.Type != PropertyMappingType.Property)
			{
				return;
			}

			if (item.SqlType == "CHAR" && item.ReturnType == "YesNo")
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.CustomType, item.ReturnType));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string CustomType
			{
				get { return ReflectionUtility.GetMethodName((PropertyPart ip) => ip.CustomType(typeof (string))); }
			}
		}
	}
}