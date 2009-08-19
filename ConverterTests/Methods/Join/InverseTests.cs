using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class InverseTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Not()
			{
				Inverse.FluentNHibernateNames.Not.ShouldBeEqualTo("Not");
			}

			[Test]
			public void Should_return_the_correct_value_for__Inverse()
			{
				Inverse.FluentNHibernateNames.Inverse.ShouldBeEqualTo("Inverse");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_an_inverse_relationship
		{
			private CodeFileBuilder _builder;
			private Inverse _inverse;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_inverse = new Inverse(_builder);
			}

			[Test]
			public void Should_generate_correct_code_given__true()
			{
				_inverse.Add(true);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}()\r\n", Inverse.FluentNHibernateNames.Inverse));
			}

			[Test]
			public void Should_generate_correct_code_given__False()
			{
				_inverse.Add(false);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}()\r\n", Inverse.FluentNHibernateNames.Not, Inverse.FluentNHibernateNames.Inverse));
			}
		}
	}
}