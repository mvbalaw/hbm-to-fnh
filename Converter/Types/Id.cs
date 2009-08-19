using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Id : IMapStart
	{
		private readonly CodeFileBuilder _builder;
		private readonly GeneratedBy _generatedBy;
		private readonly UnsavedValue _unsavedValue;

		public Id(CodeFileBuilder builder)
		{
			_builder = builder;
			_generatedBy = new GeneratedBy(_builder);
			_unsavedValue = new UnsavedValue(_builder);
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			_builder.StartMethod(prefix, "Id(x => x." + item.Name + ")");
			_generatedBy.Add(item);
			_unsavedValue.Add(item);
		}
	}
}