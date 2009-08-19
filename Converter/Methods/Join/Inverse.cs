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
				_builder.AddLine(".Inverse()");
			}
			else
			{
				_builder.AddLine(".Not.Inverse()");
			}
		}
	}
}