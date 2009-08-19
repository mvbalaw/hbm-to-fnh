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
					_builder.AddLine(".Not.LazyLoad()");
				}
				else
				{
					_builder.AddLine(".LazyLoad()");
				}
			}
		}
	}
}