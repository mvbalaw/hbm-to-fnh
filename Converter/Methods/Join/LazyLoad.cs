using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class LazyLoad
	{
		private readonly CodeFileBuilder _builder;

		public LazyLoad(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(bool lazySpecified, HbmCollectionLazy lazy)
		{
			if (lazySpecified)
			{
				if (lazy == HbmCollectionLazy.False)
				{
					_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.Not, FluentNHibernateNames.LazyLoad));
				}
				else
				{
					_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.LazyLoad));
				}
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Not
			{
				get { return ReflectionUtility.GetPropertyName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).Not); }
			}

			public static string LazyLoad
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).LazyLoad()); }
			}
		}
	}
}