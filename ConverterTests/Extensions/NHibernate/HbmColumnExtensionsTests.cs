using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmColumnExtensionsTests
	{
		[TestFixture]
		public class When_asked_if_CanBeNull
		{
			[Test]
			public void Should_get_null_given_null()
			{
				const HbmColumn column = null;
				bool? result = column.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_notnullSpecified_is_false()
			{
				HbmColumn column = new HbmColumn
					{
						notnullSpecified = false
					};
				bool? result = column.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_notnullSpecified_is_true_and_notnull_is_false()
			{
				HbmColumn column = new HbmColumn
					{
						notnullSpecified = true,
						notnull = false
					};
				bool? result = column.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_notnullSpecified_is_true_and_notnull_is_true()
			{
				HbmColumn column = new HbmColumn
					{
						notnullSpecified = true,
						notnull = true
					};
				bool? result = column.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}

		[TestFixture]
		public class When_asked_if_IsUnique
		{
			[Test]
			public void Should_get_null_given_null()
			{
				const HbmColumn column = null;
				bool? result = column.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_uniqueSpecified_is_false()
			{
				HbmColumn column = new HbmColumn
					{
						unique = true,
						uniqueSpecified = false
					};
				bool? result = column.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_uniqueSpecified_is_true_and_unique_is_true()
			{
				HbmColumn column = new HbmColumn
					{
						uniqueSpecified = true,
						unique = true
					};
				bool? result = column.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_uniqueSpecified_is_true_and_unique_is_false()
			{
				HbmColumn column = new HbmColumn
					{
						uniqueSpecified = true,
						unique = false
					};
				bool? result = column.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}
	}
}