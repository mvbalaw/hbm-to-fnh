using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmSetExtensionsTests
	{
		[TestFixture]
		public class When_asked_if_IsUnique
		{
			[Test]
			public void Should_get__true__given_key_uniqueSpecified_and_unique_are_true()
			{
				HbmSet set = new HbmSet
					{
						key = new HbmKey
							{
								uniqueSpecified = true,
								unique = true
							}
					};
				bool? result = set.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_key_uniqueSpecified_is_true_and_unique_is_false()
			{
				HbmSet set = new HbmSet
					{
						key = new HbmKey
							{
								uniqueSpecified = true,
								unique = false
							}
					};
				bool? result = set.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}

			[Test]
			public void Should_get_null_given_key_uniqueSpecified_is_false()
			{
				HbmSet set = new HbmSet
					{
						key = new HbmKey
							{
								uniqueSpecified = false,
								unique = true
							}
					};
				bool? result = set.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_key_is_null()
			{
				HbmSet set = new HbmSet
					{
						key = null
					};
				bool? result = set.IsUnique();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_to_GetPropertyName
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "FirstName";
				HbmSet set = new HbmSet
					{
						name = expected
					};
				string result = set.GetPropertyName();
				result.ShouldBeEqualTo(expected);
			}
		}


		[TestFixture]
		public class When_asked_to_GetReturnType
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "System.String";
				HbmSet set = new HbmSet
					{
						Item = new HbmOneToMany
							{
								@class = expected + ", mscorlib"
							}
					};
				string result = set.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetColumnName
		{
			[Test]
			public void Should_get_the_correct_value_from_key()
			{
				const string expected = "FirstName";
				HbmSet set = new HbmSet
					{
						key = new HbmKey
							{
								column1 = expected
							}
					};
				string result = set.GetColumnName();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_if_CanBeNull
		{
			[Test]
			public void Should_get__true__given_inverse_is_true()
			{
				HbmSet set = new HbmSet
					{
						inverse = true
					};
				bool? result = set.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_inverse_is_false()
			{
				HbmSet set = new HbmSet
					{
						inverse = false
					};
				bool? result = set.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}
	}
}