using NHibernateHbmToFluent.Converter.Types;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class SetTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__HasManyToMany()
			{
				Set.FluentNHibernateNames.HasManyToMany.ShouldBeEqualTo("HasManyToMany");
			}

			[Test]
			public void Should_return_the_correct_value_for__HasMany()
			{
				Set.FluentNHibernateNames.HasMany.ShouldBeEqualTo("HasMany");
			}

			[Test]
			public void Should_return_the_correct_value_for__AsSet()
			{
				Set.FluentNHibernateNames.AsSet.ShouldBeEqualTo("AsSet");
			}
		}
	}
}