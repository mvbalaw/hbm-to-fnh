using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Extensions.NHibernate
{
	public static class HbmManyToOneExtensions
	{
		public static bool? IsUnique(this HbmManyToOne item)
		{
			if (item.unique)
			{
				return true;
			}
			HbmColumn column = item.Column();
			if (column == null)
			{
				return item.unique;
			}
			return column.IsUnique();
		}

		public static int? GetMaxLength(this HbmManyToOne item)
		{
			string sqlType = item.GetSqlType();

			if (sqlType != "VARCHAR2")
			{
				return null;
			}
			HbmColumn column = item.Column();
			int? maxLength = column.length.ParseInt32();
			return maxLength;
		}

		public static string GetSqlType(this HbmManyToOne item)
		{
			string columnName = item.column;
			if (columnName == null)
			{
				HbmColumn column = item.Column();
				columnName = column.sqltype;
			}
			return columnName;
		}

		public static string GetUniqueIndex(this HbmManyToOne item)
		{
			if (item.index != null)
			{
				return item.index;
			}
			return item.Column().GetUniqueIndex();
		}

		public static string GetPropertyName(this HbmManyToOne item)
		{
			return item.name;
		}

		public static string GetReturnType(this HbmManyToOne item)
		{
			return item.@class.GetTypeName();
		}

		public static bool? CanBeNull(this HbmManyToOne item)
		{
			if (item.notnullSpecified)
			{
				return !item.notnull;
			}
			return item.Column().CanBeNull();
		}

		public static string GetColumnName(this HbmManyToOne item)
		{
			return item.Column().name;
		}

		private static HbmColumn Column(this HbmManyToOne item)
		{
			return (HbmColumn) item.Items[0];
		}
	}
}