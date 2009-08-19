using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmBagExtensions
	{
		public static bool? IsUnique(this HbmBag item)
		{
			if (item.key == null || !item.key.uniqueSpecified)
			{
				return null;
			}
			return item.key.unique;
		}

		public static string GetPropertyName(this HbmBag item)
		{
			return item.name;
		}

		public static string GetReturnType(this HbmBag item)
		{
			HbmOneToMany oneToMany = (HbmOneToMany) item.Item;
			return oneToMany.@class.GetTypeName();
		}

		public static string GetColumnName(this HbmBag item)
		{
			return item.key.column1;
		}

		public static bool? CanBeNull(this HbmBag item)
		{
			return item.inverse;
		}
	}
}