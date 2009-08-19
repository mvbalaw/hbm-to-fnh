using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class UniqueTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Unique()
			{
				Unique.FluentNHibernateNames.Unique.ShouldBeEqualTo("Unique");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_uniqueness
		{
			private CodeFileBuilder _builder;
			private Unique _unique;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_unique = new Unique(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is__Id()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId(), null);
				_unique.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Property_and_unique_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						updateSpecified = false
					}, null);
				_unique.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_Property_and_unique_is_not_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						updateSpecified = true,
						unique = true
					}, null);
				_unique.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}()\r\n", Unique.FluentNHibernateNames.Unique));
			}
		}
	}
}