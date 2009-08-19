namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class Inverse
	{
		private readonly CodeFileBuilder _builder;

		public Inverse(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(bool inverse)
		{
			if (inverse)
			{
				_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.Inverse));
			}
			else
			{
				_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.Not, FluentNHibernateNames.Inverse));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Not
			{
				get { return ReflectionUtility.GetPropertyName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Not); }
			}

			public static string Inverse
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Inverse()); }
			}
		}
	}
}