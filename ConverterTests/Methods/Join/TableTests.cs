using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class TableTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Table()
			{
				Table.FluentNHibernateNames.Table.ShouldBeEqualTo("Table");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_table
		{
			private CodeFileBuilder _builder;
			private Table _table;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_table = new Table(_builder);
			}

			[Test]
			public void Should_return_empty_if_tableName_is_null()
			{
				_table.Add(null);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_tableName_is_not_null()
			{
				_table.Add("Person");
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"Person\")\r\n", Table.FluentNHibernateNames.Table));
			}
		}
	}
}