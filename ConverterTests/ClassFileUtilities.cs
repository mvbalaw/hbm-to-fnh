using System.Linq;
using NHibernateHbmToFluent.Converter.Extensions;

namespace ConverterTests
{
	public static class ClassFileUtilities
	{
		public static string[] GetConstructorContents(string mapFileContents, string className)
		{
			string[] lines = mapFileContents.SplitOnFormattingWhitespace();
			string constructorStart = className + "()";
			string[] constructorInternals = lines
				.SkipWhile(x => !x.EndsWith(constructorStart))
				.SkipWhile(x => x.EndsWith(constructorStart))
				.SkipWhile(x => x == "{")
				.TakeWhile(x => x != "}")
				.ToArray();
			return constructorInternals;
		}
	}
}