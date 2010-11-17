using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Unique : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Unique(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo info)
		{
			if (info.Type == PropertyMappingType.Id)
			{
				return;
			}
			if (info.IsUnique != null && info.IsUnique.Value)
			{
				_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.Unique));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Unique
			{
				get { return ReflectionUtility.GetMethodName((PropertyPart ip) => ip.Unique()); }
			}
		}
	}
}