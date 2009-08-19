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
				_builder.AddLine(".OrderBy(\"" + orderBy + "\")");
			}
		}
	}
}