using FluentNHibernate.Mapping;

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
					_builder.AddLine(string.Format(".{0}.{1}()", FluentNHibernateNames.Not, FluentNHibernateNames.Nullable));
				}
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Not
			{
				get { return ReflectionUtility.GetPropertyName((PropertyPart ip) => ip.Not); }
			}

			public static string Nullable
			{
				get { return ReflectionUtility.GetMethodName((PropertyPart ip) => ip.Nullable()); }
			}
		}
	}
}