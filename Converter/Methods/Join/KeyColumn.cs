namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class KeyColumn
	{
		private readonly CodeFileBuilder _builder;

		public KeyColumn(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(bool isInverse, string columnName, PropertyMappingType type)
		{
			if (type == PropertyMappingType.ManyToMany)
			{
				if (isInverse)
				{
					_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.ChildKeyColumn, columnName));
				}
				else
				{
					_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.ParentKeyColumn, columnName));
				}
			}
			else if (type == PropertyMappingType.OneToMany)
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.KeyColumn, columnName));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string ChildKeyColumn
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).ChildKeyColumn(null)); }
			}

			public static string ParentKeyColumn
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).ParentKeyColumn(null)); }
			}

			public static string KeyColumn
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).KeyColumn(null)); }
			}
		}
	}
}