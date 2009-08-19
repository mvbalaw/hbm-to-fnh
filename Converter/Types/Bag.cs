using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods.Join;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Bag : IMapStart
	{
		private readonly CodeFileBuilder _builder;
		private readonly OrderBy _orderBy;
		private readonly Cascade _cascade;
		private readonly Inverse _inverse;
		private readonly Table _table;
		private readonly KeyColumn _keyColumn;
		private readonly LazyLoad _lazyLoad;

		public Bag(CodeFileBuilder builder)
		{
			_builder = builder;
			_orderBy = new OrderBy(builder);
			_cascade = new Cascade(builder);
			_inverse = new Inverse(builder);
			_table = new Table(builder);
			_keyColumn = new KeyColumn(builder);
			_lazyLoad = new LazyLoad(builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			HbmBag bag = item.HbmObject<HbmBag>();
			PropertyMappingType subType = new MappedPropertyInfo(bag.Item, item.FileName).Type;
			if (subType == PropertyMappingType.ManyToMany)
			{
				_builder.StartMethod(prefix, "HasManyToMany<" + item.ReturnType + ">(x => x." + item.Name + ")");
			}
			else if (subType == PropertyMappingType.OneToMany)
			{
				_builder.StartMethod(prefix, "HasMany<" + item.ReturnType + ">(x => x." + item.Name + ")");
			}
			else
			{
				_builder.StartMethod(prefix, "bag?(x => x" + item.Name + ")");
			}
			_builder.AddLine(".AsBag()");
			_keyColumn.Add(bag.inverse, item.ColumnName, subType);
			_lazyLoad.Add(bag.lazySpecified, bag.lazy);
			_table.Add(bag.table);
			_inverse.Add(bag.inverse);
			_cascade.Add(bag.cascade);
			_orderBy.Add(bag.orderby);
		}
	}
}