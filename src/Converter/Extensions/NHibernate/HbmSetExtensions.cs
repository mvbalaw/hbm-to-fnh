using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmSetExtensions
	{
		public static bool? IsUnique(this HbmSet item)
		{
			if (item.key == null || !item.key.uniqueSpecified)
			{
				return null;
			}
			return item.key.unique;
		}

		public static string GetPropertyName(this HbmSet item)
		{
			return item.name;
		}

		public static string GetReturnType(this HbmSet item)
		{
			return new MappedPropertyInfo(item.Item, null).ReturnType;
		}

		public static string GetColumnName(this HbmSet item)
		{
			return item.key.column1;
		}

		public static bool? CanBeNull(this HbmSet item)
		{
			return item.inverse;
		}
	}
}