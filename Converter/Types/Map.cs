using NHibernateHbmToFluent.Converter.Extensions;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Map : IMapStart
	{
		private readonly CodeFileBuilder _builder;

		public Map(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, "Map(x => x." + item.Name + ", \"" + item.ColumnName + "\")");
			if (item.SqlType == "CHAR" && item.ReturnType == "YesNo")
			{
				_builder.AddLine(".CustomType(\"YesNo\")");
			}
		}
	}
}