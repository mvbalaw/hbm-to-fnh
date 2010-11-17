using FluentNHibernate.Mapping;
using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class GeneratedBy
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
							_builder.AddLine(string.Format(".{0}.{1}(\"{2}\")", FluentNHibernateNames.GeneratedBy, FluentNHibernateNames.Sequence, text[0]));
							break;
						}
					case "assigned":
						_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.GeneratedBy, FluentNHibernateNames.Assigned));
						break;
					case "native":
						_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.GeneratedBy, FluentNHibernateNames.Native));
						break;
					default:
						_builder.AddLine(string.Format(".{0}. ?", FluentNHibernateNames.GeneratedBy));
						break;
				}
			}
		}

		public static class FluentNHibernateNames
		{
			public static string GeneratedBy
			{
				get { return ReflectionUtility.GetPropertyName((IdentityPart ip) => ip.GeneratedBy); }
			}

			public static string Assigned
			{
				get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.GeneratedBy.Assigned()); }
			}

			public static string Native
			{
				get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.GeneratedBy.Native()); }
			}

			public static string Sequence
			{
				get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.GeneratedBy.Sequence(null)); }
			}
		}
	}
}