using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Length
	{
		private readonly CodeFileBuilder _builder;

		public Length(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo item)
		{
			if (item.Type != PropertyMappingType.Property)
			{
				return;
			}
			if (item.MaxLength != null)
			{
				_builder.AddLine(string.Format(".{0}({1})", FluentNHibernateNames.Length, item.MaxLength));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Length
			{
				get { return ReflectionUtility.GetMethodName((PropertyPart ip) => ip.Length(6)); }
			}
		}
	}
}