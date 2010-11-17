using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class WhereTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Where()
			{
				Where.FluentNHibernateNames.Where.ShouldBeEqualTo("Where");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_where_clause
		{
			private CodeFileBuilder _builder;
			private Where _where;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_where = new Where(_builder);
			}

			[Test]
			public void Should_return_empty_if_sqlWhereClause_is_null()
			{
				_where.Add(null);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_sqlWhereClause_is_not_null()
			{
				_where.Add("Type = 'New'");
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(x => x.Type == \"New\")\r\n", Where.FluentNHibernateNames.Where));
			}
		}
	}
}