using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class IndexTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Index()
			{
				Index.FluentNHibernateNames.Index.ShouldBeEqualTo("Index");
			}
		}
	}
}