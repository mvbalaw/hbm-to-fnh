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
			componentBuilder.Indent();
			componentBuilder.Indent();
			componentBuilder.Indent();
			componentBuilder.Indent();
			componentBuilder.Indent();
			const string subPrefix = "y.";
			HbmComponent component = item.HbmObject<HbmComponent>();
			componentBuilder.AddLine("");

			var componentBodyBuilder = new ClassMapBody(componentBuilder);
			foreach (var componentPart in component.Items)
			{
				componentBodyBuilder.Add(subPrefix, new MappedPropertyInfo(componentPart, item.FileName));
			}
			_builder.StartMethod(prefix, "Component<" + item.ReturnType + ">(x => x." + item.Name + ", y=>");
			_builder.AddLine("{");
			_builder.AddLine(componentBuilder.ToString());
			_builder.AddLine("})");
			if (component.insert)
			{
				_builder.AddLine(".Insert()");
			}
			if (component.update)
			{
				_builder.AddLine(".Update()");
			}
		}
	}
}