using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmOneToManyExtensions
	{
		public static string GetReturnType(this HbmOneToMany item)
		{
			return item.@class.GetTypeName();
		}
	}
}