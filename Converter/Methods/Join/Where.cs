namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class Where
	{
		private readonly CodeFileBuilder _builder;

		public Where(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string sqlWhereClause)
		{
			if (sqlWhereClause != null)
			{
				_builder.AddLine(string.Format(".{0}(x => x.{1})", FluentNHibernateNames.Where, sqlWhereClause.Replace("'", "\"").Replace("=", "==")));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Where
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.HasManyToMany<string>(x => x.ToLower()).Where(x => 1 == 1)); }
			}
		}
	}
}