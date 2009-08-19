using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;

namespace ConverterTests.Methods.Join
{
	public class KeyColumnTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__ChildKeyColumn()
			{
				KeyColumn.FluentNHibernateNames.ChildKeyColumn.ShouldBeEqualTo("ChildKeyColumn");
			}

			[Test]
			public void Should_return_the_correct_value_for__ParentKeyColumn()
			{
				KeyColumn.FluentNHibernateNames.ParentKeyColumn.ShouldBeEqualTo("ParentKeyColumn");
			}

			[Test]
			public void Should_return_the_correct_value_for__KeyColumn()
			{
				KeyColumn.FluentNHibernateNames.KeyColumn.ShouldBeEqualTo("KeyColumn");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_a_key_column
		{
			private CodeFileBuilder _builder;
			private KeyColumn _keyColumn;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_keyColumn = new KeyColumn(_builder);
			}

			[Test]
			public void Should_generate_correct_code_given__Many_to_Many_if_relationship_is_inversed()
			{
				_keyColumn.Add(true, "Name", PropertyMappingType.ManyToMany);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"Name\")\r\n", KeyColumn.FluentNHibernateNames.ChildKeyColumn));
			}

			[Test]
			public void Should_generate_correct_code_given__Many_to_Many_if_relationship_is_not_inversed()
			{
				_keyColumn.Add(false, "Name", PropertyMappingType.ManyToMany);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"Name\")\r\n", KeyColumn.FluentNHibernateNames.ParentKeyColumn));
			}

			[Test]
			public void Should_generate_correct_code_given__One_to_Many()
			{
				_keyColumn.Add(false, "Name", PropertyMappingType.OneToMany);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}(\"Name\")\r\n", KeyColumn.FluentNHibernateNames.KeyColumn));
			}
		}
	}
}