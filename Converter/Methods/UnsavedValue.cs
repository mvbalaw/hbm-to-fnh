using FluentNHibernate.Mapping;
using NHibernate.Cfg.MappingSchema;

namespace NHibernateHbmToFluent.Converter.Methods
{
	public class UnsavedValue
	{
		private readonly CodeFileBuilder _builder;

		public UnsavedValue(CodeFileBuilder builder)
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
			if (id.unsavedvalue != null)
			{
				var unsavedValue = id.unsavedvalue == "null" ? "String.Empty" : id.unsavedvalue;
				_builder.AddLine(string.Format(".{0}({1})", FluentNHibernateNames.UnsavedValue, unsavedValue));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string UnsavedValue
			{
				get { return ReflectionUtility.GetMethodName((IdentityPart ip) => ip.UnsavedValue(null)); }
			}
		}
	}
}