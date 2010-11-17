using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions;

namespace NHibernateHbmToFluent.Converter.Types
{
	public class Component : IMapStart
	{
		private readonly CodeFileBuilder _builder;

		public Component(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Start(string prefix, MappedPropertyInfo item)
		{
			CodeFileBuilder componentBuilder = new CodeFileBuilder();
			componentBuilder.Indent(5);
			const string subPrefix = "y.";
			HbmComponent component = item.HbmObject<HbmComponent>();
			componentBuilder.AddLine("");

			var componentBodyBuilder = new ClassMapBody(componentBuilder);
			foreach (var componentPart in component.Items)
			{
				componentBodyBuilder.Add(subPrefix, new MappedPropertyInfo(componentPart, item.FileName));
			}
			_builder.StartMethod(prefix, string.Format("{0}<{1}>(x => x.{2}, y=>", FluentNHibernateNames.Component, item.ReturnType, item.Name));
			_builder.AddLine("{");
			_builder.AddLine(componentBuilder.ToString());
			_builder.AddLine("})");
			if (component.insert)
			{
				_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.Insert));
			}
			if (component.update)
			{
				_builder.AddLine(string.Format(".{0}()", FluentNHibernateNames.Update));
			}
		}

		public static class FluentNHibernateNames
		{
			public static string Component
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.Component(x => x, null)); }
			}

			public static string Insert
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.Component(x => x, null).Insert()); }
			}

			public static string Update
			{
				get { return ReflectionUtility.GetMethodName((FakeMap f) => f.Component(x => x, null).Update()); }
			}
		}
	}
}