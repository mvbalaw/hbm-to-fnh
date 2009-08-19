namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class Table
	{
		private readonly CodeFileBuilder _builder;

		public Table(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string table)
		{
			_builder.AddLine(".Table(\"" + table + "\")");
		}
	}
}