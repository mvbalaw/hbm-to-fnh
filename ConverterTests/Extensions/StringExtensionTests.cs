using NHibernateHbmToFluent.Converter.Extensions;
using NUnit.Framework;

namespace ConverterTests.Extensions
{
	public class StringExtensionTests
	{
		[TestFixture]
		public class When_asked_to_SplitOnFormattingWhitespace
		{
			[Test]
			public void Should_remove_newlines_and_tabs_and_return_resulting_array_of_strings()
			{
				const string input = @"
					these
					are
					some
					lines";
				string[] result = input.SplitOnFormattingWhitespace();
				result.ShouldBeEqualTo(new[] {"these", "are", "some", "lines"});
			}
		}

		[TestFixture]
		public class When_asked_to_GetTypeName
		{
			[Test]
			public void Should_return_the_type_name_given_a_full_type_descriptor()
			{
				const string input = "System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
				string result = input.GetTypeName();
				result.ShouldBeEqualTo("System.String");
			}

			[Test]
			public void Should_return_the_type_name_given_a_type_and_assembly()
			{
				const string input = "System.String, mscorlib";
				string result = input.GetTypeName();
				result.ShouldBeEqualTo("System.String");
			}

			[Test]
			public void Should_return_the_type_name_given_a_type_name()
			{
				const string input = "System.String";
				string result = input.GetTypeName();
				result.ShouldBeEqualTo("System.String");
			}
		}

		[TestFixture]
		public class When_asked_to_ParseInt32
		{
			[Test]
			public void Should_return_null_if_the_input_is_null()
			{
				const string input = null;
				int? result = input.ParseInt32();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_return_null_if_the_input_is_not_an_integer()
			{
				const string input = "ab2%";
				int? result = input.ParseInt32();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_return_the_correct_value_if_the_input_is_a_positive_integer()
			{
				const int input = 121;
				int? result = input.ToString().ParseInt32();
				result.ShouldBeEqualTo(input);
			}

			[Test]
			public void Should_return_the_correct_value_if_the_input_is_a_negative_integer()
			{
				const int input = -121;
				int? result = input.ToString().ParseInt32();
				result.ShouldBeEqualTo(input);
			}

			[Test]
			public void Should_return_the_correct_value_if_the_input_is_zero()
			{
				const int input = 0;
				int? result = input.ToString().ParseInt32();
				result.ShouldBeEqualTo(input);
			}
		}
	}
}