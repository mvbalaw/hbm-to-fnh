using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class NullabilityTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Not()
			{
				Nullability.FluentNHibernateNames.Not.ShouldBeEqualTo("Not");
			}

			[Test]
			public void Should_return_the_correct_value_for__Nullable()
			{
				Nullability.FluentNHibernateNames.Nullable.ShouldBeEqualTo("Nullable");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_nullability
		{
			private CodeFileBuilder _builder;
			private Nullability _nullability;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_nullability = new Nullability(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is__Id()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId(), null);
				_nullability.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is__Set()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmSet(), null);
				_nullability.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is__Bag()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmBag(), null);
				_nullability.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_valid_and_CanBeNull_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						notnullSpecified = false
					}, null);
				_nullability.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_valid_and_CanBeNull_is_true()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						notnullSpecified = true,
						notnull = false
					}, null);
				_nullability.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_valid_and_CanBeNull_is_false()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						notnullSpecified = true,
						notnull = true
					}, null);
				_nullability.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}()\r\n", Nullability.FluentNHibernateNames.Not, Nullability.FluentNHibernateNames.Nullable));
			}
		}
	}
}