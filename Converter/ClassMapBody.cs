using System.Collections.Generic;
using NHibernateHbmToFluent.Converter.Methods;

namespace NHibernateHbmToFluent.Converter
{
	public class ClassMapBody
	{
		private readonly CodeFileBuilder _builder;

		public ClassMapBody(CodeFileBuilder builder)
		{
			_builder = builder;
		}

		public void Add(string prefix, MappedPropertyInfo info)
		{
			var methodBuilders = new List<ICommonMapMethod>
				{
					new Column(_builder),
					new Length(_builder),
					new Nullability(_builder),
					new Unique(_builder),
					new Index(_builder)
				};
			GeneratedBy generatedBy = new GeneratedBy(_builder);
			info.Type.StartMethod(prefix, _builder, info);
			{
				methodBuilders.ForEach(x => x.Add(info));
			}
			EndMap(_builder);
		}


		private static void EndMap(CodeFileBuilder builder)
		{
			builder.AddLine(";");
			builder.Unindent();
		}
	}
}