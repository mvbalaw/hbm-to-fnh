using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmComponentExtensionsTests
	{
		[TestFixture]
		public class When_asked_to_GetPropertyName
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "FirstName";
				HbmComponent component = new HbmComponent
					{
						name = expected
					};
				string result = component.GetPropertyName();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetReturnType
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "System.String";
				HbmComponent component = new HbmComponent
					{
						@class = expected + ", mscorlib"
					};
				string result = component.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}
	}
}