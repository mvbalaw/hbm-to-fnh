namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class Table
	{
		private readonly CodeFileBuilder _builder;

		public Table(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string tableName)
		{
			if (tableName != null)
			{
				_builder.AddLine(string.Format(".{0}(\"{1}\")", FluentNHibernateNames.Table, tableName));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Table
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).Table(null)); }
			}
		}
	}
}