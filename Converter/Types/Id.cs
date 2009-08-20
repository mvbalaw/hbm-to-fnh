using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Id : IMapStart
	{
		private readonly CodeFileBuilder _builder;
		private readonly GeneratedBy _generatedBy;
		private readonly UnsavedValue _unsavedValue;
		private readonly Column _column;

		public Id(CodeFileBuilder builder)
		{
			_builder = builder;
			_column = new Column(_builder);
			_generatedBy = new GeneratedBy(_builder);
			_unsavedValue = new UnsavedValue(_builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, string.Format("{0}(x => x.{1})", FluentNHibernateNames.Id, item.Name));
			_column.Add(item);
			_generatedBy.Add(item);
			_unsavedValue.Add(item);
		}

		public static class FluentNHibernateNames
		{
			public static string Id
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.Id(null)); }
			}
		}
	}
}