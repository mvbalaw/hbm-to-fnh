using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Index : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Index(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo info)
		{
			if (info.Type == PropertyMappingType.Id)
			{
				return;
			}
			if (info.UniqueIndex != null)
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.Index, info.UniqueIndex));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Index
			{
				get { return ReflectionUtility.GetMethodName((PropertyPart ip) => ip.Index(null)); }
			}
		}
	}
}