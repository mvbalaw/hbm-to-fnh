namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class Cascade
	{
		private readonly CodeFileBuilder _builder;

		public Cascade(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string cascadeType)
		{
			if (cascadeType != null)
			{
				switch (cascadeType)
				{
					case "save-update":
						_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.Cascade, FluentNHibernateNames.SaveUpdate));
						break;
					case "none":
						_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.Cascade, FluentNHibernateNames.None));
						break;
					default:
						_builder.AddLine(string.Format(".{0}.?", FluentNHibernateNames.Cascade));
						break;
				}
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Cascade
			{
				get { return ReflectionUtility.GetPropertyName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Cascade); }
			}

			public static string SaveUpdate
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Cascade.SaveUpdate()); }
			}

			public static string None
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Cascade.None()); }
			}
		}
	}
}