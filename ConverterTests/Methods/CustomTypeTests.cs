using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class CustomTypeTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__CustomType()
			{
				CustomType.FluentNHibernateNames.CustomType.ShouldBeEqualTo("CustomType");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_custom_type
		{
			private CodeFileBuilder _builder;
			private CustomType _customType;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_customType = new CustomType(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_not_Property()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmComponent(), null);
				_customType.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Property_and_ReturnType_is_not__YesNo()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						type1 = "System.String"
					}, null);
				_customType.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Property_and_SqlType_is_not__CHAR()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						column = "VARCHAR2"
					}, null);
				_customType.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_Property_and_length_is_not_null()
			{
				const string yesNo = "YesNo";
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						column = "CHAR",
						type1 = yesNo
					}, null);
				_customType.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"{1}\")\r\n", CustomType.FluentNHibernateNames.CustomType, yesNo));
			}
		}
	}
}