using NHibernateHbmToFluent.Converter.Types;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class BagTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__HasManyToMany()
			{
				Bag.FluentNHibernateNames.HasManyToMany.ShouldBeEqualTo("HasManyToMany");
			}

			[Test]
			public void Should_return_the_correct_value_for__HasMany()
			{
				Bag.FluentNHibernateNames.HasMany.ShouldBeEqualTo("HasMany");
			}

			[Test]
			public void Should_return_the_correct_value_for__AsBag()
			{
				Bag.FluentNHibernateNames.AsBag.ShouldBeEqualTo("AsBag");
			}
		}
	}
}