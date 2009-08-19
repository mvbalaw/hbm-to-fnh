using NHibernateHbmToFluent.Converter.Extensions;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class References : IMapStart
	{
		private readonly CodeFileBuilder _builder;

		public References(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, "References(x => x." + item.Name + ")");
		}
	}
}