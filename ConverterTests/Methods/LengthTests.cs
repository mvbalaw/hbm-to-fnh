using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class LengthTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Length()
			{
				Length.FluentNHibernateNames.Length.ShouldBeEqualTo("Length");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_length
		{
			private CodeFileBuilder _builder;
			private Length _length;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_length = new Length(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_not_Property()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmComponent(), null);
				_length.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Property_and_length_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty(), null);
				_length.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_Property_and_length_is_not_null()
			{
				const string length = "6";
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						length = length
					}, null);
				_length.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}({1})\r\n", Length.FluentNHibernateNames.Length, length));
			}
		}
	}
}