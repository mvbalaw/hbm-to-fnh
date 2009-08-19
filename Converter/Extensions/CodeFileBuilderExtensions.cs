namespace NHibernateHbmToFluent.Converter.Extensions
{
	public static class CodeFileBuilderExtensions
	{
		public static void StartMethod(this CodeFileBuilder builder, string prefix, string methodBody)
		{
			builder.AddLine(prefix+methodBody);
			builder.Indent();
		}
	}
}