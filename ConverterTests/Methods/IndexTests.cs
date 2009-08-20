using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
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

		[TestFixture]
		public class When_asked_to_Add_an_index
		{
			private CodeFileBuilder _builder;
			private Index _index;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_index = new Index(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Id()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId(), null);
				_index.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_valid_and_UniqueIndex_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						index = null
					}, null);
				_index.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_valid_and_UniqueIndex_is_not_null()
			{
				const string index = "FirstName";
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty
					{
						index = index
					}, null);
				_index.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"{1}\")\r\n", Index.FluentNHibernateNames.Index, index));
			}
		}
	}
}