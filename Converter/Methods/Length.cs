namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Length : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Length(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo item)
		{
			if (item.Type != PropertyMappingType.Property)
			{
				return;
			}
			if (item.MaxLength != null)
			{
				_builder.AddLine(".Length(" + item.MaxLength + ")");
			}
		}
	}
}