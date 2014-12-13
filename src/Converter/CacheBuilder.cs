using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter
{
	public class CacheBuilder
	{
		private readonly CodeFileBuilder _builder;

        public CacheBuilder(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(HbmCache cache, bool body = false)
		{
		    if (cache == null) return;

		    string region = "";
            if (cache.region != null)
            {
                region = string.Format(".Region(\"{0}\")", cache.region);
            }

		    string cacheStr = string.Format("Cache.{0}(){1}", cache.usage == HbmCacheUsage.NonstrictReadWrite? "NonStrictReadWrite" : cache.usage.ToString(), region);
		    if (body)
		    {
		        cacheStr = cacheStr + ";";
		    }
		    else
		    {
		        cacheStr = "." + cacheStr;
		    }

            _builder.AddLine(cacheStr);
		}
	}
}