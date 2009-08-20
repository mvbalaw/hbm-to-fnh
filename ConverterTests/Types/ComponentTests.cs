using NHibernateHbmToFluent.Converter.Types;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class ComponentTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Component()
			{
				Component.FluentNHibernateNames.Component.ShouldBeEqualTo("Component");
			}

			[Test]
			public void Should_return_the_correct_value_for__Insert()
			{
				Component.FluentNHibernateNames.Insert.ShouldBeEqualTo("Insert");
			}

			[Test]
			public void Should_return_the_correct_value_for__Update()
			{
				Component.FluentNHibernateNames.Update.ShouldBeEqualTo("Update");
			}
		}
	}
}