using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class GeneratedBy : ICommonMapMethod
	{
		private readonly CodeFileBuilder _builder;

		public GeneratedBy(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(MappedPropertyInfo info)
		{
			if (info.Type != PropertyMappingType.Id)
			{
				return;
			}

			HbmId id = info.HbmObject<HbmId>();
			HbmGenerator generator = id.generator;
			if (generator != null)
			{
				switch (generator.@class)
				{
					case "sequence":
						{
							HbmParam[] parameters = generator.param;
							string[] text = parameters[0].Text;
							_builder.AddLine(".GeneratedBy.Sequence(\"" + text[0] + "\")");
							break;
						}
					case "assigned":
						_builder.AddLine(".GeneratedBy.Assigned()");
						break;
					case "native":
						_builder.AddLine(".GeneratedBy.Native()");
						break;
					default:
						_builder.AddLine(".GeneratedBy. ?");
						break;
				}
			}
			if (id.unsavedvalue != null)
			{
				var unsavedValue = id.unsavedvalue == "null" ? "String.Empty" : id.unsavedvalue;
				_builder.AddLine(".UnsavedValue(" + unsavedValue + ")");
			}
		}
	}
}