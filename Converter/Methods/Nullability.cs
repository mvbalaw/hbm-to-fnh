namespace NHibernateHbmToFluent.Converter.Methods
{
	public class Nullability : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public Nullability(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo info)
		{
			if (info.Type == PropertyMappingType.Id ||
			    info.Type == PropertyMappingType.Set ||
			    info.Type == PropertyMappingType.Bag)
			{
				return;
			}
			if (info.CanBeNull != null)
			{
				if (!info.CanBeNull.Value)
				{
					_builder.AddLine(".Not.Nullable()");
				}
			}
		}
	}
}