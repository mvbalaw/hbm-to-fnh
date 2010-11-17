using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmManyToManyExtensions
	{
		public static string GetReturnType(this HbmManyToMany item)
		{
			return item.@class.GetTypeName();
		}

		public static string GetColumnName(this HbmManyToMany item)
		{
			return item.column;
		}
	}
}