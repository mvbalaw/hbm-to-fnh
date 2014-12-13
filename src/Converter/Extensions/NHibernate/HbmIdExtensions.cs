using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmIdExtensions
	{
		public static bool? IsUnique(this HbmId item)
		{
			return item.Column().IsUnique();
		}

		public static string GetSqlType(this HbmId item)
		{
			return item.Column().sqltype;
		}

		public static int? GetMaxLength(this HbmId item)
		{
			int? maxLength = item.length.ParseInt32();
			if (maxLength == null)
			{
				HbmColumn column = item.Column();
				maxLength = column.length.ParseInt32();
			}
			return maxLength;
		}

		public static string GetColumnName(this HbmId item)
		{
			HbmColumn column = item.Column();
			if (column == null)
			{
				return item.column1;
			}
			return column.name;
		}

		public static string GetUniqueIndex(this HbmId item)
		{
			return item.Column().GetUniqueIndex();
		}

		public static string GetPropertyName(this HbmId item)
		{
			return item.name;
		}

		public static string GetReturnType(this HbmId item)
		{
			return item.type1.GetTypeName();
		}

		public static bool? CanBeNull(this HbmId item)
		{
			return item.Column().CanBeNull();
		}

		private static HbmColumn Column(this HbmId item)
		{
			if (item.column == null)
			{
				return null;
			}

			return item.column[0];
		}
	}
}