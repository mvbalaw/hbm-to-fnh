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
        private readonly CacheBuilder _cacheBuilder;

		public Bag(CodeFileBuilder builder)
		{
			_builder = builder;
			_orderBy = new OrderBy(builder);
			_cascade = new Cascade(builder);
			_inverse = new Inverse(builder);
			_table = new Table(builder);
			_keyColumn = new KeyColumn(builder);
			_lazyLoad = new LazyLoad(builder);
            _cacheBuilder = new CacheBuilder(builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			HbmBag bag = item.HbmObject<HbmBag>();
			PropertyMappingType subType = new MappedPropertyInfo(bag.Item, item.FileName).Type;
			if (subType == PropertyMappingType.ManyToMany)
			{
				_builder.StartMethod(prefix, string.Format("{0}<{1}>(x => x.{2})", FluentNHibernateNames.HasManyToMany, item.ReturnType, item.Name));
			}
			else if (subType == PropertyMappingType.OneToMany)
			{
				_builder.StartMethod(prefix, string.Format("{0}<{1}>(x => x.{2})", FluentNHibernateNames.HasMany, item.ReturnType, item.Name));
			}
			else
			{
				_builder.StartMethod(prefix, "bag?(x => x" + item.Name + ")");
			}
			_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.AsBag));
			_keyColumn.Add(bag.inverse, item.ColumnName, subType);
			_lazyLoad.Add(bag.lazySpecified, bag.lazy);
			_table.Add(bag.table);
			_inverse.Add(bag.inverse);
			_cascade.Add(bag.cascade);
			_orderBy.Add(bag.orderby);
            _cacheBuilder.Add(bag.cache);
        }

		public static class FluentNHibernateNames
		{
			public static string HasManyToMany
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x)); }
			}

			public static string HasMany
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x)); }
			}

			public static string AsBag
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x).AsBag()); }
			}
		}
	}
}