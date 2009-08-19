namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Unique : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Unique(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo info)
		{
			if (info.Type == PropertyMappingType.Id)
			{
				return;
			}
			if (info.IsUnique != null && info.IsUnique.Value)
			{
				_builder.AddLine(".Unique()");
			}
			if (info.UniqueIndex != null)
			{
				_builder.AddLine(".Index(\"" + info.UniqueIndex + "\")");
			}
		}
	}
}