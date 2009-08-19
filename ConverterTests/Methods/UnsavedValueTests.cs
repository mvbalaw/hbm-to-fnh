using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class UnsavedValueTests
	{
		[TestFixture]
		public class When_asked_to_Add_unsaved_value
		{
			private CodeFileBuilder _builder;
			private UnsavedValue _unsavedValue;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_unsavedValue = new UnsavedValue(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_not_Id()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmSet(), null);
				_unsavedValue.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Id_and_unsavedvalue_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId(), null);
				_unsavedValue.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_not_Id_and_unsavedvalue_is__null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId
					{
						unsavedvalue = "null"
					}, null);
				_unsavedValue.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(".UnsavedValue(String.Empty)\r\n");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_not_Id_and_unsavedvalue_is_not__null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId
					{
						unsavedvalue = "6"
					}, null);
				_unsavedValue.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(".UnsavedValue(6)\r\n");
			}
		}
	}
}