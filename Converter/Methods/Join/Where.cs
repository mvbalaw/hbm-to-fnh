namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class Where
	{
		private readonly CodeFileBuilder _builder;

		public Where(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string @where)
		{
			if (@where != null)
			{
				_builder.AddLine(".Where(x => x." + @where.Replace("'", "\"").Replace("=", "==") + ")");
			}
		}
	}
}