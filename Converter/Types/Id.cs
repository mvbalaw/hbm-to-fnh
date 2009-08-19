using NHibernateHbmToFluent.Converter.Extensions;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Id : IMapStart
	{
		private readonly CodeFileBuilder _builder;

		public Id(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, "Id(x => x." + item.Name + ")");
		}
	}
}