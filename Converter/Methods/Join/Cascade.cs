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
						_builder.AddLine(".Cascade.SaveUpdate()");
						break;
					case "none":
						_builder.AddLine(".Cascade.None()");
						break;
					default:
						_builder.AddLine(".Cascade.?");
						break;
				}
			}
		}

	}
}