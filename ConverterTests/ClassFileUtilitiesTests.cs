using NUnit.Framework;

namespace ConverterTests
{
	public class ClassFileUtilitiesTests
	{
		[TestFixture]
		public class When_asked_to_GetConstructorContents
		{
			[Test]
			public void Should_return_only_the_contents_of_the_named_zero_parameter_method()
			{
				const string input = @"using System;
					more stuff...
					public Constructor()
					{
						the
						body;
					}
					other stuff
					public bool AnotherMethod()
					{
						return true;
					}";
				string[] results = ClassFileUtilities.GetConstructorContents(input, "Constructor");
				results.ShouldBeEqualTo(new[] {"the", "body;"});
			}
		}
	}
}