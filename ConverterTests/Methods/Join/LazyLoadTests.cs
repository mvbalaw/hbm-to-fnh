using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class LazyLoadTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__LazyLoad()
			{
				LazyLoad.FluentNHibernateNames.LazyLoad.ShouldBeEqualTo("LazyLoad");
			}

			[Test]
			public void Should_return_the_correct_value_for__Not()
			{
				LazyLoad.FluentNHibernateNames.Not.ShouldBeEqualTo("Not");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_lazy_load
		{
			private CodeFileBuilder _builder;
			private LazyLoad _lazyLoad;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_lazyLoad = new LazyLoad(_builder);
			}

			[Test]
			public void Should_return_empty_if_lazySpecified_is_false()
			{
				_lazyLoad.Add(false, HbmCollectionLazy.False);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given__HbmCollectionLazy_False__and_lazySpecified_is_true()
			{
				_lazyLoad.Add(true, HbmCollectionLazy.False);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}()\r\n", LazyLoad.FluentNHibernateNames.Not, LazyLoad.FluentNHibernateNames.LazyLoad));
			}

			[Test]
			public void Should_generate_correct_code_given__HbmCollectionLazy_True__and_lazySpecified_is_true()
			{
				_lazyLoad.Add(true, HbmCollectionLazy.True);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}()\r\n", LazyLoad.FluentNHibernateNames.LazyLoad));
			}
		}
	}
}