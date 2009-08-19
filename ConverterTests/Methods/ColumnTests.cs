using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class ColumnTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Column()
			{
				Column.FluentNHibernateNames.Column.ShouldBeEqualTo("Column");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_column_name
		{
			private CodeFileBuilder _builder;
			private Column _column;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_column = new Column(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Component()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmComponent(), null);
				_column.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Property()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmProperty(), null);
				_column.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Set()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmSet(), null);
				_column.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Bag()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmBag(), null);
				_column.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Id_and_columnName_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId(), null);
				_column.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_Id_and_columnName_is_not_null()
			{
				const string columnName = "FirstName";
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										name = columnName
									}
							}
					}, null);
				_column.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"{1}\")\r\n", Column.FluentNHibernateNames.Column, columnName));
			}
		}
	}
}