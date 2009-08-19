using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class OrderByTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__OrderBy()
			{
				OrderBy.FluentNHibernateNames.OrderBy.ShouldBeEqualTo("OrderBy");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_order_by
		{
			private CodeFileBuilder _builder;
			private OrderBy _orderBy;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_orderBy = new OrderBy(_builder);
			}

			[Test]
			public void Should_return_empty_if_orderBy_is_null()
			{
				_orderBy.Add(null);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_orderBy_is_not_null()
			{
				_orderBy.Add("Name DESC");
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"Name DESC\")\r\n", OrderBy.FluentNHibernateNames.OrderBy));
			}
		}
	}
}