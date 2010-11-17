using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class CascadeTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Cascade()
			{
				Cascade.FluentNHibernateNames.Cascade.ShouldBeEqualTo("Cascade");
			}

			[Test]
			public void Should_return_the_correct_value_for__SaveUpdate()
			{
				Cascade.FluentNHibernateNames.SaveUpdate.ShouldBeEqualTo("SaveUpdate");
			}

			[Test]
			public void Should_return_the_correct_value_for__None()
			{
				Cascade.FluentNHibernateNames.None.ShouldBeEqualTo("None");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_cascade_type
		{
			private CodeFileBuilder _builder;
			private Cascade _cascade;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_cascade = new Cascade(_builder);
			}

			[Test]
			public void Should_generate_correct_code_given__save_update()
			{
				_cascade.Add("save-update");
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}()\r\n", Cascade.FluentNHibernateNames.Cascade, Cascade.FluentNHibernateNames.SaveUpdate));
			}

			[Test]
			public void Should_generate_correct_code_given__none()
			{
				_cascade.Add("none");
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}()\r\n", Cascade.FluentNHibernateNames.Cascade, Cascade.FluentNHibernateNames.None));
			}
		}
	}
}