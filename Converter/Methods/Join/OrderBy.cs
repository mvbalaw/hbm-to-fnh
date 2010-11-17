namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class OrderBy
	{
		private readonly CodeFileBuilder _builder;

		public OrderBy(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string orderBy)
		{
			if (orderBy != null)
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.OrderBy, orderBy));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string OrderBy
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).OrderBy(null)); }
			}
		}
	}
}