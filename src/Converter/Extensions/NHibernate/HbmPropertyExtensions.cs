using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmPropertyExtensions
	{
		public static bool? IsUnique(this HbmProperty item)
		{
			if (item.unique)
			{
				return item.unique;
			}
			HbmColumn column = item.Column();
			if (column == null)
			{
				return item.unique;
			}
			return column.IsUnique();
		}

		public static string GetUniqueIndex(this HbmProperty item)
		{
			if (item.index != null)
			{
				return item.index;
			}
			return item.Column().GetUniqueIndex();
		}

		public static string GetPropertyName(this HbmProperty item)
		{
			return item.name;
		}

		public static string GetReturnType(this HbmProperty item)
		{
			return item.type1.GetTypeName();
		}

		public static string GetColumnName(this HbmProperty item)
		{
			string columnName = item.column;
			if (columnName == null)
			{
				HbmColumn column = item.Column();
				columnName = column.name;
			}
			return columnName;
		}

		public static string GetSqlType(this HbmProperty item)
		{
			if (item.column != null)
			{
				return item.column;
			}
			HbmColumn column = item.Column();
			if (column == null)
			{
				return null;
			}
			string sqlType = column.sqltype;
			return sqlType;
		}

		public static int? GetMaxLength(this HbmProperty item)
		{
			int? maxLength = item.length.ParseInt32();
			if (maxLength == null)
			{
				HbmColumn column = item.Column();
				if (column != null)
				{
					maxLength = column.length.ParseInt32();
				}
			}
			return maxLength;
		}

		public static bool? CanBeNull(this HbmProperty item)
		{
			if (item.notnullSpecified)
			{
				return !item.notnull;
			}
			return item.Column().CanBeNull();
		}

		private static HbmColumn Column(this HbmProperty item)
		{
			if (item.Items == null)
			{
				return null;
			}
			return (HbmColumn) item.Items[0];
		}
	}
}