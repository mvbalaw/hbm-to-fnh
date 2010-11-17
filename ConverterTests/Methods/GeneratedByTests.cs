using System;
using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods;
using NUnit.Framework;

namespace ConverterTests.Methods
{
	public class GeneratedByTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__GeneratedBy()
			{
				GeneratedBy.FluentNHibernateNames.GeneratedBy.ShouldBeEqualTo("GeneratedBy");
			}

			[Test]
			public void Should_return_the_correct_value_for__Assigned()
			{
				GeneratedBy.FluentNHibernateNames.Assigned.ShouldBeEqualTo("Assigned");
			}

			[Test]
			public void Should_return_the_correct_value_for__Native()
			{
				GeneratedBy.FluentNHibernateNames.Native.ShouldBeEqualTo("Native");
			}

			[Test]
			public void Should_return_the_correct_value_for__Sequence()
			{
				GeneratedBy.FluentNHibernateNames.Sequence.ShouldBeEqualTo("Sequence");
			}
		}

		[TestFixture]
		public class When_asked_to_Add_unsaved_value
		{
			private CodeFileBuilder _builder;
			private GeneratedBy _generatedBy;

			[SetUp]
			public void BeforeEachTest()
			{
				_builder = new CodeFileBuilder();
				_generatedBy = new GeneratedBy(_builder);
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_not_Id()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmSet(), null);
				_generatedBy.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_return_empty_given_MappedPropertyInfo_Type_is_Id_and_generator_is_null()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId(), null);
				_generatedBy.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo("");
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_not_Id_and_generator_class_is__sequence()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId
					{
						generator = new HbmGenerator
							{
								@class = "sequence",
								param = new[]
									{
										new HbmParam
											{
												Text = new[] {"IX_NAME"}
											}
									}
							}
					}, null);
				_generatedBy.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}(\"IX_NAME\")\r\n", GeneratedBy.FluentNHibernateNames.GeneratedBy, GeneratedBy.FluentNHibernateNames.Sequence));
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_not_Id_and_generator_class_is__assigned()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId
					{
						generator = new HbmGenerator
							{
								@class = "assigned"
							}
					}, null);
				_generatedBy.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(String.Format(".{0}.{1}()\r\n", GeneratedBy.FluentNHibernateNames.GeneratedBy, GeneratedBy.FluentNHibernateNames.Assigned));
			}

			[Test]
			public void Should_generate_correct_code_given_MappedPropertyInfo_Type_is_not_Id_and_generator_class_is__native()
			{
				MappedPropertyInfo mappedPropertyInfo = new MappedPropertyInfo(new HbmId
					{
						generator = new HbmGenerator
							{
								@class = "native"
							}
					}, null);
				_generatedBy.Add(mappedPropertyInfo);
				string result = _builder.ToString();
				result.ShouldBeEqualTo(string.Format(".{0}.{1}()\r\n", GeneratedBy.FluentNHibernateNames.GeneratedBy, GeneratedBy.FluentNHibernateNames.Native));
			}
		}
	}
}