using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmManyToManyExtensionsTests
	{
		[TestFixture]
		public class When_asked_to_GetReturnType
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "System.String";
				HbmManyToMany component = new HbmManyToMany
					{
						@class = expected + ", mscorlib"
					};
				string result = component.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetColumnName
		{
			[Test]
			public void Should_get_the_correct_value_from_column_if_not_null()
			{
				const string expected = "FirstName";
				HbmManyToMany property = new HbmManyToMany
					{
						column = expected
					};
				string result = property.GetColumnName();
				result.ShouldBeEqualTo(expected);
			}
		}
	}
}