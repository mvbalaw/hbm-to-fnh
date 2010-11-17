using FluentNHibernate.Mapping;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Column : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Column(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo item)
		{
			if (item.Type == PropertyMappingType.Component ||
			    item.Type == PropertyMappingType.Property ||
			    item.Type == PropertyMappingType.Set ||
			    item.Type == PropertyMappingType.Bag)
			{
				return;
			}
			if (item.ColumnName != null)
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.Column, item.ColumnName));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Column
			{
				get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.Column(null)); }
			}
		}
	}
}