using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmOneToManyExtensionsTests
	{
		[TestFixture]
		public class When_asked_to_GetReturnType
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "System.String";
				HbmOneToMany component = new HbmOneToMany
					{
						@class = expected + ", mscorlib"
					};
				string result = component.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}
	}
}