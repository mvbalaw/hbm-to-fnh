namespace NHibernateHbmToFluent.Converter.Methods.Join
{
	public class KeyColumn
	{
		private readonly CodeFileBuilder _builder;

		public KeyColumn(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(bool isInverse, string columnName, PropertyMappingType type)
		{
			if (type == PropertyMappingType.ManyToMany)
			{
				if (isInverse)
				{
					_builder.AddLine(".ChildKeyColumn(\"" + columnName + "\")");
				}
				else
				{
					_builder.AddLine(".ParentKeyColumn(\"" + columnName + "\")");
				}
			}
			else if (type == PropertyMappingType.OneToMany)
			{
				_builder.AddLine(".KeyColumn(\"" + columnName + "\")");
			}
		}

	}
}