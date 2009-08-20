using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Map : IMapStart
	{
		private readonly CodeFileBuilder _builder;
		private readonly Length _length;
		private readonly CustomType _customType;

		public Map(CodeFileBuilder builder)
		{
			_builder = builder;
			_length = new Length(_builder);
			_customType = new CustomType(_builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, string.Format("{0}(x => x.{1}, \"{2}\")", FluentNHibernateNames.Map, item.Name, item.ColumnName));
			_customType.Add(item);
			_length.Add(item);
		}

		public static class FluentNHibernateNames
		{
			public static string Map
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.Map(null)); }
			}
		}
	}
}