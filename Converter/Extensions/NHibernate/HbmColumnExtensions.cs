using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmColumnExtensions
	{
		public static string GetUniqueIndex(this HbmColumn column)
		{
			if (column == null)
			{
				return null;
			}
			return column.index;
		}

		public static bool? CanBeNull(this HbmColumn column)
		{
			if (column == null || !column.notnullSpecified)
			{
				return null;
			}
			return !column.notnull;
		}

		public static bool? IsUnique(this HbmColumn column)
		{
			if (column == null || !column.uniqueSpecified)
			{
				return null;
			}
			return column.unique;
		}
	}
}