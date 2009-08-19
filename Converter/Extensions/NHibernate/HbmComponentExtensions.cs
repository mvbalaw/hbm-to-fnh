using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmComponentExtensions
	{
		public static string GetPropertyName(this HbmComponent item)
		{
			return item.name;
		}

		public static string GetReturnType(this HbmComponent item)
		{
			return item.@class.GetTypeName();
		}
	}
}