using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class References : IMapStart
	{
		private readonly CodeFileBuilder _builder;
		private readonly Column _column;

		public References(CodeFileBuilder builder)
		{
			_builder = builder;
			_column = new Column(_builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, string.Format("{0}(x => x.{1})", FluentNHibernateNames.References, item.Name));
			_column.Add(item);
		}

		public static class FluentNHibernateNames
		{
			public static string References
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.References(x => x)); }
			}
		}
	}
}